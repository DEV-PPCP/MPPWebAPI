using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace PPCPWebApiServices.Controllers
{
    public class DefaultXmlController : ApiController
    {
        public class ServiceMethodMetaData
        {
            public string WebMethodName;
            public string XMLdata;

        }
        public object Post([FromBody]ServiceMethodMetaData value)
        {
            HttpResponseMessage result;
            object ResultValue = null;
            List<object> objemp = new List<object>();
            if (value != null)
            {
                Type magicType = Type.GetType("PPCPWebApiServices.ServiceAccess.DefaultServiceMethod");
                ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
                object magicClassObject = magicConstructor.Invoke(new object[] { });
                // Get the ItsMagic method and invoke with a parameter value of  
                MethodInfo magicMethod = magicType.GetMethod(value.WebMethodName);
                string perinfo = value.XMLdata;
                object[] paraValue = new object[1];
                for (int i = 0; i < 1; i++)
                {
                    paraValue[i] = perinfo;
                }
                ResultValue = magicMethod.Invoke(magicClassObject, paraValue);
                //ServiceMethods cs = new ServiceMethods();

                //DoctorDetails obj = (DoctorDetails)ResultValue;
                //ResultValue = ResultValue;
                // result= ResultValue.ToString();
                objemp.Add(ResultValue);
                //result = Request.CreateResponse(HttpStatusCode.Created, ResultValue);
                // return result;
            }
            else
            {
                //return new { Result = "Nothing" };
                result = Request.CreateResponse(HttpStatusCode.BadRequest, "Server failed to save data");

            }
            return Json(objemp);
        }
    }
}