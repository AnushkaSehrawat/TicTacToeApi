using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace TicTacToeAssignment
{
    public class LogAttribute : ResultFilterAttribute, IActionFilter
    {
        Logger logObject = new Logger();
        IRepo addingObject;
        GetRepoInstance repoObject = new GetRepoInstance();
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null)
            {
                addingObject = repoObject.getInstance("sql");
                logObject.Request = context.RouteData.Values["action"].ToString() + " " + context.RouteData.Values["controller"].ToString();
                logObject.Response = "Success";
                logObject.Exception = "NULL";
                addingObject.addlog(logObject);
            }

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //addingObject = repoObject.getInstance("sql");
            //logObject.Request = context.RouteData.Values["action"].ToString()+" " + context.RouteData.Values["controller"].ToString();
            //logObject.Response = "NULL";
            //logObject.Exception = "NULL";
            //addingObject.addlog(logObject);
            
        }
    }
}
