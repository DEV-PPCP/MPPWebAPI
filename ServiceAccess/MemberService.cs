using PPCPWebApiServices.Models.PPCPWebService.DAL;
using PPCPWebApiServices.Models.PPCPWebService.DC;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace PPCPWebApiServices.ServiceAccess
{
    public class MemberService
    {
        DALMemberService objdal = new DALMemberService();
        public Object CreateObject(string XMLString, Object YourClassObject)
        {
            XmlSerializer oXmlSerializer = new XmlSerializer(YourClassObject.GetType());
            //The StringReader will be the stream holder for the existing XML file 
            YourClassObject = oXmlSerializer.Deserialize(new StringReader(XMLString));
            //initially deserialized, the data is represented by an object without a defined type 
            return YourClassObject;
        }

        /// <summary>
        /// SaveMemberSignUP- vinod on 31/07/2018
        /// </summary>
        /// <param name="organizationxml"></param>
        /// <returns></returns>
        public object SaveMemberSignUP(string organizationxml)
        {
            //DALMemberService objdal = new DALMemberService();
            if (!string.IsNullOrEmpty(organizationxml))
            {
                List<TemporaryMemberDetails> objTemporaryDetails = new List<TemporaryMemberDetails>();
                objTemporaryDetails = objdal.SaveMemberSignUP(organizationxml);
                return objTemporaryDetails;
            }
            return 0;
        }
        //public object SaveMemberDetails(string xml)
        //{
        //    DALMemberService objdal = new DALMemberService();
        //    List<Models.PPCPWebService.DC.TemporaryMemberDetails> getStates = objdal.SaveMemberDetails(xml);
        //    return getStates;
        //}

        public object ValidateUser(string Username, string Password, string IpAddress)
        {
            //DALMemberService objdal = new DALMemberService();
            List<Models.PPCPWebService.DC.MemberLoginDetails> lstMemberDetails = objdal.ValidateUser(Username, Password, IpAddress);
            return lstMemberDetails;
        }
        /// <summary>
        /// This web service is used for Add family member details
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object AddFamilyMemberDetails(string xml)
        {
            //DALMemberService objdal = new DALMemberService();
            List<Models.PPCPWebService.DC.TemporaryMemberDetails> getStates = objdal.AddFamilyMemberDetails(xml);
            return getStates;
        }
        /// <summary>
        /// Enrollpan details -vinod
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object EnrollPlanDetails(string xml)
        {
            //DALMemberService objdal = new DALMemberService();
            List<Models.PPCPWebService.DC.TemporaryMemberDetails> getStates = objdal.EnrollPlanDetails(xml);
            return getStates;
        }
        /// <summary>
        /// SaveMemberSignUP- vinod on 31/07/2018
        /// </summary>
        /// <param name="organizationxml"></param>
        /// <returns></returns>
        public object UpdateMemberPlanPayments(string Paymentsxml)
        {
            //DALMemberService objdal = new DALMemberService();
            if (!string.IsNullOrEmpty(Paymentsxml))
            {
                List<TemporaryMemberDetails> objTemporaryDetails = objdal.UpdateMemberPlanPayments(Paymentsxml);
                return objTemporaryDetails;
            }
            return 0;
        }
        /// <summary>
        /// Get particular member details based on MemberID-Vinod on 08/13/2019
        /// </summary>
        /// <param name="strMemberID"></param>
        /// <returns></returns>

        public object GetMemberDetails(string strMemberID)
        {
            //DALMemberService objdal = new DALMemberService();
            List<Member> objGetMemberDetails = new List<Member>();
            try
            {
                if (!string.IsNullOrEmpty(strMemberID))
                {
                    objGetMemberDetails = objdal.GetMemberDetails(Convert.ToInt32(strMemberID));
                }
            }
            catch (Exception Ex)
            {

            }
            return objGetMemberDetails;

        }
        /// <summary>
        /// Get Member Plan Details based on PlanID-vinod on 08/13/2019
        /// </summary>
        /// <param name="strMemberPlanID"></param>
        /// <returns></returns>
        public object GetMemberPlanDetails(string strMemberPlanCode)
        {
            //DALMemberService objdal = new DALMemberService();
            List<PPCPWebApiServices.Models.PPCPWebService.DC.MemberPlansDetails> objeGetMemberPlanDetails = new List<PPCPWebApiServices.Models.PPCPWebService.DC.MemberPlansDetails>();
            try
            {
                if (!string.IsNullOrEmpty(strMemberPlanCode))
                {
                    objeGetMemberPlanDetails = objdal.GetMemberPlanDetails(Convert.ToInt32(strMemberPlanCode));
                }

            }
            catch (Exception ex)
            {


            }
            return objeGetMemberPlanDetails;
        }
        /// <summary>
        /// Get Family details based on MemberParentID for Member Table-vinod-08/17/2019
        /// </summary>
        /// <param name="strParentID"></param>
        /// <returns></returns>
        public object GetFamilyDetails(string strMemberParentID)
        {
            List<Member> objGetFamilyDetails = new List<Member>();
            objGetFamilyDetails = objdal.GetFamilyDetails(Convert.ToInt32(strMemberParentID));
            return objGetFamilyDetails;
        }
        /// <summary>
        ///Get  Member Payment Details based on MemberParentID
        /// </summary>
        /// <param name="strMemberParentID"></param>
        /// <returns></returns>

        public object GetPaymentDetails(string strMemberParentID)
        {
            
            List<PaymentDetail> objGetPaymentDetails = new List<PaymentDetail>();
            objGetPaymentDetails = objdal.GetPaymentDetails(Convert.ToInt32(strMemberParentID));
            return objGetPaymentDetails;
        }
        /// <summary>
        /// Get Member Family Paln details based on MemberParentID-vinod-08/23/2019
        /// </summary>
        /// <param name="strMemberParentID"></param>
        /// <returns></returns>
        public object GetMemberFamilyPlanDetails(string strMemberParentID,string PlanType)
        {
          
            List<MemberPlan> objGetPaymentDetails = new List<MemberPlan>();
            objGetPaymentDetails = objdal.GetMemberFamilyPlanDetails(Convert.ToInt32(strMemberParentID), Convert.ToInt32(PlanType));
            return objGetPaymentDetails;
        }
        /// <summary>
        /// GetFamilyPlanMemberDetails- vinod
        /// </summary>
        /// <param name="MemberPlanID"></param>
        /// <returns></returns>

        public object GetFamilyPlanMemberDetails(string MemberPlanID)
        {
            List<MemberPlanMapping> objGetPaymentDetails = new List<MemberPlanMapping>();
            objGetPaymentDetails = objdal.GetFamilyPlanMemberDetails(Convert.ToInt32(MemberPlanID));
            return objGetPaymentDetails;

        }
        /// <summary>
        /// Member is exists or not in Member table-Vinod
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <param name="Gender"></param>
        /// <param name="DOB"></param>
        /// <param name="MobileNumber"></param>
        /// <returns></returns>
        public object CheckMemberExists(string FirstName, string LastName, string Gender, string DOB, string MobileNumber)
        {
            //DALMemberService objdal = new DALMemberService();
            // List<MemberPlan> objGetPaymentDetails = new List<MemberPlan>();
            int objGetPaymentDetails = objdal.CheckMemberExists(FirstName, LastName, Gender, Convert.ToDateTime(DOB), MobileNumber);
            return objGetPaymentDetails;
        }
        public object AddDoctorDetails(string xml)
        {
            //DALMemberService objdal = new DALMemberService();
            List<Models.PPCPWebService.DC.TemporaryMemberDetails> getStates = objdal.AddDoctorDetails(xml);
            return getStates;
        }
        /// <summary>
        /// This web service is used for get the Stripe card details based on customerID
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>

        public object GetStripCardDetails(string CustomerID)
        {
            //DALMemberService objdal = new DALMemberService();
            List<stripeCardDetails> getStripCardDetails = objdal.GetStripCardDetails(CustomerID);
            return getStripCardDetails;
        }   
        /// <summary>
        /// This web service used for get the payment details based on plan code from PaymentDetails,MemberPlans,Plans table
        /// </summary>
        /// <param name="strPlanCode"></param>
        /// <returns></returns>
        public object GetMemberPlanAndPaymentsDetails(string strPlanCode)        
        {
            object obj= objdal.GetMemberPlanAndPaymentsDetails(Convert.ToInt32(strPlanCode));
            return obj;

        }

        public object UpdateTermsandConditions(string MemberID)
        {
            List<Result> updateTermsAndConditions = objdal.UpdateTermsandConditions(Convert.ToInt32(MemberID));
            return updateTermsAndConditions;
        }

        public object UpdateFamilyMemberDetails(string xml)
        {
            List<Result> getStates = objdal.UpdateFamilyMemberDetails(xml);
            return getStates;
        }
        /// <summary>
        /// Get Member plan Installment detaila based on MemberPlanID by Vinod
        /// </summary>
        /// <param name="MemberPlanID"></param>
        /// <returns></returns>
        public object GetMemberPlanInstallments(string MemberPlanID)
        {
            List<PPCPWebApiServices.Models.PPCPWebService.DC.MemberPlanInstallmentMapping> objGetPaymentDetails = new List<PPCPWebApiServices.Models.PPCPWebService.DC.MemberPlanInstallmentMapping>();
            objGetPaymentDetails = objdal.GetMemberPlanInstallments(Convert.ToInt32(MemberPlanID));
            return objGetPaymentDetails;
        }
    }
}