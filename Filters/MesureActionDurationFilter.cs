using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace DemoAppWebAPI.Filters
{
    public class MesureActionDurationFilter : Attribute, IActionFilter
    {
        private string _attributeName;
        
        public MesureActionDurationFilter(string name)
        {
            _attributeName = name;
        }
        void IActionFilter.OnActionExecuted(ActionExecutedContext context)
        {
            
            Console.WriteLine($"After excuted..{_attributeName} - {DateTime.Now.ToString()}");
        }

        void IActionFilter.OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"Before excuting..{_attributeName} - {DateTime.Now.ToString()}");
        }
    }
}
