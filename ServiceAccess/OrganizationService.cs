using PPCPWebApiServices.Models.PPCPWebService.DC;
using PPCPWebApiServices.Models.PPCPWebService.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static PPCPWebApiServices.Models.PPCPWebService.DC.DCProviderService;
using PPCPWebApiServices.CustomEntities;
using static Antlr.Runtime.Tree.TreeWizard;

namespace PPCPWebApiServices.ServiceAccess
{
    public class OrganizationService
    {
        DALOrganizationService objdal = new DALOrganizationService();
        public object OrganizationSignUp(string organizationxml)
        {
            List<Models.PPCPWebService.DC.OrganizationDetails> SaveOrganizationDetails = new List<Models.PPCPWebService.DC.OrganizationDetails>();
            try
            {

                SaveOrganizationDetails = objdal.SaveOrganizationDetails(organizationxml);

            }
            catch (Exception Ex)
            {

            }
            return SaveOrganizationDetails;
        }
        public object SavePlanDetailsXML(string plansxml)
        {

            List<Models.PPCPWebService.DC.OrganizationDetails> SaveOrganizationDetails = objdal.SaveOrganizationDetails(plansxml);
            return SaveOrganizationDetails;
        }
        //public object ValidateOrganization(string Username, string Password, string IpAddress)
        //{

        //    List<OrganizationUsers> ordDetails = objdal.ValidateOrganization(Username, Password, IpAddress);
        //    if (ordDetails.Count >= 1)
        //    {
        //        if (ordDetails[0].IsTwofactorAuthentication == true)
        //        {
        //            DALDefaultService dal = new DALDefaultService();

        //            string OTP = dal.randamNumber();
        //            string Message = "MyPhysicianPlan: DO NOT share this Sign In Code.  We will Never call you or text you for it.  Code " + OTP;
                    
        //            if (ordDetails[0].TwoFactorType == 1)
        //            {
        //                dal.SendMessageByText(Message, ordDetails[0].MobileNumber, ordDetails[0].CountryCode);
        //                ordDetails[0].Otp = OTP;
        //            }
        //            else
        //            {
        //                if (ordDetails[0].PreferredIP != IpAddress)
        //                {
        //                    dal.SendMessageByText(Message, ordDetails[0].MobileNumber, ordDetails[0].CountryCode);
        //                    ordDetails[0].Otp = OTP;
        //                }
        //                else
        //                {
        //                    // No Action Required
        //                }
        //            }
        //        }
        //        try
        //        {
        //            //Organization Terms and Conditions flag
        //            DALDefaultService objdal = new DALDefaultService();
        //            List<TermsAndCondition> objTermsAndConditionsOrganization = objdal.GetTermsAndConditions(2);//intType=2-Organization
        //            if (objTermsAndConditionsOrganization.Count >= 1)
        //            {
        //                int value = DateTime.Compare(Convert.ToDateTime(ordDetails[0].OrganizationTandC), Convert.ToDateTime(objTermsAndConditionsOrganization[0].CreatedDate));
        //                if (value > 0)
        //                    ordDetails[0].OrganizationTandCFlag = 0;
        //                else if (value < 0)
        //                    ordDetails[0].OrganizationTandCFlag = 1;
        //            }
        //            // Organization User Terms and Conditions flag
        //            List<TermsAndCondition> objTermsAndConditionsOrganizatioUsers = objdal.GetTermsAndConditions(3);//intType=2-Organization
        //            if (objTermsAndConditionsOrganizatioUsers.Count >= 1)
        //            {
        //                int value = DateTime.Compare(Convert.ToDateTime(ordDetails[0].OrganizationUserTandC), Convert.ToDateTime(objTermsAndConditionsOrganizatioUsers[0].CreatedDate));
        //                if (value > 0)
        //                    ordDetails[0].OrganizationUserTandCFlag = 0;
        //                else if (value < 0)
        //                    ordDetails[0].OrganizationUserTandCFlag = 1;
        //            }
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }

        //    return ordDetails;
        //}
        public object AddUserDetails(string organizationxml)
        {

            List<TemporaryUserDetails> SaveOrganizationDetails = objdal.AddUserDetails(organizationxml);
            return SaveOrganizationDetails;
        }
        /// <summary>
        /// ValidateUserName-by vinod(06/08/2018)
        /// </summary>
        /// <param name="UserName"></param>
        /// <returns></returns>
        public object ValidateUserName(string UserName)
        {
            if (!string.IsNullOrEmpty(UserName))
            {

                List<Models.PPCPWebService.DC.Result> ValidateUserName = objdal.ValidateUsername(UserName);

                return ValidateUserName;
            }
            return 0;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserID"></param>
        /// <param name="OrganizationID"></param>
        /// <returns></returns>
        public object GetOrganizationUsers(string UserID, string OrganizationID)
        {

