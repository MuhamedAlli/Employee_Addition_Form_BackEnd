using Employee_Addition_Form_BackEnd.Domain.Consts;
using Employee_Addition_Form_BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Application.Dtos.RequestDtos
{
    public class EmployeeFormDto
    {
        [MaxLength(50,ErrorMessage =ErrorMessages.MaxLength)]
        [Required(ErrorMessage =ErrorMessages.Required)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = ErrorMessages.Required)]
        public JobRole JobRole { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public bool IsFirstAppointment { get; set; }

        [Required(ErrorMessage = ErrorMessages.Required)]
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
