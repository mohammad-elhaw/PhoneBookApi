﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Presentation.ActionFilters
{
    public class ValidationFilterAttribute : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var action = context.RouteData.Values["action"];
            var controller = context.RouteData.Values["controller"];

            var param = context.ActionArguments
                .FirstOrDefault(x => x.Value.ToString().Contains("Dto")).Value;

            if(param is null)
            {
                context.Result =
                    new BadRequestObjectResult($"Object is null. Controller: {controller}, Action {action}");
                return;
            }
            if(!context.ModelState.IsValid)
                context.Result = new UnprocessableEntityObjectResult(context.ModelState);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
