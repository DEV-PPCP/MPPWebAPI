using Newtonsoft.Json;
using PPCPWebApiServices.Models.PPCPWebService.DC;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Serialization;
using static PPCPWebApiServices.Models.PPCPWebService.DC.DCProviderService;

namespace PPCPWebApiServices.Models.PPCPWebService.DAL
{
    public class DALProviderService
    {
        public List<Provider> ValidateProviderLogin(string Username, string Password)
        {

            List<Provider> objProvider = new List<Provider>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    var query = (from RR in Context.ProviderCredentials
                                 from M in Context.Providers
                                 where RR.ProviderID == M.ProviderID
                                 //|| RR.SoldProductId == M.ProductID // Your join
                                 where RR.UserName == Username
                                        && RR.Userpassword == Password
                                 //&& statusIds.Any(x => x.Equals(RR.StatusID.Value))
                                 select M).ToArray();


                    objProvider = query.ToList();
                }
            }
            catch (Exception ex)
            {

            }
            return objProvider;

        }
        //Provider credentials forgot username or password by veema
        public List<ProviderCredential> ValidateProviderForgotUserName(string Username, string Firstname, string Lastname, string Mobilenumber, string Countrycode, string email)
        {

            List<ProviderCredential> getProviderUsersDetails = new List<ProviderCredential>();


            try
            {

                using (var Context = new Dev_PPCPEntities(1))
                {
                    var query = (from RR in Context.ProviderCredentials
                                 from M in Context.Providers
                                 where RR.ProviderID == M.ProviderID
                                 where
                                        M.FirstName == Firstname
                                         && M.LastName == Lastname
                                           && M.MobileNumber == Mobilenumber
                                             && M.CountryCode == Countrycode
                                               && M.Email == email
                                 select RR).ToArray();

                    getProviderUsersDetails = query.ToList();
                }
                if (getProviderUsersDetails.Count >= 1)
                {
                    DALDefaultService dal = new DALDefaultService();
                    string OTP = dal.randamNumber();
                    string Message = "Dear " + Firstname + " " + Lastname + ", Your one time password is : " + OTP;
                    dal.SendMessageByText(Message, Mobilenumber, Countrycode);
                    getProviderUsersDetails[0].OTP = OTP;
                    //public string OTP { get; set; }
                }
            }
            catch (Exception ex)
            {

            }
            return getProviderUsersDetails;
        }

        public List<Provider> ValidateProviderForgotPassword(string UserName)
        {
            List<Provider> getProviderUsersDetails = new List<Provider>();
            try
            {

                using (var Context = new Dev_PPCPEntities(1))
                {
                    var query = (from PC in Context.ProviderCredentials
                                 from P in Context.Providers
                                 where PC.ProviderID == P.ProviderID
                                 where
                                        PC.UserName == UserName
                                 select P).ToArray();

                    getProviderUsersDetails = query.ToList();
                }
                if (getProviderUsersDetails.Count >= 1)
                {
                    DALDefaultService dal = new DALDefaultService();
                    string OTP = dal.randamNumber();
                    string Message = "Dear " + getProviderUsersDetails[0].FirstName + " " + getProviderUsersDetails[0].LastName + ", Your one time password is : " + OTP;
                    dal.SendMessageByText(Message, getProviderUsersDetails[0].MobileNumber, getProviderUsersDetails[0].CountryCode);
                    getProviderUsersDetails[0].OTP = OTP;
                    // public string OTP { get; set; }
                }
            }
            catch (Exception ex)
            {

            }
            return getProviderUsersDetails;
        }

        public List<Result> UpdatePassword(int intProviderID, string strPassword)
        {

            List<Result> res = new List<Result>();
            try
            {
                byte[] bytes = Encoding.UTF8.GetBytes(strPassword);
                strPassword = Convert.ToBase64String(bytes);//Convert the password to Encrypt

                using (var Context = new Dev_PPCPEntities(1))
                {
                    ProviderCredential h = Context.ProviderCredentials.First(m => m.ProviderID == intProviderID);
                    h.Userpassword = strPassword;
                    int result = Context.SaveChanges();
                    Result objres = new Result();
                    objres.ResultID = result;
                    res.Add(objres);

                }
            }
            catch (Exception ex)
            {
                Result objres = new Result();
                objres.ResultName = ex.Message;
                res.Add(objres);

            }
            return res;

        }
        public List<Member> GetOrganizationMemberDetails(int OrganizationID)
        {
            List<Member> getMemberDetails = new List<Member>();

            using (var Context = new Dev_PPCPEntities(1))
            {
                getMemberDetails = Context.Members.Where(m => m.ID == OrganizationID && m.Type == 2).ToList();
            }
            return getMemberDetails;
        }


        /// <summary>
        /// Update Providers ,Provider Details  -Ragini
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        public List<Result> UpdateProviderDetails(string providerxml)
        {
            
            List<Result> res = new List<Result>();
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(ProviderDetails));
                StringReader rdr = new StringReader(providerxml);
                ProviderDetails providerDetails = (ProviderDetails)serializer.Deserialize(rdr);
                using (var Context = new Dev_PPCPEntities(1))
                {
                    if (providerDetails.ProviderID != 0)
                    {
                        Provider objProvider = Context.Providers.First(m => m.ProviderID == providerDetails.ProviderID);
                        objProvider.FirstName = providerDetails.FirstName;
                        objProvider.LastName = providerDetails.LastName;
                        objProvider.DOB = providerDetails.DOB;
                        objProvider.CountryName = providerDetails.CountryName;
                        objProvider.CountryID = providerDetails.CountryID;
                        objProvider.Email = providerDetails.Email;
                        objProvider.MobileNumber = providerDetails.MobileNumber;
                        objProvider.Gender = providerDetails.Gender;
                        objProvider.Salutation = providerDetails.Salutation;
                        objProvider.CountryCode = providerDetails.CountryCode;
                        objProvider.CityName = providerDetails.CityName;
                        objProvider.CityID = providerDetails.CityID;
                        objProvider.StateID = providerDetails.StateID;
                        objProvider.StateName = providerDetails.StateName;
                        objProvider.Address = providerDetails.Address;
                        objProvider.Zip = providerDetails.Zip;
                        objProvider.IsTwofactorAuthentication = providerDetails.IsTwofactorAuthentication;
                        objProvider.PreferredIP = providerDetails.PreferredIP;
                        objProvider.TwoFactorType = providerDetails.TwoFactorType;
                        objProvider.SpecializationName = providerDetails.SpecializationName;
                        objProvider.SpecializationID = providerDetails.SpecializationID;
                        objProvider.Specialization = providerDetails.Specialization;
                        objProvider.NPI = providerDetails.NPI;
                        objProvider.Fax = providerDetails.Fax;
                        objProvider.Degree = providerDetails.Degree;
                        int result = Context.SaveChanges();
                        Result objresult = new Result();
                        objresult.ResultID = result;
                        res.Add(objresult);
                    }
                }
            }
            catch (Exception ex)
            {
                Result objres = new Result();
                objres.ResultName = ex.Message;
                res.Add(objres);
            }

            return res;
        }
     
        public List<Provider> GetProviderDetails(int ProvderID)
        {
            List<Provider> getProviderDetails = new List<Provider>();
            try
            {
                using (var Context = new Dev_PPCPEntities(1))
                {
                    getProviderDetails = Context.Providers.Where(m => (m.ProviderID == ProvderID)).ToList();

                }
            }
            catch (Exception ex)
            {

            }
            return getProviderDetails;
        }
    }
}