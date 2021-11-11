using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DemoAppWebAPI.Models
{
    public enum ToDoItemPriority
    {
        [Display(Name = "Low")]
        Low = 1,
        [Display(Name = "Medium")]
        Medium = 7,

        [Display(Name = "High")]
        High = 11
}

    public enum ToDoItemStatus
    {
        [Display(Name = "Pending")]
        Pending = 0,

        [Display(Name = "InProgress")]
        InProgress = 11,

        [Display(Name = "Completed")]
        Completed = 23,
        
        [Display(Name = "Deferred")]
        Deferred =47
    }
}
