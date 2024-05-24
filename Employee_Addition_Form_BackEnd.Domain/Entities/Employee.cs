using Employee_Addition_Form_BackEnd.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; } = null!;
        public JobRole JobRole { get; set; }
        public Gender Gender { get; set; }
        public bool IsFirstAppointment { get; set; }
        public DateTime StartDate { get; set; }
        public string? Notes { get; set; }
    }
}
