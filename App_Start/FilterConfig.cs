using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Mvc;

namespace LabWebApiServices
{
    public class FilterConfig : ExceptionFilterAttribute
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
        //public override void OnException(HttpActionExecutedContext context)
        //{
        //    if (context.Exception is NotImplementedException)
        //    {
        //        context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
        //    }
        //}
    }
}