            List<OrganizationUser> getusers = objdal.GetOrganizationUsers(Convert.ToInt32(UserID), Convert.ToInt32(OrganizationID));
            return getusers;
        }



        //public object UpdateOrgPassword(string UserID, string Password)
        //{

        //    int UpdatePassword = objdal.UpdateOrgCredentials(Convert.ToInt32(UserID), Password);
        //    return UpdatePassword;
        //}
        /// <summary>
        /// Update Organization details in Organization ,OrganizationUser and UserCredential table-vinod
        /// </summary>
        /// <param name="organizationxml"></param>
        /// <returns></returns>
        public object UpdateOrganizationDetails(string organizationxml)
        {

            List<Models.PPCPWebService.DC.OrganizationDetails> UpdateOrganizationDetails = objdal.UpdateOrganizationDetails(organizationxml);
            return UpdateOrganizationDetails;
        }

        public object ConvertOrganizationBillingType(string OrganizationId)
        {
            List<Models.PPCPWebService.DC.OrganizationDetails> UpdateOrganizationDetails = objdal.ConvertOrganizationBillingType(Convert.ToInt32(OrganizationId));
            return UpdateOrganizationDetails;
        }

        public object GetOrganizationUsersProfile(string OrganizationID)
        {

            List<OrganizationDetails> ValidateUserName = objdal.GetOrganizationUsersProfile(Convert.ToInt32(OrganizationID));
            return ValidateUserName;
        }
        /// <summary>
        /// Get SpecializationLKP-vinod
        /// </summary>
        /// <returns></returns>

        public object GetSpecializationLKP()
        {

            List<SpecializationLKP> UpdateOrganizationDetails = objdal.GetSpecializationLKP();
            return UpdateOrganizationDetails;
        }
        /// <summary>
        /// Add doctor details in provider,Provider Credential ,Provider Specialization table-vinod
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object AddDoctorDetails(string xml)
        {

            List<TemporaryUserDetails> SaveDoctorDetails = objdal.AddDoctorDetails(xml);
            return SaveDoctorDetails;

        }
        /// <summary>
        /// Add Member Details in Member,Member Credentials table-vinod
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object AddMemberDetails(string xml)
        {

            List<TemporaryUserDetails> addMemberDetails = objdal.AddMemberDetails(xml);
            return addMemberDetails;
        }
        /// <summary>
        /// Update member in Organization
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public object UpdateMemberDetails(string xml)
        {
            DALOrganizationService objdal = new DALOrganizationService();
            if (!string.IsNullOrEmpty(xml))
            {

                // List<TemporaryMemberDetails> objTemporaryDetails = new List<TemporaryMemberDetails>();
                List<Result> objTemporaryDetails = objdal.UpdateMemberDetails(xml);
                return objTemporaryDetails;
            }
            return 0;
        }
        /// <summary>
        /// Get Organization Based Member details -vinod
        /// </summary>
        /// <param name="OrganizationID"></param>
        /// <returns></returns>

        public object GetOrganizationMemberDetails(string OrganizationID, string strMemberID)
        {
            if (string.IsNullOrEmpty(OrganizationID)) OrganizationID = "0";
            if (string.IsNullOrEmpty(strMemberID)) strMemberID = "0";

            List<Member> GetMemberDetails = new List<Member>();

            GetMemberDetails = objdal.GetOrganizationMemberDetails(Convert.ToInt32(OrganizationID), Convert.ToInt32(strMemberID));

            return GetMemberDetails;

        }
        //veena
        public object GetOrganizationPlanDetails(string strOrganizationPlanCode)
        {
            DALOrganizationService objdal = new DALOrganizationService();
            List<PPCPWebApiServices.Models.PPCPWebService.DC.OrganizationPlanDetails> objeGetOrganizationPlanDetails = new List<PPCPWebApiServices.Models.PPCPWebService.DC.OrganizationPlanDetails>();
            try
            {
                if (!string.IsNullOrEmpty(strOrganizationPlanCode))
                {
                    objeGetOrganizationPlanDetails = objdal.GetOrganizationPlanDetails(Convert.ToInt32(strOrganizationPlanCode));
                }

            }
            catch (Exception ex)
            {


            }
            return objeGetOrganizationPlanDetails;
        }
        /// <summary>
        /// Validate Provider UserName -vinod
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>


