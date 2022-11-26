﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class Dev_PPCPEntities : DbContext
    {
        public Dev_PPCPEntities()
            : base("name=Dev_PPCPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CitiesLKP> CitiesLKPs { get; set; }
        public virtual DbSet<CountriesLKP> CountriesLKPs { get; set; }
        public virtual DbSet<FamilyMember> FamilyMembers { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<PlansPriceDetail> PlansPriceDetails { get; set; }
        public virtual DbSet<ProviderSpecialization> ProviderSpecializations { get; set; }
        public virtual DbSet<RelationshipLkp> RelationshipLkps { get; set; }
        public virtual DbSet<SpecializationLKP> SpecializationLKPs { get; set; }
        public virtual DbSet<StatesLKP> StatesLKPs { get; set; }
        public virtual DbSet<TimeZonesLKP> TimeZonesLKPs { get; set; }
        public virtual DbSet<Application_Parameter_Config> Application_Parameter_Config { get; set; }
        public virtual DbSet<OrganizationPlan> OrganizationPlans { get; set; }
        public virtual DbSet<Plan> Plans { get; set; }
        public virtual DbSet<PaymentDetail> PaymentDetails { get; set; }
        public virtual DbSet<PlansMapping> PlansMappings { get; set; }
        public virtual DbSet<TermsAndCondition> TermsAndConditions { get; set; }
        public virtual DbSet<OrganizationUser> OrganizationUsers { get; set; }
        public virtual DbSet<MemberPlanMapping> MemberPlanMappings { get; set; }
        public virtual DbSet<ModuleUseCas> ModuleUseCases { get; set; }
        public virtual DbSet<Provider> Providers { get; set; }
        public virtual DbSet<MemberPlanInstallmentMapping> MemberPlanInstallmentMappings { get; set; }
        public virtual DbSet<TransactionstoPractice> TransactionstoPractices { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<MemberPlan> MemberPlans { get; set; }
        public virtual DbSet<lkpRole> lkpRoles { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<Log> Logs { get; set; }
    
        public virtual ObjectResult<Pr_GetProviders_Result> Pr_GetProviders(Nullable<int> organizationID)
        {
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Pr_GetProviders_Result>("Pr_GetProviders", organizationIDParameter);
        }
    
        public virtual ObjectResult<Pr_GetOrganizationUsers_Result> Pr_GetOrganizationUsers(Nullable<int> organizationID)
        {
            var organizationIDParameter = organizationID.HasValue ?
                new ObjectParameter("OrganizationID", organizationID) :
                new ObjectParameter("OrganizationID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Pr_GetOrganizationUsers_Result>("Pr_GetOrganizationUsers", organizationIDParameter);
        }
    }
}
