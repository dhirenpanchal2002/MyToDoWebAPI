using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Models
{
    public class ServiceResponse<T>
    {
        public T data { get; set; }

        public bool IsSuccess { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
