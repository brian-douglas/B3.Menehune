using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using B3.Menehune.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace B3.Menehune.Infrastructure
{
    public class MenehuneMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MenehuneMiddleware> _logger;

        public MenehuneMiddleware(RequestDelegate next, ILogger<MenehuneMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            var path = context.Request.Path.Value;
            if (path.Contains("/MenehuneState"))
            {
                await _next(context);
                return;
            }

            var returnStrategy = MenehuneState.Instance.ReturnStrategy;

            //if active
            switch (returnStrategy)
            {
                case ServiceReturnStrategies.Return500Error:
                    _logger.Log(LogLevel.Information, "Menehune says '500 Error'");
                    context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                    await context.Response.WriteAsync("Menehune here!");
                    break;

                case ServiceReturnStrategies.NeverReturn:
                    _logger.Log(LogLevel.Information, "Menehune says 'Never Return'");
                    Thread.Sleep(TimeSpan.FromDays(1));
                    context.Response.StatusCode = (int) HttpStatusCode.GatewayTimeout;
                    await context.Response.WriteAsync("Menehune here!");
                    break;

                default:
                    await _next(context);
                    break;
            }
        }



    }
}
