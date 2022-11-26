using IPHGlobal;
using Newtonsoft.Json;
using PPCPWebApiServices.Controllers;
using PPCPWebApiServices.Models.PPCPWebService.DC;
using PPCPWebApiServices.Models.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Configuration;
using System.Data;
using Dapper;
using PPCPWebApiServices.CustomEntities;
using System.Web.UI.WebControls;
using System.Net.PeerToPeer;
using System.Net;
using Twilio.TwiML.Voice;
using Microsoft.Ajax.Utilities;
using System.Web.Mvc;

namespace PPCPWebApiServices.Models.PPCPWebService.DAL
{
    
    public class DALDefaultService : DbContext
    {
       

        #region Account Management
        public List<UserProfile> ValidateCredentials(string Username, string Password, string Ipaddress)
        {
            List<UserProfile> usrDetails = new List<UserProfile>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    usrDetails = conn.Query<UserProfile>("pr_UserValidate", new { Username, Password, Ipaddress }, commandType: CommandType.StoredProcedure).ToList();                    
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ValidateCredentials", ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
                return null;
            }
            return usrDetails;
        }

        public List<Credentials> ValidateForgotCredentials(string UserName, string FirstName, string LastName, string CountryCode, string MobileNumber, string Email)
        {
            List<Credentials> result;
            using (var context = new DALDefaultService())
            {
                SqlParameter pUserName = new SqlParameter("@UserName", UserName);
                SqlParameter pFirstName = new SqlParameter("@FirstName", FirstName);
                SqlParameter pLastName = new SqlParameter("@LastName", LastName);
                SqlParameter pCountryCode = new SqlParameter("@CountryCode", CountryCode);
                SqlParameter pMobileNumber = new SqlParameter("@MobileNumber", MobileNumber);
                SqlParameter pEmail = new SqlParameter("@Email", Email);

                result = context.Database.SqlQuery<Credentials>("Pr_ValidateForgotCredentials @UserName, @FirstName,@LastName,@CountryCode,@MobileNumber,@Email",
                    pUserName, pFirstName, pLastName, pCountryCode, pMobileNumber, pEmail).ToList();
            }
            if (result.Count > 0)
            {
                string OTP = randamNumber();
                string Message = "OTP: " + OTP;
                result[0].OTP = OTP;
                SendMessageByText(Message, result[0].MobileNumber, result[0].CountryCode);
                ForgotCredentials(Message, result[0].Email, "OTP");
            }

            return result;
        }

        public int SendCredentials(string FirstName, string LastName, string CountryCode, string MobileNumber, string Email, string UserName, string Password, string TempID)
        {
            // byte[] bytes = Decoder.UTF8.GetBytes(Password);
            string password = decode(Password);//HttpUtility.HtmlDecode(Password);
                                               // password = Convert.ToBase64String(bytes);
            string Message = "";
            if (TempID.Equals("1"))
            {
                Message = "Dear " + FirstName + " " + LastName + " your Password is : " + password;
            }
            else
            {
                Message = "Dear " + FirstName + " " + LastName + " your UserName is : " + UserName;
            }

            SendMessageByText(Message, MobileNumber, CountryCode);
            ForgotCredentials(Message, Email, "Credentials");
            return 1;

        }
        public static string decode(string text)
        {
            byte[] mybyte = System.Convert.FromBase64String(text);
            string returntext = System.Text.Encoding.UTF8.GetString(mybyte);
            return returntext;
        }

