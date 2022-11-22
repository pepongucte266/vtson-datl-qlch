using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace datn_qlch_be.Core.Exceptions
{
    public class HttpResponseExceptionFilter : IActionFilter, IOrderedFilter
    {
        public int Order => int.MaxValue - 10;

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception is HttpResponseException httpResponseException)
            {
                context.Result = new ObjectResult(httpResponseException.Value)
                {
                    StatusCode = httpResponseException.StatusCode
                };

                context.ExceptionHandled = true;
            }
            else if (context.Exception is MISAValidateException)
            {
                var res = new
                {
                    userMsg = context.Exception.Message,
                    devMsg = "Lỗi",
                    data = context.Exception.Data
                };

                context.Result = new ObjectResult(res)
                {
                    StatusCode = 400
                };
                context.ExceptionHandled = true;
            }
        }
    }
}
