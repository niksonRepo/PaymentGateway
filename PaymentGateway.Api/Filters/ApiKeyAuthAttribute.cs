using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PaymentGateway.Api.Filters
{
    [AttributeUsage(validOn:AttributeTargets.Class | AttributeTargets.Method)]
    public class ApiKeyAuthAttribute: Attribute, IAsyncActionFilter
    {
        private const string ApiKeyHeaderName = "ApiKey";

        public async Task OnActionExecutionAsync ( ActionExecutingContext context, ActionExecutionDelegate next )
        {
            if(!context.HttpContext.Request.Headers.TryGetValue( ApiKeyHeaderName , out var clientApiKey) )
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var apikey = configuration.GetValue<string> ( key: "ApiKey" );

            if(!apikey.Equals(clientApiKey))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            await next();            
        }
    }
}