        /// <summary>
        /// veena view OrganizationPaymentDetails using OrganizationID
        /// </summary>
        /// <param name="OrganizationID"></param>
        /// <returns></returns>
        public object GetOrganizationPaymentDetails(string OrganizationID, string Todate, string FromDate, string MemberID, string PaymentStatus, string PlanType)
        {
            DALOrganizationService objdal = new DALOrganizationService();

            List<MemberPlan> GetpaymentDetails = new List<MemberPlan>();
            try
            {
                string ToDate = "";
                try
                {
                    DateTime to_date = Convert.ToDateTime(Todate);
                    ToDate = Convert.ToString(to_date.AddDays(1).AddSeconds(-1));
                }
                catch(Exception e)
                {
                    GetpaymentDetails = objdal.GetOrganizationPaymentDetails(Convert.ToInt32(OrganizationID), Convert.ToDateTime(Todate), Convert.ToDateTime(FromDate), Convert.ToInt32(MemberID), PaymentStatus, Convert.ToInt32(PlanType));
                }
                GetpaymentDetails = objdal.GetOrganizationPaymentDetails(Convert.ToInt32(OrganizationID), Convert.ToDateTime(ToDate), Convert.ToDateTime(FromDate), Convert.ToInt32(MemberID), PaymentStatus, Convert.ToInt32(PlanType));

            }
            catch (Exception ex)
            {

            }
            return GetpaymentDetails;

        }

     

        public object InsertOrganizationPlans(string OrganizationID, string PlanID, string StartDate, string ModifiedBy)
        {
            int insertOrgPlans = objdal.InsertOrganizationPlan(Convert.ToInt32(OrganizationID), Convert.ToInt32(PlanID), Convert.ToDateTime(StartDate), Convert.ToInt32(ModifiedBy));
            return insertOrgPlans;
        }
        /// <summary>
        /// GetProviderDetails by veena
        /// Edited By Ragini on 30/10/2019 
        /// to get Details using provider table
        /// </summary>
        /// <param name="strOrganizationID"></param>
        /// <param name="strProviderID"></param>
        /// <returns></returns>
        public object GetProviderDetails(string strOrganizationID, string strProviderID)
        {

            object GetProviderDetails = new List<ProviderDetails>();

            GetProviderDetails = objdal.GetOrganizationProviderDetails(Convert.ToInt32(strOrganizationID), Convert.ToInt32(strProviderID));

            return GetProviderDetails;

        }
        /// <summary>
        /// Get Organization details-vinod
        /// </summary>
        /// <param name="strOrganizationID"></param>
        /// <returns></returns>
        public object GetOrganizationDetails(string strOrganizationID)
        {
            List<Organization> getOrganizationDetails = new List<Organization>();
            getOrganizationDetails = objdal.GetOrganizationDetails(Convert.ToInt32(strOrganizationID));
            return getOrganizationDetails;
        }

        public object GetOrganizationPlans(string strOrganizationID, string strType)
        {
            List<PlansAndPlansMapping> getOrganizationPlans = new List<PlansAndPlansMapping>();
            getOrganizationPlans = objdal.GetOrganizationPlans(Convert.ToInt32(strOrganizationID), Convert.ToInt32(strType));

            return getOrganizationPlans;
        }
        public object GetOrganizationProviderPlans(string strOrganizationID, string strProviderID, string strType)
        {
            List<PlansAndPlansMapping> getOrganizationPlans = new List<PlansAndPlansMapping>();
            getOrganizationPlans = objdal.GetOrganizationProviderPlans(Convert.ToInt32(strOrganizationID), Convert.ToInt32(strProviderID), Convert.ToInt32(strType));

            return getOrganizationPlans;
        }

