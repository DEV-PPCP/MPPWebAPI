using ExtendedXmlSerializer.ContentModel.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.CustomEntities
{
    public static class LogType
    {
        public const string Info = "Info";
        public const string Warning = "Warning";
        public const string Error = "Error";
    }
    public class LookupValue
    {
        public int Id { get; set; }
        public int LookupTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }
    }
    public static class enumTermsType
    {
        public const int Organization = 1;
        public const int Member = 2;
        public const int Provider = 3;
        public const int MPP = 4;
    }
    public static class VisitType
    {
        public const int InPerson = 15;
        public const int Tele = 16;
    }
    public static class PaymentType
    {
        public const int Cash = 20;
        public const int Credit = 21;
        public const int Check = 22;
    }
    public static class BillingType
    {
        public const int Lumpsum = 25;
        public const int PPV = 26;
    }

}