using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Addition_Form_BackEnd.Application.Dtos
{
    public class SuccessResponseDto<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