        private void ForgotCredentials(string Message, string Email, string Heading)
        {
            try
            {
                string body = ReadFile(VirtualPathUtility.MakeRelative(VirtualPathUtility.ToAppRelative(HttpContext.Current.Request.CurrentExecutionFilePath), "~/Resource/EmailTemplates/SendOTPToUser.htm"));

                //string sub = message + " " + "Payment Receipt";
                string sub = "Forgot Credentials";
                body = body.Replace("##Date##", DateTime.UtcNow.ToShortDateString());
                body = body.Replace("##Heading##", Heading);
                body = body.Replace("##Message##", Message);

                SendEmail(sub, Email, body, "");
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ForgotCredentials", ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
        }

        public List<Result> ValidateUsername(string Username)
        {
            List<Result> IsActive;
            using (var context = new DALDefaultService())
            {
                SqlParameter UserName = new SqlParameter("@UserName", Username);
                //IsActive = context.Database.SqlQuery<Result>("Pr_ValidateMemberUserName @UserName", UserName).ToList();
                IsActive = context.Database.SqlQuery<Result>("[Pr_ValidateUserName] @UserName", UserName).ToList();
            }
            return IsActive;
        }

        #endregion

        public List<LookupValue> GetLookupValues(int LookupTypeId)
        {
            List<LookupValue> list = new List<LookupValue>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    list = conn.Query<LookupValue>("select * from lookupValues where lookuptypeid = " + LookupTypeId, null, commandType: CommandType.Text).ToList();
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetLookupValues: " + LookupTypeId, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
                return null;
            }
            return list;
        }

