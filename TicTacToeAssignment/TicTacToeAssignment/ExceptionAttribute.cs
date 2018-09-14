using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToeAssignment.Model;

namespace TicTacToeAssignment
{
    public class ExceptionAttribute:ExceptionFilterAttribute
    {
        Logger logObject = new Logger();
       
        IRepo addingobject;
        GetRepoInstance repoObject = new GetRepoInstance();

        public override void OnException(ExceptionContext actionExecutedContext)
        {
            if (actionExecutedContext.Exception is Exception)
            {
                addingobject = repoObject.getInstance("sql");
                logObject.Request = actionExecutedContext.RouteData.Values["action"].ToString() + " " + actionExecutedContext.RouteData.Values["controller"].ToString();
                logObject.Exception = actionExecutedContext.Exception.ToString();
                var index= logObject.Exception.IndexOf("\r");
                logObject.Exception = logObject.Exception.Substring(0, index);
                logObject.Response = "Failure";
                addingobject.addlog(logObject);
            }
        }
    }
}
