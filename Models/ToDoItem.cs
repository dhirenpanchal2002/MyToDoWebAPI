using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDoWebAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ToDoItemPriority Priority { get; set; }

        public Boolean IsActive { get; set; }
    }
}
