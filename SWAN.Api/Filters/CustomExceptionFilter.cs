using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace SWAN.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        private readonly ILogger _errorLogger = LogManager.GetLogger("errorLogger");
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            string exceptionMessage = string.Empty;
            if (actionExecutedContext.Exception.InnerException == null)
            {
                exceptionMessage = actionExecutedContext.Exception.Message;
                _errorLogger.Error(actionExecutedContext.Exception + exceptionMessage + actionExecutedContext.Exception.StackTrace);
            }
            else
            {
                exceptionMessage = actionExecutedContext.Exception.InnerException.Message;
                _errorLogger.Error(actionExecutedContext.Exception + exceptionMessage + actionExecutedContext.Exception.StackTrace);
            }
            //We can log this exception message to the file or database.  
            var response = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("An unhandled exception was thrown by service."),
                ReasonPhrase = "Internal Server Error.Please Contact your Administrator.",
                StatusCode = HttpStatusCode.InternalServerError
            };

            actionExecutedContext.Response = response;
        }
    }
}