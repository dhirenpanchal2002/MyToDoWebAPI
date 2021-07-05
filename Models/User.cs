using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppWebAPI.Models
{
    public class User
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        public string EmailId { get; set; } = null;

        public byte[] PwdHash { get; set; }

        public byte[] PwdSalt { get; set; }

        public List<ToDoItem> ToDoItems { get; set; }
    }
}
