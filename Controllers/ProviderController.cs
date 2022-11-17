using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace PPCPWebApiServices.Controllers
{
    public class ProviderController : ApiController
    {
        public class ServiceData
        {
            public string WebMethodName;
            public string[] ParameterName;
            public string[] ParameterValue;
            //testing git commit
        }

        public object Post([FromBody]ServiceData value)
        {
            HttpResponseMessage result;
            object ResultValue = null;
            List<object> objemp = new List<object>();
            if (value != null)
            {
                Type magicType = Type.GetType("PPCPWebApiServices.ServiceAccess.ProviderService");
                ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
                object magicClassObject = magicConstructor.Invoke(new object[] { });
                // Get the ItsMagic method and invoke with a parameter value of  
                MethodInfo magicMethod = magicType.GetMethod(value.WebMethodName);
                ParameterInfo[] perinfo = magicMethod.GetParameters();
                object[] paraValue = new object[perinfo.Length];
                for (int i = 0; i < perinfo.Length; ++i)
                {
                    for (int j = 0; j < value.ParameterValue.Length && j < value.ParameterName.Length; ++j)
                    {
                        if (perinfo[i].Name.ToLower() == value.ParameterName[j].ToLower())
                        {
                            paraValue[i] = value.ParameterValue[j].Replace('^', '\"');
                            break;
                        }
                    }
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