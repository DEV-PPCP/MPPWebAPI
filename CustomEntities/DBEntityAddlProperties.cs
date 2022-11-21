using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices
{
    public partial class Dev_PPCPEntities : DbContext
    {

        public Dev_PPCPEntities(int val)
          : base("name=Dev_PPCPEntities")
        {
            if (val == 1)
            {
                Configuration.ProxyCreationEnabled = false;
            }
            else
            {
                Configuration.ProxyCreationEnabled = true;
            }
        }
    }
    public partial class Provider
    {
        [NotMapped]
        public string OTP { get; set; }
    }

    public partial class ProviderCredential
    {
        [NotMapped]
        public string OTP { get; set; }
    }

    public partial class MemberPlan
    {
        [NotMapped]
        public Nullable<decimal> GrandTotalAmount { get; set; }
        [NotMapped]
        public Nullable<decimal> GrandAmountPaid { get; set; }

    }
}