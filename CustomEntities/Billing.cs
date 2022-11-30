using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.CustomEntities
{
    public class MemberVisit
    {
        public int VisitId { get; set; }
        public int MemberId { get; set; }
        public string MemberCardID { get; set; }
        public string MemberName { get; set; }
        public DateTime? MemberDOB { get; set; }
        public string MemberCountryCode { get; set; }
        public string MemberMobileNumber { get; set; }
        public string MemberEmail { get; set; }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrgStripeAccountId { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime? DateOfService { get; set; }
        public bool IsPlanExistingOnDOS { get; set; }
        public int MemberPlanId { get; set; }
        public int VisitTypeId { get; set; }
        public string VisitType { get; set; }
        public int ProviderId { get; set; }
        public string ProviderName { get; set; }
        public string ProviderNPI { get; set; }
        public string PrimaryDiagnosisCode { get; set; }
        public string PrimaryProcedureCode { get; set; }
        public decimal Copay { get; set; }
        public decimal OtherCharges { get; set; }
        public int PaymentTypeId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal PlanPaidAmount { get; set; }
        public int ClaimStatusId { get; set; }
        public string ClaimStatus { get; set; }
        public int ClaimSubStatusId { get; set; }
        public string ClaimSubStatus { get; set; }
        public DateTime? ManualApprovalDate { get; set; }
        public int ManualApprovalBy { get; set; }
        public string ManualApprovalUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public int ModifiedBy { get; set; }

        //Plan 
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public decimal AllowedFee { get; set; }
        public decimal CoPayFee { get; set; }
        public decimal InPersonProviderFee { get; set; }
        public decimal TeleVisitProviderFee { get; set; }

        public List<ProcedureLine> ProcedureLines { get; set; }
    }

    public class ProcedureLine
    {
        public string ProcCode { get; set; }
        public string Modifier1 { get; set; }
        public string Modifier2 { get; set; }
        public string Modifier3 { get; set; }
        public string Modifier4 { get; set; }
    }
}