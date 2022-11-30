using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PPCPWebApiServices.CustomEntities
{
    public class MemberPlanDetails
    {
        public int MemberPlanID { get; set; }
        public int MemberID { get; set; }
        public Nullable<int> MemberParentID { get; set; }
        public string MemberName { get; set; }
        public bool doesPlanExist { get; set; }
        public int PlanID { get; set; }
        public string PlanName { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<int> ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> PlanStartDate { get; set; }
        public Nullable<System.DateTime> PlanEndDate { get; set; }
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
        public Nullable<int> PlanType { get; set; }
        public Nullable<decimal> GrandTotalAmount { get; set; }
        public Nullable<decimal> GrandAmountPaid { get; set; }
        public string PatientTAndCPath { get; set; }
    }
}