        public List<Models.PPCPWebService.DC.CountriesLKP> GetCountries()
        {

            List<Models.PPCPWebService.DC.CountriesLKP> getcountries=new List<Models.PPCPWebService.DC.CountriesLKP>();
            try
            {
                using (var context = new DALDefaultService())
                {
                    getcountries = context.Database.SqlQuery<Models.PPCPWebService.DC.CountriesLKP>("Pr_GetCountries").ToList();
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetCountries", ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return getcountries;
        }

        public List<Models.PPCPWebService.DC.StatesLKP> GetStates(int CountryId)
        {
            List<Models.PPCPWebService.DC.StatesLKP> getstates;
            using (var context = new DALDefaultService())
            {
                SqlParameter CountyID = new SqlParameter("@CountyID", CountryId);
                getstates = context.Database.SqlQuery<Models.PPCPWebService.DC.StatesLKP>("Pr_GetStates @CountyID", CountyID).ToList();

            }
            return getstates;
        }
        public List<Models.PPCPWebService.DC.CitiesLKP> GetCities(int StateId)
        {
            List<Models.PPCPWebService.DC.CitiesLKP> getcities;
            using (var context = new DALDefaultService())
            {
                SqlParameter StateID = new SqlParameter("@StateID", StateId);
                getcities = context.Database.SqlQuery<Models.PPCPWebService.DC.CitiesLKP>("Pr_GetCities @StateID", StateID).ToList();
            }
            return getcities;
        }

        public List<PPCPOrganizations> GetOrganizations()
        {
            List<PPCPOrganizations> getOrganizations;
            using (var context = new DALDefaultService())
            {
                getOrganizations = context.Database.SqlQuery<PPCPOrganizations>("Pr_GetOrganizations").ToList();
            }
            return getOrganizations;
        }

        public List<PPCPOrganizations> GetPPCPSpecificOrganization(int OrganizationId)
        {
            List<PPCPOrganizations> getOrganizations;
            using (var context = new DALDefaultService())
            {
                SqlParameter OrganizationID = new SqlParameter("@OrganizationID", OrganizationId);
                getOrganizations = context.Database.SqlQuery<PPCPOrganizations>("Pr_GetOrganizations @OrganizationID", OrganizationID).ToList();
            }
            return getOrganizations;
        }        

        public List<PPCPOrganizationProviders> GetPPCPOrganizationProviders(int OrganizationId)
        {
            List<PPCPOrganizationProviders> getOrganizationProviders;
            using (var context = new DALDefaultService())
            {
                SqlParameter OrganizationID = new SqlParameter("@OrganizationID", OrganizationId);
                getOrganizationProviders = context.Database.SqlQuery<PPCPOrganizationProviders>("Pr_GetProviders @OrganizationID", OrganizationID).ToList();
            }
            return getOrganizationProviders;
        }
        public List<PPCPOrganizationProviders> GetPPCPProviders(int OrganizationId)
        {
            List<PPCPOrganizationProviders> getOrganizationProviders;
            using (var context = new DALDefaultService())
            {
                SqlParameter OrganizationID = new SqlParameter("@OrganizationID", OrganizationId);
                getOrganizationProviders = context.Database.SqlQuery<PPCPOrganizationProviders>("Pr_GetPPCPProviders @OrganizationID", OrganizationID).ToList();
            }
            return getOrganizationProviders;
        }

        public List<PlansAndPlansMapping> GetPPCPOrganizationProviderPlans(int OrganizationId, int ProviderId, int PlanId, string Memberage, string Membergender, int Plantype)
        {
            List<PlansAndPlansMapping> list = new List<PlansAndPlansMapping>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    list = conn.Query<PlansAndPlansMapping>("Pr_GetPlans", new { OrganizationId, ProviderId, PlanId, Memberage, Membergender, Plantype }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetPPCPOrganizationProviderPlans: OrganizationId: " + OrganizationId + ": ProviderId: " + ProviderId, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
                return null;
            }
            return list;
        }

        public List<MemberPlans> GetPlanDetails(int PlanId, int MemberId, int OrganizationId, int ProviderId)
        {
            List<MemberPlans> getPlans;

            using (var context = new DALDefaultService())
            {
                SqlParameter PlanID = new SqlParameter("@PlanID", PlanId);
                SqlParameter MemberID = new SqlParameter("@MemberID", MemberId);
                SqlParameter OrganizationID = new SqlParameter("@OrganizationID", OrganizationId);
                SqlParameter ProviderID = new SqlParameter("@ProviderID", ProviderId);
                getPlans = context.Database.SqlQuery<MemberPlans>("Pr_GetPlaneDetails @PlanID,@MemberID,@OrganizationId,@ProviderID", PlanID, MemberID, OrganizationID, ProviderID).ToList();
            }

            return getPlans;
        }

        public List<MemberPlans> GetMemberPlansAndPaymentDetails(int PlanId, int MemberId, int OrganizationId)
        {
            List<MemberPlans> getPlans;

            using (var context = new DALDefaultService())
            {
                SqlParameter PlanID = new SqlParameter("@PlanId", PlanId);
                SqlParameter MemberID = new SqlParameter("@MemberId", MemberId);
                SqlParameter OrganizationID = new SqlParameter("@OrganizationId", OrganizationId);
                getPlans = context.Database.SqlQuery<MemberPlans>("Pr_GetMemberPlansAndPaymentDetails @PlanId, @MemberId, @OrganizationId", PlanID, MemberID, OrganizationID).ToList();
            }

            return getPlans;
        }

        
        private void SendEmail(string message, string ProviderEmail, string body, string CcEmail)
        {
            try
            {
                List<Application_Parameter_Config> list = GetApplicationParameterConfig();
                string FromMail = list[4].PARAMETER_VALUE; ;
                string Password = list[5].PARAMETER_VALUE; ;
                Service.MailHelper _objMail = new Service.MailHelper();
                _objMail.SmtpMail(ProviderEmail, CcEmail, message, body, FromMail, Password);
            }
            catch (Exception ex)
            {
                Logging.LogMessage("SendEmail: ProviderEmail: " + ProviderEmail, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
        }
        public static string ReadFile(string fileName)
        {
            try
            {
                String filename = HttpContext.Current.Server.MapPath(fileName);
                StreamReader objStreamReader = System.IO.File.OpenText(filename);
                String contents = objStreamReader.ReadToEnd();
                return contents;
            }
            catch (Exception)
            {
            }
            return "";
        }
        
        public List<Result> validateChangePassword(int UserId, string password, int TypeId)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(password);
            password = Convert.ToBase64String(bytes);//Convert the password to Encrypt
            List<Result> changePassword;
            using (var context = new DALDefaultService())
            {
                SqlParameter UserID = new SqlParameter("@UserID", UserId);
                SqlParameter Password = new SqlParameter("@Password", password);
                SqlParameter TypeID = new SqlParameter("@TypeID", TypeId);
                changePassword = context.Database.SqlQuery<Result>("Pr_validateChangePassword @UserID,@Password,@TypeID", UserID, Password, TypeID).ToList();
            }
            return changePassword;
        }


        public void SendMessageByText(string message, string MobileNo, string CountryCode)
        {
            List<string> MessageInfo = new List<string>();
            try
            {
                List<Application_Parameter_Config> getApplication_Parameter_Config = GetApplicationParameterConfig();

                string PhoneNumber = "";
                string AccountSid = getApplication_Parameter_Config[0].PARAMETER_VALUE.Trim(); //"ACee0fa31137b3bb48086716289755b6ce"; //getApplication_Parameter_Config[0].PARAMETER_VALUE;// "ACee0fa31137b3bb48086716289755b6ce";
                string AuthToken = getApplication_Parameter_Config[1].PARAMETER_VALUE.Trim(); //"b2647dabc45ab06f9157d696667ee9bb"; //list[1].PARAMETER_VALUE;//"b2647dabc45ab06f9157d696667ee9bb";
                string FromPhone = getApplication_Parameter_Config[2].PARAMETER_VALUE.Trim(); //"+17322534561";//list[2].PARAMETER_VALUE;//"+17322534561";               
                string MessagingServiceSid= getApplication_Parameter_Config[8].PARAMETER_VALUE.Trim();
                if (string.IsNullOrEmpty(CountryCode))
                {
                    CountryCode = getApplication_Parameter_Config[3].PARAMETER_VALUE;// list[3].PARAMETER_VALUE;
                }
                if (MobileNo != "")
                {
                    PhoneNumber = MobileNo;

                }

                string mobile = "+" + CountryCode + PhoneNumber;

                string K = "";

                MessageInfo = SMS.SendMessage(FromPhone, AccountSid, AuthToken, mobile, message, MessagingServiceSid);




                //if (K.Substring(0, 1) == "1")
                //{
                //    // Result = "1";//if want show popupsuecessfully messaage based text sucess we can these things
                //}
                //else
                //{
                //    // Result = "0";//if want show popupsuecessfully messaage based text sucess we can these things
                //}
            }
            catch (Exception ex)
            {
                Logging.LogMessage("SendMessageByText: MobileNo: " + MobileNo, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
        }

        private void SendMessageByEmail(string message, string ProviderEmail, string body)
        {
            List<string> MessageInfo = new List<string>();
            try
            {
                List<Application_Parameter_Config> list = GetApplicationParameterConfig();//Table name-Application_Parameter_Config
                string FromMail = list[6].PARAMETER_VALUE; ;
                string Password = list[7].PARAMETER_VALUE; ;

                PPCPWebApiServices.Models.Service.MailHelper _objMail = new PPCPWebApiServices.Models.Service.MailHelper();
                _objMail.SmtpMail(ProviderEmail, "", message, body, FromMail, Password);

            }
            catch (Exception ex)
            {
                Logging.LogMessage("SendMessageByEmail: ProviderEmail: " + ProviderEmail, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
        }

        public string randamNumber()
        {
            RandomTextGenerator random = new RandomTextGenerator();
            random.ConsecutiveCharacters = false;
            random.ExcludeSymbols = false;
            random.Exclusions = null;
            random.Maximum = 5;
            random.Minimum = 5;
            random.pwdCharArray = "123456789".ToCharArray();
            random.RepeatCharacters = false;
            string number = random.Generate();
            return number;
        }
        public List<PaymentDetails> GetPaymentDetails(int MemberId)
        {
            List<PaymentDetails> getpaymentdetails;
            using (var context = new DALDefaultService())
            {
                SqlParameter MemberID = new SqlParameter("@MemberID", MemberId);
                getpaymentdetails = context.Database.SqlQuery<PaymentDetails>("Pr_GetPaymentDetails @MemberID", MemberID).ToList();

            }
            return getpaymentdetails;
        }

        public List<RelationShip> GetRelationShipDetails()
        {
            List<RelationShip> getRelationShipDetails;
            using (var context = new DALDefaultService())
            {
                getRelationShipDetails = context.Database.SqlQuery<RelationShip>("Pr_GetRelationshipLKP").ToList();
            }
            return getRelationShipDetails;
        }

        public List<Application_Parameter_Config> GetApplicationParameterConfig()
        {
            List<Application_Parameter_Config> getApplicationParameterConfig = new List<Application_Parameter_Config>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                   
                    getApplicationParameterConfig = Context.Application_Parameter_Config.ToList();

                }
            }
            catch (Exception ex)
            {

            }
            return getApplicationParameterConfig;

        }

        /// <summary>
        /// WithdrawPlans in Admin Module - Ragini
        /// </summary>
        /// <returns></returns>
        public List<Plan> GetPlans(string type)
        {
            List<Plan> getPlans = new List<Plan>();
            int Type = Convert.ToInt32(type);
            try
            {
                using (var context = new Dev_PPCPEntities(1))
                {
                    if (Type == 1)
                    {
                        getPlans = context.Plans.Where(a => a.IsActive == true && a.IsDelete == false).OrderByDescending(a => a.PlanID).ToList();
                    }
                    else if (Type == 2)
                    {
                        getPlans = context.Plans.Where(a => a.IsActive == true && a.IsDelete == true).OrderByDescending(a => a.PlanID).ToList();

                    }
                    else
                    {
                        getPlans = context.Plans.OrderByDescending(a => a.PlanID).ToList();

                    }
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetPlans: type: " + type, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }

            return getPlans;
        }

        public List<Result> AddPlans(string xml)
        {
            List<Result> objResult = new List<Result>();
            try
            {
                using (var context = new DALDefaultService())
                {
                    SqlParameter XML = new SqlParameter("@XML", xml);
                    objResult = context.Database.SqlQuery<Result>("Pr_AddPlans @XML", XML).ToList();

                }
            }
            catch (Exception ex)
            {
                Result obj = new Result();
                obj.ResultName = ex.Message;
                objResult.Add(obj);
                Logging.LogMessage("AddPlans", ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return objResult;
        }

        public int ValidatePlanName(string strPlanName)
        {
            int result = 0;
            using (var Context = new Dev_PPCPEntities(1))
            {
                result = Context.Plans.Count(P => P.PlanName == strPlanName && P.IsDelete == false);
            }
            return result;
        }

        public List<Result> SavePlanMapping(string OrganizationName, int OrganizationID, string ProviderName, int ProviderID, string PlanName, int PlanID)
        {
            List<Result> res = new List<Result>();
            Result resobj = new Result();
            try
            {

                using (var Context = new Dev_PPCPEntities(1))
                {

                    int result = Context.PlansMappings.Count(P => P.OrganizationID == OrganizationID
                                                                && P.Organizationname == OrganizationName
                                                                && P.PlanName == PlanName
                                                                && P.PlanID == PlanID
                                                                && P.ProviderID == ProviderID
                                                                && P.ProviderName == ProviderName);

                    if (result == 0)
                    {
                        PlansMapping objPlansMapping = new PlansMapping();
                        objPlansMapping.Organizationname = OrganizationName;
                        objPlansMapping.OrganizationID = OrganizationID;
                        objPlansMapping.ProviderName = ProviderName;
                        objPlansMapping.ProviderID = ProviderID;
                        objPlansMapping.PlanName = PlanName;
                        objPlansMapping.PlanID = PlanID;
                        Context.PlansMappings.Add(objPlansMapping);
                        Context.SaveChanges();
                        int id = objPlansMapping.PlanMapID;
                        resobj.ResultID = id;
                        res.Add(resobj);
                    }
                    else
                    {
                        resobj.ResultID = -1;
                        resobj.ResultName = "Already exsists";
                        res.Add(resobj);
                    }

                }
            }
            catch (Exception ex)
            {
                resobj.ResultName = ex.Message;
                res.Add(resobj);
                Logging.LogMessage("SavePlanMapping: OrganizationID: " + OrganizationID, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return res;
        }



        public List<Result> WithdrawPlans(int PlanID, DateTime UnsubscribeDate)
        {
            List<Result> objResult = new List<Result>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    PPCPWebApiServices.Plan h = Context.Plans.FirstOrDefault(m => m.PlanID == PlanID);
                    h.IsDelete = true;
                    h.UnSubscribedDate = UnsubscribeDate;
                    int Result = Context.SaveChanges();
                    Result res = new Result();
                    res.ResultID = Result;
                    objResult.Add(res);
                }

            }
            catch (Exception ex)
            {
                Result obj = new Result();
                obj.ResultName = ex.Message;
                objResult.Add(obj);
            }
            return objResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Todate"></param>
        /// <param name="FromDate"></param>

        /// <returns></returns>
        public List<MemberPlan> GetAdminPaymentDetails(DateTime dateToDate, DateTime dateFromDate, int intOrganizationID, int intProviderID, int intPlanID)
        {
            List<MemberPlan> getAdminPaymentDetails = new List<MemberPlan>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    string strtemp = " ";
                    if (intOrganizationID != 0)
                    {
                        strtemp = "1";
                    }
                    if (intProviderID != 0)
                    {
                        strtemp = strtemp + "2";
                    }
                    if (intPlanID != 0)
                    {
                        strtemp = strtemp + "3";
                    }
                    switch (strtemp)
                    {
                        case " ":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate).ToList();
                            break;
                        case "1":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.OrganizationID == intOrganizationID).ToList();
                            break;
                        case "2":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.ProviderID == intProviderID).ToList();
                            break;
                        case "3":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.PlanID == intPlanID).ToList();
                            break;
                        case "12":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.OrganizationID == intOrganizationID && m.ProviderID == intProviderID).ToList();
                            break;
                        case "13":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.OrganizationID == intOrganizationID && m.PlanID == intPlanID).ToList();
                            break;
                        case "23":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.ProviderID == intProviderID && m.PlanID == intPlanID).ToList();
                            break;
                        case "123":
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.OrganizationID == intOrganizationID && m.ProviderID == intProviderID && m.PlanID == intPlanID).ToList();
                            break;
                        default:
                            getAdminPaymentDetails = Context.MemberPlans.Where(m => m.CreatedDate <= dateToDate && m.CreatedDate >= dateFromDate && m.OrganizationID == intOrganizationID).ToList();
                            break;
                    }
                    if (getAdminPaymentDetails.Count > 0)
                    {


                        Decimal lengthSum = Convert.ToDecimal(getAdminPaymentDetails.Select(x => x.TotalAmount).Sum());
                        getAdminPaymentDetails[0].GrandTotalAmount = lengthSum;
                        Decimal GrandAmountPaid = Convert.ToDecimal(getAdminPaymentDetails.Select(x => x.AmountPaid).Sum());
                        getAdminPaymentDetails[0].GrandAmountPaid = GrandAmountPaid;
                        //public Nullable<decimal> GrandTotalAmount { get; set; }  public Nullable<decimal> GrandAmountPaid { get; set; }
                       
                    }

                }
            }

            catch (Exception ex)
            {

            }


            return getAdminPaymentDetails;

        }
        public object GetOrganizationAutoComplete(string Text)
        {
            using (var Context = new Dev_PPCPEntities(1))
            {
                var dataset = Context.Organizations
               .Where(x => x.OrganizationName.Contains(Text))
               .Select(x => new
               {
                   OrganizationName = x.OrganizationName,
                   OrganizationID = x.OrganizationID,

               }).ToList();
                return dataset;
            }
        }

