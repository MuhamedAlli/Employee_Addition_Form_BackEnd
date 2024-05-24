using AutoMapper;
using Employee_Addition_Form_BackEnd.Application.Dtos.RequestDtos;
using Employee_Addition_Form_BackEnd.Application.Dtos.ResponseDtos;
using Employee_Addition_Form_BackEnd.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Application.Mapper
{
    public class MappingProfile :Profile
    {
        public MappingProfile()
        {
            //Employee Mapping
            CreateMap<EmployeeFormDto, Employee>(); //Mapp From EmployeeFormDto To Employee
            CreateMap<Employee, EmployeeDto>()
                .ReverseMap(); ////Mapp From Employee To  EmployeeDto
        }
    }
}
