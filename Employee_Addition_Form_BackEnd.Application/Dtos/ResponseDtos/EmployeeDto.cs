using Employee_Addition_Form_BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Application.Dtos.ResponseDtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string JobRole { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public bool IsFirstAppointment { get; set; }
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
