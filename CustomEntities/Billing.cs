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
        public string MemberName { get; set; }
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public DateTime? SubmitDate { get; set; }
        public DateTime DateOfService { get; set; }
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
        public DateTime PaymentDate { get; set; }
        public string ReceiptNumber { get; set; }
        public DateTime? DatePaid { get; set; }
        public decimal PlanPaidAmount { get; set; }
        public int ClaimStatusId { get; set; }
        public string ClaimStatus { get; set; }
        public DateTime? ManualApprovalDate { get; set; }
        public int ManualApprovalBy { get; set; }
        public string ManualApprovalUserName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        //Plan 
        public int PlanId { get; set; }
        public string PlanName { get; set; }
        public decimal AllowedFee { get; set; }
        public decimal CoPayFee { get; set; }
    }
}