﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WalksAPI.CustomActionFilter
{
    public class ValidateModelAttributes : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.ModelState.IsValid ==false)
            {
                context.Result = new BadRequestResult ();
            }
        }
    }
    
    
}
