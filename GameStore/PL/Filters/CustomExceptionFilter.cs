using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Linq;

namespace PL.Filters
{
    public class CustomExceptionFilterAttribute : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var action = context.ActionDescriptor.DisplayName;
            var exceptionMessage = context.Exception.Message;

            if (context.Exception is AggregateException aggregateException)
            {
                exceptionMessage = "Several exceptions might happen" +
                    string.Join(';', aggregateException.InnerExceptions.Select(e => e.Message));
            }

            context.Result = new ContentResult
            {
                Content = $"Calling {action} failed, because: {exceptionMessage}.",
                StatusCode = 400
            };
            context.ExceptionHandled = true;
        }
    }
}
