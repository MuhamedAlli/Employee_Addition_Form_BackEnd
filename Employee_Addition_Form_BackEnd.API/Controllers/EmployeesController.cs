using AutoMapper;
using Employee_Addition_Form_BackEnd.Application.Dtos;
using Employee_Addition_Form_BackEnd.Application.Dtos.RequestDtos;
using Employee_Addition_Form_BackEnd.Application.Dtos.ResponseDtos;
using Employee_Addition_Form_BackEnd.Application.Interfaces;
using Employee_Addition_Form_BackEnd.Domain.Consts;
using Employee_Addition_Form_BackEnd.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Employee_Addition_Form_BackEnd.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public EmployeesController(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var employees = _dbContext.Employees.ToList();
            var dto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            return Ok(
                   new SuccessResponseDto<IEnumerable<EmployeeDto>>
                   {
                       Message = SuccessMessages.Success,
                       Data = dto
                   });
        }

        [HttpPost("Create")]
        public IActionResult Create(EmployeeFormDto employeeFormDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

                return BadRequest(
                    new FailureResponseDto
                    {
                        Message = ErrorMessages.Failed,
                        Errors = errors
                    });
            }

            var employee = _mapper.Map<Employee>(employeeFormDto);
            _dbContext.Employees.Add(employee);
            var result = _dbContext.SaveChanges();

            if (result <= 0)
                return BadRequest(new { Meassage = ErrorMessages.SomethingWrong });

            var dto = _mapper.Map<EmployeeDto>(employee);
            return Ok(
                new SuccessResponseDto<EmployeeDto>
                {
                    Message = SuccessMessages.Success,
                    Data = dto
                });
        }


        //Get Employee By id  
        [HttpGet("GetById/{id}")]
        public IActionResult GetById(int id)
        {
            var emp = _dbContext.Employees.Find(id);
            if (emp is null)
            {
                return NotFound(
                    new FailureResponseDto
                    {
                        Message = ErrorMessages.Failed,
                        Errors = { ErrorMessages.NotFound }
                    });
            }

            var dto = _mapper.Map<EmployeeDto>(emp);

            return Ok(
                new SuccessResponseDto<EmployeeDto>
                {
                    Message = SuccessMessages.Success,
                    Data = dto
                });
        }


        [HttpPost("Update")]
        public IActionResult Update([FromQuery]int id , [FromBody]EmployeeFormDto employeeFormDto)
        {
            Debug.WriteLine("ID ===  "+id);
			Debug.WriteLine("Emplo ===  " + employeeFormDto.Name);

			var emp = _dbContext.Employees.Find(id);

            if (emp is null)
            {
                return NotFound(new {Message= ErrorMessages.NotFound});
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                   .Select(e => e.ErrorMessage)
                                   .ToList();

                return BadRequest(
                    new FailureResponseDto
                    {
                        Message = ErrorMessages.Failed,
                        Errors = errors
                    });
            }

            emp = _mapper.Map(employeeFormDto,emp);

            var result = _dbContext.SaveChanges();

            if (result <= 0)
                return BadRequest(new { Meassage = ErrorMessages.SomethingWrong });

            var dto = _mapper.Map<EmployeeDto>(emp);
            return Ok(
                new SuccessResponseDto<EmployeeDto>
                {
                    Message = SuccessMessages.Success,
                    Data = dto
                });
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromQuery]int id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee is null)
            {
                return NotFound(
                    new FailureResponseDto
                    {
                        Message = ErrorMessages.Failed,
                        Errors = { ErrorMessages.NotFound }
                    });
            }
            _dbContext.Employees.Remove(employee);

            var result=_dbContext.SaveChanges();
            if (result <= 0)
                return BadRequest(new {Meassage=ErrorMessages.SomethingWrong});

             return Ok(new{Message = SuccessMessages.Success});
        }

    }
}
