using Flashcard.AppServices.APIs.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flashcard.AppServices.APIs.Filters
{
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext context)
        {
            ResponseBase r = new ResponseBase();
            r.IsSuccess = false;
            r.Message = context.Exception.Message;
            context.Result = new ObjectResult(r)
            {
                StatusCode = 500,
                DeclaredType = typeof(ResponseBase)
            };

        }
    }
}
