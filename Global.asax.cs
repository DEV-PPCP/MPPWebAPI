using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LabWebApiServices
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static string ErrorLogFolder = System.Configuration.ConfigurationManager.AppSettings["ErrorLogFolder"].ToString();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            HttpConfiguration config = GlobalConfiguration.Configuration;
            config.Formatters.JsonFormatter
                        .SerializerSettings
                        .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Serialize;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        }
        protected void Application_BeginRequest(Object sender, EventArgs e)
        {
           // HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
            {
                HttpContext.Current.Response.AddHeader("Cache-Control", "no-cache");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "GET, POST");
                HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
                HttpContext.Current.Response.AddHeader("Access-Control-Max-Age", "1728000");
                HttpContext.Current.Response.End();
            }
        }

        protected void Application_error(Object sender, EventArgs e)
        {
            #region Exception
            Exception exception = Server.GetLastError();
            string SystemName = System.Net.Dns.GetHostName();
            string dir = ErrorLogFolder;
            string file = dir + @"\" + DateTime.Today.ToString("MM-dd-yyyy") + ".txt";
            if (!(Directory.Exists(dir)))
            {
                Directory.CreateDirectory(dir);
            }
            System.IO.StreamWriter sw = new System.IO.StreamWriter(file, true);
            sw.WriteLine("=================================================");
            sw.WriteLine("====================" + DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
            sw.WriteLine("Loggedin Provider NPI: UserLogin");
            sw.WriteLine("SystemName : " + SystemName);
            sw.WriteLine("Error Description : " + exception.ToString());
            //sw.WriteLine("Error Source : " + Errorsource.ToString());
            //sw.WriteLine("Errorno : " + Errorno.ToString());
            //sw.WriteLine("Class Name : " + Classname);
            //sw.WriteLine("Method Name : " + Methodname);
            sw.WriteLine("=====================================================");
            sw.Flush();
            sw.Close();

            #endregion
        }
    }
}
