using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppWebAPI.Dto.User
{
    public class UserLoginDto
    {
        public string Password { get; set; }

        public string UserName { get; set; }

        public string NewPassword { get; set; }
    }
}
