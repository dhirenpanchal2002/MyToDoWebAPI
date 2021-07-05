using DemoAppWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAppWebAPI.Dto.ToDoDto
{
    public class GetToDoDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; } = null;

        public ToDoItemPriority Priority { get; set; } = ToDoItemPriority.Medium;

        public Boolean IsActive { get; set; } = true;
    }
}
