using DNC_WS.EmptyApp;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
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

        private string _number;

        private readonly WaitService _waitService;

        public ReinRausMiddleware(RequestDelegate next, 
                                    IOptions<ReinRausOptions> options,
                                    WaitService waitService )
        {
            _next = next;
            _number = options.Value.Nummer;
            _waitService = waitService;
        }
        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            await context.Response.WriteAsync($"{_number} rein</br>");
            await _waitService.Wait();
            await _next(context);
            await _waitService.Wait();
            await context.Response.WriteAsync($"{_number} raus</br>");
        }
    }
}
