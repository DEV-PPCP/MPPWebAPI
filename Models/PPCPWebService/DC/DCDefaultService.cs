using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.Models.PPCPWebService.DC
{
    public class DCDefaultService
    {
    }

    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CountryCode { get; set; }
        public string MobileNumber { get; set; }
        public string OTP { get; set; }
        public string LastIPAddress { get; set; }        
        public string UserStatus { get; set; }
        public bool IsActive { get; set; }
        public bool IsAccountLocked { get; set; }
        public DateTime? DeactivationDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public bool IsTwoFactorEnabled { get; set; }
        public int? TwoFactorType { get; set; }
        public bool IsTermsAccepted { get; set; }
        public DateTime? TermsAcceptDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? AssociatedEntityId { get; set; }

        //additional properties
        public string RoleName { get; set; }
        public string RoleType { get; set; }
        public string TermsAndConditionsFile { get; set; }

        //additional org details
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        //public DateTime? OrganizationUserTandC { get; set; }
        //public DateTime? OrganizationTandC { get; set; }
        //public int OrganizationUserTandCFlag { get; set; }
        //public int OrganizationTandCFlag { get; set; }

        //additional member details
        public int? MemberID { get; set; }
        public int? MemberParentID { get; set; }
        //public DateTime? MemberTandCDate { get; set; }
        //public int MemberTermsAndConditionsFlag { get; set; }
        public string StripeCustomerID { get; set; }

        //provider details
        public int? ProviderID { get; set; }

    }
    public class CountriesLKP
    {
        public int? CountryID { get; set; }
        public string CountryName { get; set; }
    }
    public class StatesLKP
    {
        public int? StateID { get; set; }
        public string StateName { get; set; }
        public string StateCode { get; set; }
        public int? CountryID { get; set; }
    }
    public class CitiesLKP
    {

        public int? CityID { get; set; }
        public string CityName { get; set; }
        public int? CountyID { get; set; }
        public int? StateID { get; set; }
        public int? TimeZoneID { get; set; }
        public string ZipCode { get; set; }
    }
    public class PPCPOrganizations
    {
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int? ParentOrganizationID { get; set; }
        public int? CountryID { get; set; }
        public string CountryName { get; set; }
        public int? StateID { get; set; }
        public string StateName { get; set; }
        public int? CityID { get; set; }
        public string CityName { get; set; }
        public string Address { get; set; }
        public string Zip { get; set; }
        public int? Type { get; set; }
    }

    public class PPCPOrganizationProviders
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
        public DateTime? CreatedDateip { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int Type { get; set; }

        public int? ProviderID { get; set; }

        public string ProviderName { get; set; }
    }

    public class PPCPOrganizationProviderPlans
    {
        public int? PlanMapID { get; set; }
        public int? PlanID { get; set; }
        public string PlanName { get; set; }
        public int? ProviderID { get; set; }
        public string ProviderName { get; set; }
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public bool? IsActive { get; set; }


    }

    public class Result
    {
        public int? ResultID { get; set; }
        public string ResultName { get; set; }
        public string Exception { get; set; }
    }

    public class Plans
    {
        public int? PlanID { get; set; }
        public string PlanName { get; set; }

        public string PaymentIntervals { get; set; }

        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public decimal? Amount { get; set; }

    }
    public class PaymentIntervalsList
    {
        public List<PaymentIntervals> PaymentIntervals { get; set; }
    }
    public class PaymentIntervalsDetails
    {
        public List<PaymentIntervalsDetails1> PaymentIntervalsDetails1 { get; set; }
    }
    public class PaymentIntervalsDetails1
    {
        public string Paymentschedule { get; set; }
        public int? NoofInstallments { get; set; }

        public decimal? InstallmentAmount { get; set; }

        public decimal? InstallmentFee { get; set; }
        public int? Savings { get; set; }

        public decimal? TotalAmount { get; set; }

    }
    public class PaymentIntervals
    {
        public int? PlanID { get; set; }
        public string PlanName { get; set; }
        public string Paymentschedule { get; set; }
        public int? NoofInstallments { get; set; }

        public decimal? InstallmentAmount { get; set; }

        public decimal? InstallmentFee { get; set; }
        public int? Savings { get; set; }

        public decimal? TotalAmount { get; set; }
        public bool? IsActive { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public decimal? MonthlyFee { get; set; }
        public int? ProviderID { get; set; }
        public string ProviderName { get; set; }
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int BillingTypeID { get; set; }
        public int MaxAllowedClaims { get; set; }

        public string AccountID { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<decimal> CommPrimaryMember { get; set; }
        public Nullable<decimal> CommAdditionalMember { get; set; }
    }

    public class Credentials
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? UserID { get; set; }

        public string UserName { get; set; }

        public string CountryCode { get; set; }

        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }

        public string OTP { get; set; }
    }

    public class MemberPlans
    {
        public int? MemberPlanID { get; set; }
        public int? MemberID { get; set; }
        public string MemberName { get; set; }
        public int? PlanID { get; set; }
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string Status { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanEnddate { get; set; }
        public Decimal? TotalAmount { get; set; }
        public Decimal? AmountPaid { get; set; }
        public Decimal? DueAmount { get; set; }
        public Decimal? Discount { get; set; }
        public string PaymentInterval { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string PlanName { get; set; }
        public string Duration { get; set; }
    }

    public class PlansAndPlansMapping
    {

        public int? PlanID { get; set; }
        public string PlanCode { get; set; }
        public string PlanName { get; set; }
        public Nullable<decimal> MonthlyFee { get; set; }
        public string PaymentIntervals { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
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
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<int> PlanMemberType { get; set; }
        public Nullable<decimal> PlanFeeAddMember { get; set; }
      
        public Nullable<decimal> CommAdditionalMember { get; set; }
        public Nullable<bool> IsThirdParty { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public Nullable<int> ProviderID { get; set; }
        
        public string ProviderName { get; set; }
        public string FirstName { get; set; } //provider firstname
        public string LastName { get; set; } //provider LastName
        public string OrganizationName { get; set; }
        public string OrganizationAddress { get; set; }
        public string ProviderAddress { get; set; }
        public string Features { get; set; }
        public string Patient_Features { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public int OrgID { get; set; }
        public string OrgName { get; set; }
        public string PatientTAndCPath { get; set; }
        public string OrganizationTAndCPath { get; set; }
        public string ProviderTAndCPath { get; set; }

        public string AccountID { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<decimal> CommPrimaryMember { get; set; }
        public int MapID { get; set; }
        public int BillingTypeID { get; set; }
        public string BillingType { get; set; }
        public int MaxAllowedClaims { get; set; }
    }
    public class PaymentDetails
    {
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }

        public int PaymentDetailsID { get; set; }
        public Nullable<int> MemberPlanID { get; set; }
        public Nullable<int> MemberID { get; set; }
        public Nullable<int> MemberParentID { get; set; }
        public string Membername { get; set; }
        public Nullable<int> PlanID { get; set; }
        public string PlanName { get; set; }
        public string TransactionID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<decimal> PaidAmount { get; set; }
        public Nullable<decimal> NetAmount { get; set; }
        public Nullable<decimal> TransactionFee { get; set; }
        
    }

    public class Intervals
    {
        public string Paymentschedule { get; set; }
        public int? NoofInstallments { get; set; }

        public decimal? InstallmentAmount { get; set; }

        public decimal? InstallmentFee { get; set; }
        public int? Savings { get; set; }

        public decimal? TotalAmount { get; set; }
        public decimal? EnrollFee { get; set; }

    }

    public class StripePaymentDetails
    {
        public string TransactionID { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TransactionFee { get; set; }

        public string Result { get; set; }

        public decimal TransferAmount { get; set; }



    }
    public class RelationShip
    {

        public int RelationshipID { get; set; }

        public string RelationshipName { get; set; }


    }
    public class stripeCardDetails
    {


        public string Id { get; set; }
        public string ExpirationMonth { get; set; }

        public string ExpirationYear { get; set; }

        public string Last4 { get; set; }

        public string Name { get; set; }

        public string Brand { get; set; }
        public string Fingerprint { get; set; }

    }
}