        public object InsertOrganizationProviderPlans(string OrganizationID, string PlanID, string StartDate, string ProviderID, string OrganizationName, string PlanName, string ProviderName)
        {
            List<Result> obj = objdal.InsertOrganizationProviderPlans(Convert.ToInt32(OrganizationID), Convert.ToInt32(PlanID), Convert.ToDateTime(StartDate), Convert.ToInt32(ProviderID), OrganizationName, PlanName, ProviderName);
            return obj;

        }
        /// <summary>
        /// Calling Webmethod From Organization Module to update provider details By Ragini
        /// </summary>
        /// <param name="OrgProviderDetails"></param>
        /// <returns></returns>
        public object UpdateOrganizationProviderDetails(string OrgProviderDetails)
        {
            List<Result> objOrgProvider = objdal.UpdateOrganizationProviderDetails(OrgProviderDetails);
            return objOrgProvider;

        }
        public object UpdateUserDetails(string xml)
        {
            List<Result> objUserDetails = new List<Result>();
            if (!string.IsNullOrEmpty(xml))
            {
                objUserDetails = objdal.UpdateUserDetails(xml);
                return objUserDetails;
            }
            return objUserDetails;
        }

        public object GetOrganizationMembersAutoComplete(string OrganizationID, string Text)
        {
            object memberDetails = objdal.GetOrganizationMembersAutoComplete(Convert.ToInt32(OrganizationID), Text);
            return memberDetails;
        }
        /// <summary>
        /// Search Provider Details in Organizaton Module -- By Ragini 
        /// </summary>
        /// <param name="OrganizationID"></param>
        /// <param name="Text"></param>
        /// <returns></returns>
        public object GetProviderDetailsAutoComplete(string OrganizationID, string Text)
        {
            object providerDetails = objdal.GetProviderDetailAutoComplete(Convert.ToInt32(OrganizationID), Text);
            return providerDetails;
        }

        public object UpdateTermsandConditions(string OrganizationID, string UserID, string OrgType, string OrgUserType)
        {
            List<Result> updateTermsAndConditions = objdal.UpdateTermsandConditions(Convert.ToInt32(OrganizationID), Convert.ToInt32(UserID), Convert.ToInt32(OrgType), Convert.ToInt32(OrgUserType));
            return updateTermsAndConditions;
        }

        public object GetMemberPendingEnrollment(string OrganizationID)
        {
            List<Member> updateTermsAndConditions = objdal.GetMemberPendingEnrollment(Convert.ToInt32(OrganizationID));
            return updateTermsAndConditions;
        }

        public object UnSubscribePlanDetails(string OrganizationID, string PlanID,string MapID)
        {
             List<Result> UnSubscribePlanDetailsList = objdal.UnSubscribePlanDetails(Convert.ToInt32(OrganizationID), Convert.ToInt32(PlanID), Convert.ToInt32(MapID));
              return UnSubscribePlanDetailsList;
        }

        public object UnSubscribedProviderPlan(string OrganizationID, string ProviderID,string MapID)//, string PlanID
        {
             List<Result> UnSubscribePlanDetailsList = objdal.UnSubscribedProviderPlan(Convert.ToInt32(OrganizationID), Convert.ToInt32(ProviderID), Convert.ToInt32(MapID));
              return UnSubscribePlanDetailsList;
        }

        /// <summary>
        /// GetReports data by Anusha
        /// 
        /// to get Details using provider table
        /// </summary>
        /// <param name="strOrganizationID"></param>
        /// <param name="strProviderID"></param>
        /// <returns></returns>
        public object GetPPCPReports(string FromDate, string ToDate, string ProviderID, string PaymentStatus, string PlanType, string OrganziationID,string Type)
        {

            object GetDetails = new List<PPCPReports>();

            GetDetails = objdal.GetPPCPReports(Convert.ToDateTime(FromDate), Convert.ToDateTime(ToDate), Convert.ToInt32(ProviderID), PaymentStatus,PlanType, Convert.ToInt32(OrganziationID), Convert.ToInt32(Type));

            return GetDetails;

        }


        public object GetTransactionsToPractice(string OrganizationID, string Todate, string FromDate)
        {
            DALOrganizationService objdal = new DALOrganizationService();

            List<TransactionstoPractice> GetpaymentDetails = new List<TransactionstoPractice>();
            try
            {
                string ToDate = "";
                try
                {
                    DateTime to_date = Convert.ToDateTime(Todate);
                    ToDate = Convert.ToString(to_date.AddDays(1).AddSeconds(-1));
                }
                catch (Exception e)
                {
                    GetpaymentDetails = objdal.GetTransactionsToPractice(Convert.ToInt32(OrganizationID), Convert.ToDateTime(Todate), Convert.ToDateTime(FromDate));
                }
                GetpaymentDetails = objdal.GetTransactionsToPractice(Convert.ToInt32(OrganizationID), Convert.ToDateTime(ToDate), Convert.ToDateTime(FromDate));

            }
            catch (Exception ex)
            {

            }
            return GetpaymentDetails;

        }
        public object GetMembersList(string OrganizationID, string strMemberID, string searchtext)
        {
            int memberid = 0;
            if (!string.IsNullOrEmpty(strMemberID))
                 memberid = Convert.ToInt32(strMemberID);
            int orgid = 0;
            if (!string.IsNullOrEmpty(OrganizationID))
                orgid = Convert.ToInt32(OrganizationID);

