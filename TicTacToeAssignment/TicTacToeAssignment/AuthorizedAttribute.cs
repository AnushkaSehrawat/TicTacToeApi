using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToeAssignment
{
    public class AuthorizedAttribute : ResultFilterAttribute, IActionFilter
    {
        Authorization authobject = new Authorization();
        string apiKey = null;
        public void OnActionExecuted(ActionExecutedContext context)
        {
            ////throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
             apiKey = context.HttpContext.Request.Headers["apikey"].ToString();
            string response = authobject.AuthenticateUser(apiKey);
            if (apiKey == null)
            {
                throw new Exception("Api Key not provided");
            }
            if (response==null)
            {
                throw new Exception("Not a valid api key");
            }
        }
    }
}
