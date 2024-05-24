using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Application.Dtos
{
    public class FailureResponseDto
    {
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
    }
}
