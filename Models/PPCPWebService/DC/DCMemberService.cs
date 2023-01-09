using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.Models.PPCPWebService.DC
{
    public class DCMemberService
    {
       
    }
    public class TemporaryMemberDetails
    {
        public int? MemberID { get; set; }

        public int? ResultID { get; set; }

        public string UserName { get; set; }
        public string UserPassword { get; set; }

        public string result { get; set; }

        public string TransactionID { get; set; }

        public string StripeCustomerID { get; set; }

      
    }
    public class MemberLoginDetails
    {
        public int? MemberID { get; set; }
        public string MemberCode { get; set; }

        public int? MemberParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Salutation { get; set; }
        public DateTime? DOB { get; set; }
        public string Gender { get; set; }
        public string  Email { get; set; }
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
        public int? OrganizationID { get; set; }
        public string Organizationname { get; set; }
        public int? OrganizationType { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsTwofactorAuthentication { get; set; }
        public string PreferredIP { get; set; }
        public int? TwoFactorType { get; set; }
        public string Otp { get; set; }
        public int? UserID { get; set; }

        public string StripeCustomerID { get; set; }

        public DateTime? TandCAcceptedDate { get; set; }

        public int TermsAndConditionsFlag { get; set; }
    }

    public class MemberPlansDetails
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

        public int PointsEarned { get; set; }

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

        public int BillingTypeID { get; set; }
        public string BillingType { get; set; }
      
        public string PlanTermName { get; set; }
        public Nullable<int> PlanTermMonths { get; set; }
        public Nullable<decimal> VisitFee { get; set; }
        public Nullable<decimal> TeleVisitFee { get; set; }
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

        public string AccountID { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<decimal> CommPrimaryMember { get; set; }
    }


    public class MemberPlanInstallmentMapping
    {
        public int MemberPlanInstallmentID { get; set; }
        public int MemberPlanID { get; set; }
        public int PaymentDetailsID { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<decimal> InstallmentAmount { get; set; }
        public Nullable<decimal> PointsAmount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public string PaymentStatus { get; set; }
        public string PaymentDate1 { get; set; }

    
    }
        public class MemberDetails
    {

        public int MemberPlanID { get; set; }
        public int MemberID { get; set; }
        public int ReferringMemberId { get; set; }

        public int MemberParentID { get; set; }
        public string MemberCode { get; set; }
        
        public string MemberName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public int SalutationID { get; set; }
        public string Salutation { get; set; }       
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string CountryName { get; set; }
        public Nullable<int> CountryID { get; set; }

        public Nullable<int> StateID { get; set; }

        public Nullable<int> CityID { get; set; }
        public string StateName { get; set; }        
        public string CityName { get; set; }
        public string Zip { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string OrganizationName { get; set; }
        public int OrganizationID { get; set; }
        public int BillingTypeID { get; set; }
        public string ProviderName { get; set; }
        public int ProviderID { get; set; }
        public string PlanName { get; set; }
        public int PlanID { get; set; }
        public string Specialization { get; set; }
        public DateTime PlanStartDate { get; set; }
        public string Paymentschedule { get; set; }
        public int NoofInstallments { get; set; }
        public decimal InstallmentAmount { get; set; }
        public decimal InstallmentFee { get; set; }
        public int Savings { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public string CVV { get; set; }
        
        public int MM { get; set; }
        public int YY { get; set; }

        public int TwoFactorType { get; set; }

        public decimal TotalAmount { get; set; }
        public decimal? Amount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal DueAmount { get; set; }
        public decimal Discount { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; }
        public int RelationshipID { get; set; }
        public string Relationship { get; set; }
        public string Address { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<bool> IsTwofactorAuthentication { get; set; }
        public string PreferredIP { get; set; }
        public string RelationshipName { get; set; }

        public Nullable<int> ID { get; set; }
        public Nullable<int> Type { get; set; }

        public string PlanTermName { get; set; }
        public int? PlanTermMonths { get; set; }
        public decimal? VisitFee { get; set; }
        public decimal? EnrollFee { get; set; }

        public int? FromAge { get; set; }
        public int? ToAge { get; set; }

        public int? GenderID { get; set; }

        public int? PlanType { get; set; }
        public bool? PlanStatus { get; set; }
        public DateTime? PlanEndDate { get; set; }

        public string PlanDescription { get; set; }
        public int? Plan_Code { get; set; }
        public int Result { get; set; }

        public string CardID { get; set; }

        public string StripeCustomerID { get; set; }

        public int LoginMemberID { get; set; }

        public string StripeAccountID { get; set; }
       // public decimal? CommPPCP { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<decimal> CommPrimaryMember { get; set; }
    }

    public class MakePayment
    {
        public int MemberID { get; set; }
        public int MemberParentID { get; set; }        
        public int CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public int MemberPlanCode { get; set; }
        public string MemberName { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal AmountPaid { get; set; }
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public string CardNumber { get; set; }
        public string NameOnCard { get; set; }
        public int MM { get; set; }
        public int YY { get; set; }
        public int CVV { get; set; }
        public string CardID { get; set; }
        public string StripeCustomerID { get; set; }

        public string Email { get; set; }

        public decimal Amount { get; set; }

        public string StripeAccountID { get; set; }

        public string MemberPlanInstallmentMapping { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<decimal> CommPrimaryMember { get; set; }
        public decimal InstallmentAmount { get; set; }
        public string OrganizationName { get; set; }
    }
    public class AddMemberDetails
    {
        public int MemberID { get; set; }

        public string MemberName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public int Age { get; set; }
        
        public int Gender { get; set; }

        public int SalutationID { get; set; }
        public string Salutation { get; set; }

        
        public string Email { get; set; }
       
        public string CountryCode { get; set; }
       
        public string MobileNumber { get; set; }
        public string CountryName { get; set; }

        public Nullable<int> CountryID { get; set; }

        public Nullable<int> StateID { get; set; }

        public Nullable<int> CityID { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        
        public string Zip { get; set; }
        public string ZipCode { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        
        public string ConfirmPassword { get; set; }
        public string OrganizationName { get; set; }

        public int OrganizationID { get; set; }

        public int RelationshipID { get; set; }
        public string RelationshipName { get; set; }
        public int Type { get; set; }
        public bool IsTwofactorAuthentication { get; set; }
        public string PreferredIP { get; set; }
        public int? TwoFactorType { get; set; }
    }


    public class DCMemberPlanInstallmentMapping
    {
        public int MemberPlanInstallmentID { get; set; }
        public Nullable<int> MemberPlanID { get; set; }
        public Nullable<int> PaymentDetailsID { get; set; }
        public Nullable<System.DateTime> PaymentDueDate { get; set; }
        public Nullable<decimal> PaymentAmount { get; set; }
        public Nullable<decimal> InstallmentAmount { get; set; }
        public Nullable<decimal> PointsAmount { get; set; }
        public Nullable<System.DateTime> PaymentDate { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public string PaymentStatus { get; set; }

       
    }

    public class ApplicationParameterConfig
    {
        public int? PARAMETER_ID { get; set; }
        public string PARAMETER_NAME { get; set; }
        public string PARAMETER_VALUE { get; set; }
        public string PARAMETER_DESCRIPTION { get; set; }
        public bool? IS_ENABLED { get; set; }
    }

    public class ReferralSummary
    {
        public int TotalPoints { get; set; }
        public int PointsEarned { get; set; }
        public int PointsPending { get; set; }
        public int AvailableToUse { get; set; }
        public int PointsUsed { get; set; }
        public string MemberReferralLink { get; set; }

    }
    public class Referral
    {
        public int Id { get; set; }
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool isReminderSet { get; set; }
        public DateTime? ReferralDate { get; set; }

        //set if member joins
        public DateTime? ReferralJoinedDate { get; set; }
        public int ReferralMemberID { get; set; }
        public int ReferralPlanID { get; set; }
        public string PlanName { get; set; }
        public int Points { get; set; }
        public DateTime? PointsEarnedDate { get; set; }
    }

}