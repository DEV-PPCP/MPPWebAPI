using PPCPWebApiServices.Models.PPCPWebService.DAL;
using PPCPWebApiServices.Models.PPCPWebService.DC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;
using static PPCPWebApiServices.Models.PPCPWebService.DC.DCProviderService;

namespace PPCPWebApiServices.ServiceAccess
{
    public class ProviderService
    {
        DALProviderService objDalProvider = new DALProviderService();

        public Object CreateObject(string XMLString, Object YourClassObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
            //The StringReader will be the stream holder for the existing XML file 
            YourClassObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            //initially deserialized, the data is represented by an object without a defined type 
            return YourClassObject;
        }
       

        //public object UpdatePassword(string ProviderID,string Password)
        //{
        //    List<Result> res = objDalProvider.UpdatePassword(Convert.ToInt32(ProviderID), Password);
        //    return res;
        //}
        /// <summary>
        /// Provider Details in Provider-Ragini
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object UpdateDoctorDetails(string xml)
        {

         List<Result> objProviderDetails = objDalProvider.UpdateProviderDetails(xml);
            return objProviderDetails;
        }

        public object GetProviderDetails(string ProviderID)
        {
            List<Provider> objProviderDetails = objDalProvider.GetProviderDetails(Convert.ToInt32(ProviderID));
            return objProviderDetails;
        }
        
    }
}