        public List<MemberPlan> GetMemberPlansDetails(DateTime FromDate, DateTime ToDate, int MemberID)
        {
            List<MemberPlan> MemberPlanDetails = new List<MemberPlan>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    if (MemberID == 0)
                    {

                        MemberPlanDetails = Context.MemberPlans.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).OrderByDescending(x => x.CreatedDate).ToList();
                    }
                    else
                    {
                        MemberPlanDetails = Context.MemberPlans.Where(x => x.MemberID == MemberID).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetMemberPlansDetails: MemberID: " + MemberID, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return MemberPlanDetails;
        }

        public object GetOrganizationPlanDetails(DateTime FromDate, DateTime ToDate, int OrganizationID)
        {

            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    if (OrganizationID == 0)
                    {
                        // OrganizationPlanDetails = Context.OrganizationPlans.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).ToList();

                        var entryPoint = (from OP in Context.OrganizationPlans
                                          join P in Context.Plans on OP.PlanID equals P.PlanID
                                          join O in Context.Organizations on OP.OrganizationID equals O.OrganizationID
                                          where OP.CreatedDate >= FromDate && OP.CreatedDate <= ToDate
                                          select new
                                          {
                                              PlanName = P.PlanName,
                                              OrganizationName = O.OrganizationName,
                                              SubscibedDate = OP.CreatedDate,
                                              PlanstartDate = OP.PlanstartDate
                                          }).ToList();
                        return entryPoint;

                    }
                    else
                    {
                        // OrganizationPlanDetails = Context.OrganizationPlans.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate && x.OrganizationID == OrganizationID).ToList();
                        var entryPoint = (from OP in Context.OrganizationPlans
                                          join P in Context.Plans on OP.PlanID equals P.PlanID
                                          join O in Context.Organizations on OP.OrganizationID equals O.OrganizationID
                                          where OP.CreatedDate >= FromDate && OP.CreatedDate <= ToDate &&
                                          OP.OrganizationID == OrganizationID
                                          select new
                                          {
                                              PlanName = P.PlanName,
                                              OrganizationName = O.OrganizationName,
                                              SubscibedDate = OP.CreatedDate,
                                              PlanstartDate = OP.PlanstartDate
                                          }).ToList();
                        return entryPoint;
                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetOrganizationPlanDetails: OrganizationID: " + OrganizationID, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return "";
        }


