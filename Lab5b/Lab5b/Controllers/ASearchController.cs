using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5b.Controllers
{
    public class ASearchController : Controller
    {
        [MyAction]
        [Route("~/ASearch/AA")]
        public string AA()
        {
            return "<br/>Action: AA";
        }

        [MyResult]
        [Route("AR")]
        public string AR()
        {
            return "<br/>Action: AR<br/>";
        }

        [MyException]
        [Route("AE")]
        public string AE()
        {
            int[] mas = new int[2];
            mas[6] = 4;
            return "<br/>Action: AE";
        }
    }
    public class MyActionAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Действие выполнено");
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.HttpMethod == "GET")
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
    public class MyResultAttribute : FilterAttribute, IResultFilter
    {

        public void OnResultExecuted(ResultExecutedContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Время текущего запроса HTTP: " + filterContext.HttpContext.Timestamp);
        }

        public void OnResultExecuting(ResultExecutingContext filterContext)
        {

            filterContext.HttpContext.Response.Write("Метод: " + filterContext.HttpContext.Request.HttpMethod);
        }
    }

    public class MyException : FilterAttribute, IExceptionFilter
    {

        public void OnException(ExceptionContext exceptionContext)
        {
            if (!exceptionContext.ExceptionHandled && exceptionContext.Exception is IndexOutOfRangeException)
            {
                var content = new ContentResult();
                content.Content = "Errors happens";
                exceptionContext.Result = content;
                exceptionContext.ExceptionHandled = true;
            }
        }
    }
}