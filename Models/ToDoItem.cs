using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemoAppWebAPI.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 200, ErrorMessage = "Description cannot be greater then 200")]
        public string Name { get; set; }

        [Required]
        [StringLength(maximumLength:500,ErrorMessage ="Description cannot be greater then 500")]
        public string Description { get; set; } = null;

        public ToDoItemPriority Priority { get; set; } = ToDoItemPriority.Medium;

        public ToDoItemStatus Status { get; set; } = ToDoItemStatus.Pending;

        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedDate { get; set; } = null;
        public Boolean IsActive { get; set; } = true;

        public User User { get; set; }
    }
}