        public List<PlansMapping> GetProviderPlanDetails(DateTime FromDate, DateTime ToDate, int ProviderID)
        {
            List<PlansMapping> ProviderPlanDetails = new List<PlansMapping>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    if (ProviderID == 0)
                    {
                        ProviderPlanDetails = Context.PlansMappings.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate).ToList();
                    }
                    else
                    {
                        ProviderPlanDetails = Context.PlansMappings.Where(x => x.CreatedDate >= FromDate && x.CreatedDate <= ToDate && x.ProviderID == ProviderID).ToList();
                    }

                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetProviderPlanDetails: ProviderID: " + ProviderID, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return ProviderPlanDetails;
        }

        public List<Result> InsertTermsAndConditions(string TermsAndConditionsName, string TempletPath, int Type)
        {
            List<Result> obj = new List<Result>();
            Result res = new Result();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    var items = Context.TermsAndConditions.OrderByDescending(u => u.TermsAndConditionsID).Where(u => u.Type == Type).Take(1);
                    var objTermsAndConditionsList = items.ToList();
                    TermsAndCondition termsandconditions = new TermsAndCondition()
                    {
                        TermsAndConditionsName = TermsAndConditionsName,
                        TempletPath = TempletPath,
                        Type = Type,
                        CreatedDate = DateTime.Parse(Convert.ToString(DateTime.UtcNow), new CultureInfo("en-US")),
                        IsActive = true,
                    };
                    Context.TermsAndConditions.Add(termsandconditions);
                    res.ResultID = Context.SaveChanges();
                    obj.Add(res);
                    if (res.ResultID >= 1)
                    {
                        if (objTermsAndConditionsList.Count >= 1)
                        {
                            int id = objTermsAndConditionsList[0].TermsAndConditionsID;
                            TermsAndCondition h = Context.TermsAndConditions.First(m => m.TermsAndConditionsID == id);
                            h.IsActive = false;
                            int Result = Context.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                res.ResultName = ex.Message;
                obj.Add(res);
                Logging.LogMessage("InsertTermsAndConditions: Type: " + Type, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }

            return obj;
        }
        /// <summary>
        /// this method call from member login,Organization Login,User login for validate accepted terms and conditions
        /// </summary>
        /// <param name="intType"></param>
        /// <returns></returns>

        public List<TermsAndCondition> GetTermsAndConditions(int intType)
        {
            List<TermsAndCondition> obj = new List<TermsAndCondition>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    var objTermsAndConditions = Context.TermsAndConditions.Where(T => T.Type == intType && T.IsActive == true).ToList();
                    obj = objTermsAndConditions.ToList();
                }
            }
            catch (Exception ex)
            {
                string s = ex.InnerException.Message;
                string st = ex.InnerException.StackTrace;
                string st1 = ex.InnerException.Source;
                Logging.LogMessage("GetTermsAndConditions: Type: " + intType, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }
            return obj;

        }

        public List<Result> UpdateTermsandConditions(int UserID)
        {
            List<Result> obj = new List<Result>();
            Result res = new Result();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    User data = Context.Users.FirstOrDefault(m => m.UserID == UserID);
                    data.IsTermsAccepted = true;
                    data.TermsAcceptDate = DateTime.Parse(Convert.ToString(DateTime.UtcNow), new CultureInfo("en-US"));
                    int Result = Context.SaveChanges();

                    res.ResultID = Result;
                    obj.Add(res);
                }
            }
            catch (Exception ex)
            {
                res.ResultName = ex.Message;
                obj.Add(res);
                Logging.LogMessage("UpdateTermsandConditions: UserID: " + UserID, ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
            }

            return obj;
        }
       

