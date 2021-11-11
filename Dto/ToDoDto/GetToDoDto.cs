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

        public ToDoItemPriority Priority { get; set; }

        public string PriorityName { get { return Priority.ToString("F"); }  }

        public Boolean IsActive { get; set; } = true;

        public string StatusName { get { return Status.ToString("F"); } }

        public ToDoItemStatus Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string City { get; set; }
    }
}
