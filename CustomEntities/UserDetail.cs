using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.CustomEntities
{
    public class UserProfile
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
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
        public bool IsTermsNeeded { get; set; }
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
        //public int TermsAndConditionsNeeded { get; set; }

        //additional org details
        public int? OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public int BillingTypeID { get; set; }
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

    public class EmailMaster
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public string Subject { get; set; } 
        public string HtmlBody { get; set; }
        public bool isActive { get; set; }
    }
}