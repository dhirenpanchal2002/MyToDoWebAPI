using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace DemoAppWebAPI.Middlewares
{
    public class ExceptionHandlingMiddleware : IMiddleware
    {
        async Task IMiddleware.InvokeAsync(HttpContext context, RequestDelegate next)
        {

            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await context.Response.WriteAsync(e.Message);
                // throw new Exception(e.Message);
            }
        }
    }
}
