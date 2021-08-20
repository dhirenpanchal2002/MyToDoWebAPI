using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoAppWebAPI.Filters
{
    public class AsyncFilterAttribute : Attribute, IAsyncActionFilter
    {
        private string _attributeName;

        public AsyncFilterAttribute(string name)
        {
            _attributeName = name;
        }
        async Task IAsyncActionFilter.OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            Console.WriteLine($"Before AsyncFilterAttribute excuting..{_attributeName} - {DateTime.Now.ToString()}");
            await next();
            Console.WriteLine($"After AsyncFilterAttribute excuted..{_attributeName} - {DateTime.Now.ToString()}");
        }
    }
}
