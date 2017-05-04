using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DNC_WS
{
    /// <summary>
    /// middleware basis impl nur in out 
    /// </summary>
    public class ReinRausMiddleware
    {
        private readonly RequestDelegate _next;

        public ReinRausMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync("Eins rein</br>");
            await _next(context);
            await context.Response.WriteAsync("Eins raus</br>");
        }
    }
}
