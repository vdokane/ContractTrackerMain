using ContractTracker.Common.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using Newtonsoft.Json;

namespace ContractTracker.API.Middleware
{
    
    public class BusinessRuleExceptionMiddleware 
    {
        private readonly RequestDelegate _next;

        public BusinessRuleExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError; // 500 if unexpected

            if (ex is BusinessRuleException)
            {
                code = HttpStatusCode.BadRequest;
            }

            var newErr = (BusinessRuleException)ex;
            var result = JsonConvert.SerializeObject(new { isBusinessException = true, messages = newErr.ValidationMessages.ToArray() });   
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;

            return context.Response.WriteAsync(result);
        }
    }

    public static class RequestBusinessRuleExceptionMiddleware
    {
        public static IApplicationBuilder UseBusinessRuleException(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<BusinessRuleExceptionMiddleware>();
        }
    }
}
