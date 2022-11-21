using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.Models.PPCPWebService.DC
{
    public class OrganizationDetails
    {
        public string OrganizationName { get; set; }

        public string TaxID { get; set; }
        public string OrgEmail { get; set; }
     
        public string OrgCountryCode { get; set; }
       
        public string OrgMobileNumber { get; set; }
        public int? OrgCountryID { get; set; }
       
        public string OrgCountryName { get; set; }
        public int? OrgStateID { get; set; }
      
        public string OrgStateName { get; set; }
        public int? OrgCityID { get; set; }
     
        public string OrgCityName { get; set; }
     
        public string OrgZip { get; set; }
      
        public string OrgZipCode { get; set; }
        public string OrgAddress { get; set; }

        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public DateTime? DOB { get; set; }
      
        public int? Age { get; set; }
        
        public string Gender { get; set; }
        public int? SalutationID { get; set; }
       
        public string Salutation { get; set; }
       
        public string Email { get; set; }
      
        public string CountryCode { get; set; }
      
        public string MobileNumber { get; set; }
        public int? CountryID { get; set; }
      
        public string CountryName { get; set; }
        public string Address { get; set; }
        public int? Type { get; set; }
        public int? StateID { get; set; }
      
        public string StateName { get; set; }
        public int? CityID { get; set; }
       
        public string CityName { get; set; }
      
        public string Zip { get; set; }
     
        public string ZipCode { get; set; }
      
        public string UserName { get; set; }
     
        public string Password { get; set; }
 
        public string ConfirmPassword { get; set; }

        public int? UserID { get; set; }

        public string Result { get; set; }

        public string PreferredIP { get; set; }
        public int? TwoFactorType { get; set; }
        public bool? IsTwofactorAuthentication { get; set; }

        public string Otp { get; set; }


        public string UserEmail { get; set; }

        public string UserCountryCode { get; set; }

        public string UserMobileNumber { get; set; }
        public int? UserCountryID { get; set; }

        public string UserCountryName { get; set; }
        public int? UserStateID { get; set; }

        public string UserStateName { get; set; }
        public int? UserCityID { get; set; }

        public string UserCityName { get; set; }

        public string UserZip { get; set; }

        public string UserZipCode { get; set; }

        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }

        public string UserSSN { get; set; }
    }
    public class TemporaryUserDetails
    {
        public int? UserID { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string result { get; set; }

        public string TransactionID { get; set; }
    }

    public class OrganizationUsers
    {
        public int? UserID { get; set; }

        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Salutation { get; set; }

        public DateTime? DOB { get; set; }
        public string Gender { get; set; }

        public string Email { get; set; }

        public string CountryCode { get; set; }


        public string MobileNumber { get; set; }

        public int? CountryID { get; set; }
        public string CountryName { get; set; }

        public int? StateID { get; set; }

        public string StateName { get; set; }


        public int? CityID { get; set; }
        public string CityName { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Type { get; set; }
        public bool? IsTwofactorAuthentication { get; set; }
        public string PreferredIP { get; set; }
        public int? TwoFactorType { get; set; }
        public string Otp { get; set; }

        public DateTime? OrganizationUserTandC { get; set; }

        public DateTime? OrganizationTandC { get; set; }

        public int OrganizationUserTandCFlag { get; set; }
        public int OrganizationTandCFlag { get; set; }

    }

    public class ValidateOrgForgotCredentials
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string CountryCode { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string Otp { get; set; }
    }


    public class UpdateOrgPassword
    {
        public int UserID { get; set; }
        public string Password { get; set; }
    }

    public class OrganizationUserDetails
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<int> ParentOrganizationID { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string CountryName { get; set; }
        public Nullable<int> StateID { get; set; }
        public string StateName { get; set; }
        public Nullable<int> CityID { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public Nullable<int> Type { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public int UserID { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string OrgUserEmail { get; set; }
        public string OrgUserCountryCode { get; set; }
        public string OrgUserMobileNumber { get; set; }
        public Nullable<int> OrgUserCountryID { get; set; }
        public string OrgUserCountryName { get; set; }
        public Nullable<int> OrgUserStateID { get; set; }
        public string OrgUserStateName { get; set; }
        public Nullable<int> OrgUserCityID { get; set; }
        public string OrgUserCityName { get; set; }
        public string OrgUserAddress { get; set; }
        public string OrgUserZip { get; set; }
    }
    public class OrganizationPlanDetails
    {
        public int MemberPlanID { get; set; }
        public int MemberID { get; set; }
        public Nullable<int> MemberParentID { get; set; }
        public string MemberName { get; set; }
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Status { get; set; }

        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public Nullable<decimal> Discount { get; set; }
        public string PaymentInterval { get; set; }
        public string Duration { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<int> Plan_Code { get; set; }

        public virtual Member Member { get; set; }

        public Nullable<decimal> Amount { get; set; }
        public string PaymentIntervals { get; set; }
        public Nullable<bool> IsActive { get; set; }

        public string PlanTermName { get; set; }
        public Nullable<int> PlanTermMonths { get; set; }
        public Nullable<decimal> VisitFee { get; set; }
        public Nullable<decimal> EnrollFee { get; set; }
        public Nullable<int> FromAge { get; set; }
        public Nullable<int> ToAge { get; set; }
        public Nullable<int> GenderID { get; set; }
        public Nullable<int> PlanType { get; set; }
        public Nullable<bool> PlanStatus { get; set; }
        public Nullable<System.DateTime> PlanStartDate { get; set; }
        public Nullable<System.DateTime> PlanEndDate { get; set; }
        public string PlanDescription { get; set; }

        public string PStartDate { get; set; }
        public string PEndDate { get; set; }

        public string Paymentschedule { get; set; }

        public int? NoofInstallments { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? InstallmentFee { get; set; }
        public decimal? Savings { get; set; }
    }

    public class PPCPReports
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProviderName { get; set; }
        public string DOB { get; set; }
        public string PlanName { get; set; }
        public string PlanStartDate { get; set; }
        public string PlanEndDate { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> AmountPaid { get; set; }
        public Nullable<decimal> DueAmount { get; set; }
        public string PaymentDate { get; set; }
        public string MobileNumber { get; set; }
        public string PaymentStatus { get; set; }
       

    }


    public class MembersList
    {

        public int MemberID { get; set; }
        public Nullable<int> MemberParentID { get; set; }
        public string MemberCode { get; set; }
        public Nullable<int> RelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MemberName { get; set; }
        public string Salutation { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public Nullable<int> CountryID { get; set; }
        public string CountryName { get; set; }
        public Nullable<int> StateID { get; set; }
        public string StateName { get; set; }
        public Nullable<int> CityID { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTwofactorAuthentication { get; set; }
        public string PreferredIP { get; set; }
        public Nullable<int> TwoFactorType { get; set; }
        public Nullable<int> ID { get; set; }
        public Nullable<int> Type { get; set; }
        public string StripeCustomerID { get; set; }
        public Nullable<System.DateTime> TandCAcceptedDate { get; set; }


        //Plan details
        public string PlanName { get; set; }
        public DateTime PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }

    }


    //public class PracticeTransactions
    //{
    //    public int MemberID { get; set; }
    //    public string MemberName { get; set; }
    //    public string PlanName { get; set; }
    //    public string DOB { get; set; }
    //    public string DoctorName { get; set; }       
    //    public Nullable<decimal> AmountPaid { get; set; }    
    //    public string PaymentDate { get; set; }
    //    public int OrganizationID { get; set; }
    //    public int MemberPlanID { get; set; }
    //    public int ID { get; set; }
    //}
}