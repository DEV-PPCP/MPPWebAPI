//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PPCPWebApiServices
{
    using System;
    using System.Collections.Generic;
    
    public partial class Plan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Plan()
        {
            this.OrganizationPlans = new HashSet<OrganizationPlan>();
            this.PlansMappings = new HashSet<PlansMapping>();
        }
    
        public int PlanID { get; set; }
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
        public Nullable<decimal> CommPrimaryMember { get; set; }
        public Nullable<decimal> CommAdditionalMember { get; set; }
        public Nullable<bool> IsThirdParty { get; set; }
        public Nullable<int> OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string Features { get; set; }
        public string Patient_Features { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public Nullable<System.DateTime> UnSubscribedDate { get; set; }
        public string PatientTAndCPath { get; set; }
        public string OrganizationTAndCPath { get; set; }
        public string ProviderTAndCPath { get; set; }
        public Nullable<decimal> CommPPCP { get; set; }
        public Nullable<int> BillingTypeID { get; set; }
        public Nullable<int> TeleVisitFee { get; set; }
        public Nullable<int> MaxAllowedClaims { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationPlan> OrganizationPlans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlansMapping> PlansMappings { get; set; }
    }
}