        /// <summary>
        /// Returning Oject of the searched text values to ViewProviders in Organization Module -- Ragini
        /// </summary>
        public object GetProviderDetailAutoComplete(int intOrganizationID, string Text)
        {

            using (var Context = new Dev_PPCPEntities(1))
            {
                if (intOrganizationID != 0)
                {
                    var dataset = Context.Providers
                   .Where(x => x.OrganizationID == intOrganizationID)
                   .Where(x => x.FirstName.Contains(Text) || x.LastName.Contains(Text) || x.MobileNumber.Contains(Text))
                   .Select(x => new
                   {
                       ProviderName = x.FirstName + " " + x.LastName + "," + x.MobileNumber,
                       ProviderID = x.ProviderID,

                   }).ToList();
                    return dataset;
                }
                else
                {
                    var dataset = Context.Providers
               .Where(x => x.FirstName.Contains(Text) || x.LastName.Contains(Text) || x.MobileNumber.Contains(Text))
               .Select(x => new
               {
                   ProviderName = x.FirstName + " " + x.LastName + "," + x.MobileNumber,
                   ProviderID = x.ProviderID,

               }).ToList();
                    return dataset;
                }
            }

        }

        
        internal List<Organization> GetDisabledOrganizationDetails(int intOrganizationID)
        {
            List<Organization> getdisabledOrganizations = new List<Organization>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    if (intOrganizationID == 0)
                    {
                        getdisabledOrganizations = Context.Organizations.Where(m => m.IsActive == false).ToList();

                    }
                    else
                    {
                        getdisabledOrganizations = Context.Organizations.Where(m => m.OrganizationID == intOrganizationID && m.IsActive == false).ToList();
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return getdisabledOrganizations;
        }


        public object GetUserDetailsAutoComplete(int intOrganizationID, string Text)
        {

            using (var Context = new Dev_PPCPEntities(1))
            {
                if (intOrganizationID != 0)
                {
                    var dataset = Context.OrganizationUsers
                   .Where(x => x.OrganizationID == intOrganizationID)
                   .Where(x => x.FirstName.Contains(Text) || x.LastName.Contains(Text) || x.MobileNumber.Contains(Text))
                   .Select(x => new
                   {
                       UserName = x.FirstName + " " + x.LastName + "," + x.MobileNumber,
                       UserID = x.UserID,

                   }).ToList();
                    return dataset;
                }
                else
                {
                    var dataset = Context.OrganizationUsers
               .Where(x => x.FirstName.Contains(Text) || x.LastName.Contains(Text) || x.MobileNumber.Contains(Text))
               .Select(x => new
               {
                   UserName = x.FirstName + " " + x.LastName + "," + x.MobileNumber,
                   UserID = x.UserID,

               }).ToList();
                    return dataset;
                }
            }

        }

        public List<PlansAndPlansMapping> GetPPCPOrganizationProviderPlansBasedonFilters(int OrganizationId, int ProviderId, int PlanId, int StateId, int CityId, string Zip, int Plantype)
        {

            List<PlansAndPlansMapping> list = new List<PlansAndPlansMapping>();
            try
            {
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["DALDefaultService"].ConnectionString))
                {
                    list = conn.Query<PlansAndPlansMapping>("Pr_GetPlansBasedOnFilters", new { OrganizationId, ProviderId, PlanId, StateId, CityId, Zip, Plantype }, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                Logging.LogMessage("GetPPCPOrganizationProviderPlansBasedonFilters: OrganizationId: " + OrganizationId + ", ProviderId:" + ProviderId + ", StateId: " + StateId + ", CityId: " + CityId , ex.Message + "; InnerException: " + ex.InnerException + "; stacktrace:" + ex.StackTrace, LogType.Error, -1);
                return null;
            }
            return list;
            
        }

    }
}