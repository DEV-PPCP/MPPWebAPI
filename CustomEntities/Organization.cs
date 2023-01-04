using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.CustomEntities
{
    public class OrganizationDetail
    {
        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public Nullable<int> ParentOrganizationID { get; set; }
        public string TaxID { get; set; }
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
        public string AccountID { get; set; }
        public Nullable<System.DateTime> TandCAcceptedDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<int> BillingTypeID { get; set; }
        public string BillingType { get; set; }
    }
}