            object GetDetails = new List<MembersList>();

            GetDetails = objdal.GetMembersList(orgid, memberid, searchtext);

            return GetDetails;

        }
        /// <summary>
        /// AdminPlans in Admin Module
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetPlans(string PlanId)
        {
            List<Plan> getPlans = new List<Plan>();
            int PlanID= Convert.ToInt32(PlanId);
            try
            {
                using (var context = new Dev_PPCPEntities(1))
                {
                    getPlans = context.Plans.Where(a => a.IsActive == true && a.IsDelete == true && a.PlanID== PlanID).OrderByDescending(a => a.PlanID).ToList();
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetPlans: PlanId: " + PlanId, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }

            return getPlans;
        }

        public object GetPPVMembersList(string OrganizationID, string strMemberID, string searchtext)
        {
            int memberid = 0;
            if (!string.IsNullOrEmpty(strMemberID))
                memberid = Convert.ToInt32(strMemberID);
            int orgid = 0;
            if (!string.IsNullOrEmpty(OrganizationID))
                orgid = Convert.ToInt32(OrganizationID);

            object GetDetails = new List<MembersList>();

            GetDetails = objdal.GetMembersList(orgid, memberid, searchtext, true);

            return GetDetails;

        }



        #region Billing

        public object GetClaims(string OrganizationID, string ClaimStartDate, string ClaimEndDate, string ClaimStatus)
        {
            int orgid = 0;
            if (!string.IsNullOrEmpty(OrganizationID))
                orgid = Convert.ToInt32(OrganizationID);
            int claimStatus = 0;
            if (!string.IsNullOrEmpty(ClaimStatus))
                claimStatus = Convert.ToInt32(ClaimStatus);

            object list = new List<MemberVisit>();

            list = objdal.GetClaims(orgid, Convert.ToDateTime(ClaimStartDate), Convert.ToDateTime(ClaimEndDate), Convert.ToInt32(claimStatus));

            return list;

        }

        public object GetVisitById(string VisitId)
        {
            int visitId = 0;
            if (!string.IsNullOrEmpty(VisitId))
                visitId = Convert.ToInt32(VisitId);

            object list = new List<MemberVisit>();
            list = objdal.GetVisitById(visitId);

            return list;
        }

        public object SaveClaim(string xml)
        {
            DALOrganizationService objdal = new DALOrganizationService();
            if (!string.IsNullOrEmpty(xml))
            {

                // List<TemporaryMemberDetails> objTemporaryDetails = new List<TemporaryMemberDetails>();
                List<MemberVisit> objTemporaryDetails = objdal.SaveClaim(xml);
                return objTemporaryDetails;
            }
            return 0;
        }

        public object ClaimConfirm(string VisitId)
        {
            Result res = objdal.ClaimMemberResponse(Convert.ToInt32(VisitId), "Confirm");
            List<Result> result = new List<Result>();
            result.Add(res);
            return result;
        }
        public object ClaimDeny(string VisitId)
        {
            Result res = objdal.ClaimMemberResponse(Convert.ToInt32(VisitId), "Deny");
            List<Result> result = new List<Result>();
            result.Add(res);
            return result;
        }

        public object ClaimDelete(string VisitId)
        {
            Result res = objdal.ClaimDelete(Convert.ToInt32(VisitId));
            List<Result> result = new List<Result>();
            result.Add(res);
            return result;
        }

        public object ResendClaimConfirmText(string VisitId)
        {
            object res = new Result();
            res = objdal.ResendClaimConfirmText(Convert.ToInt32(VisitId));
            return res;
        }

        public object ResendClaimConfirmEmail(string VisitId)
        {
            object res = new Result();
            res = objdal.ResendClaimConfirmEmail(Convert.ToInt32(VisitId));
            return res;
        }

        public object AdminClaimApproval(string VisitId, string AdminNotes, string ModifiedBy)
        {
            object res = new Result();
            res = objdal.AdminClaimApproval(Convert.ToInt32(VisitId), AdminNotes, Convert.ToInt32(ModifiedBy));
            return res;
        }

        #endregion

    }

}