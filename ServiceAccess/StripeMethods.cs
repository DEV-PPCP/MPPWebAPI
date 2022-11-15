using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PPCPWebApiServices.ServiceAccess
{
    public class StripeMethods
    {
        static string StripeApiKey = System.Configuration.ConfigurationManager.AppSettings["StripeApiKey"];
        /// <summary>
        /// This method is used for Create stripe token -vinod(19/02/2020)
        /// </summary>
        /// <param name="CardNumber"></param>
        /// <param name="MM"></param>
        /// <param name="YY"></param>
        /// <param name="Cvv"></param>
        /// <param name="cardName"></param>
        /// <returns></returns>
        public Token StripeTokenCreation(string CardNumber, int MM, int YY, string Cvv, string cardName)
        {
            StripeConfiguration.ApiKey = StripeApiKey;
            var stripeTokenCreateOptions = new Stripe.TokenCreateOptions();
            stripeTokenCreateOptions = new Stripe.TokenCreateOptions
            {
                Card = new Stripe.CreditCardOptions
                {
                    Number = CardNumber,
                    ExpMonth = MM,
                    ExpYear = YY,
                    Cvc = Cvv,
                    Name = cardName
                }
            };
            var tokenService = new Stripe.TokenService();
            var stripeToken = tokenService.Create(stripeTokenCreateOptions);
            return stripeToken;
        }
        /// <summary>
        /// This method is used for Validate Saved card details-Vinod(19/02/2020)
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <param name="objtoken"></param>
        /// <returns></returns>

        public int ValidateExistingCardDetails(string CustomerID, Token objtoken)
        {
            StripeConfiguration.ApiKey = StripeApiKey;
            int intValidatevalue = 0;
            var service = new CardService();
            var options = new CardListOptions
            {
                Limit = 100,
            };
            var cards = service.List(CustomerID, options).ToList();
            for (int i = 0; i < cards.Count; i++)
            {
                if (objtoken.Card.Fingerprint == cards[i].Fingerprint.ToString())
                {
                    intValidatevalue = 1;
                    break;
                }
            }
            return intValidatevalue;
        }
        /// <summary>
        /// This method is to create stripe customer -vinod(19/02/2020)
        /// </summary>
        /// <param name="Email"></param>
        /// <param name="token"></param>
        /// <returns></returns>

        public Stripe.Customer GetCustomer(string Email, string token)
        {
            StripeConfiguration.ApiKey = StripeApiKey;
            var options = new CustomerCreateOptions
            {
                Email = Email,
                Source = token
            };
            var service = new CustomerService();
            return service.Create(options);
        }
        /// <summary>
        /// This methos is used for Add new Card to Customer-vinod(19/02/2020)- 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public Stripe.Card AddCardToCustomet(string token, string CustomerID)
        {
            StripeConfiguration.ApiKey = StripeApiKey;
            var cardOptions = new Stripe.CardCreateOptions()
            {
                Source = token
            };
            var cardService = new Stripe.CardService();
            var card = cardService.Create(CustomerID, cardOptions);
            return card;
        }
        /// <summary>
        /// This method is used for get the exsiting card details
        /// </summary>
        /// <param name="CustomerID"></param>
        /// <returns></returns>
        public List<Stripe.Card> GetCardDetails(string CustomerID)
        {
            StripeConfiguration.ApiKey = StripeApiKey;
            var service = new CardService();
            var options = new CardListOptions
            {
                Limit = 100,
            };
            var cardDeails = service.List(CustomerID, options).ToList();
            return cardDeails;
        }

//        public Stripe.Account CreateStripeCustomer(string AccountName, string AccountNumber, string RoutingNumber, string MobileNumber,
//   string FirstName, string LastName, string EmailID, string PostelCode, string FirstLineAddress, string SecoundLineAddress, string State, string City, DateTime? DOB)
//        {
//            string stripeApiKey = System.Configuration.ConfigurationManager.AppSettings["StripeApiKey"];
//            StripeConfiguration.ApiKey = StripeApiKey;
//            var bankAccountOptions = new AccountBankAccountOptions();
//            bankAccountOptions.AccountHolderName = AccountName.Trim();
//            bankAccountOptions.AccountNumber = AccountNumber.Trim();
//            bankAccountOptions.RoutingNumber = RoutingNumber.Trim();
//            bankAccountOptions.Country = "US";
//            bankAccountOptions.Currency = "USD";
//            bankAccountOptions.AccountHolderType = "company";
//            var accountLegalEntityOptions = new PersonCreateOptions();
//            accountLegalEntityOptions.SSNLast4 = "0000";
//            accountLegalEntityOptions.Phone = MobileNumber;
//            accountLegalEntityOptions.FirstName = FirstName.Trim();
//            accountLegalEntityOptions.LastName = LastName.Trim();
//            accountLegalEntityOptions.Email = EmailID;
//            AddressOptions addressOptions = new Stripe.AddressOptions()
//            {
//                Country = "US",
//                State = State.Trim(),
//                City = City.Trim(),
//                PostalCode = PostelCode.Trim(),
//                Line1 = "462 New Rd",//FirstLineAddress.Trim()
//                Line2 = SecoundLineAddress.Trim()
//            };


//            accountLegalEntityOptions.Address = addressOptions;
//            AccountTosAcceptanceOptions AAO = new AccountTosAcceptanceOptions();
//            AAO.Ip = Iph.Utilities.Common.GetUserIp();
//            AAO.Date = DateTime.Now;
//            DateTime date = Convert.ToDateTime(DOB);
//            var DobOptions = new DobOptions()
//            {
//                Day = date.Day,
//                Month = date.Month,
//                Year = date.Year
//            };
//            accountLegalEntityOptions.Dob = DobOptions;
//            var accountOptions = new AccountCreateOptions()
//            {
//                Email = EmailID.Trim(),
//                Type = "custom",//StripeAccountType.Custom,
//                Country = "US",
//                BusinessType = "individual",
//                ExternalAccount = bankAccountOptions,
//                Individual = accountLegalEntityOptions,
//                TosAcceptance = AAO,
//                RequestedCapabilities = new List<string>
//{
//"card_payments",
//"transfers",

//},
//                BusinessProfile = new AccountBusinessProfileOptions
//                {
//                    Mcc = "8011", //dont rmeove this . let it be hardcoded only
//                    ProductDescription = "myphysicianplan",//dont rmeove this . let it be hardcoded only
//                },
//            };
//            var accountService = new AccountService();
//            Stripe.Account account = accountService.Create(accountOptions);
//            return account;
//        }
        //company account
        public Stripe.Account CreateStripeCustomer(string AccountName, string AccountNumber, string RoutingNumber, string MobileNumber,
            string FirstName, string LastName, string EmailID, string PostelCode, string FirstLineAddress, string SecoundLineAddress, string State, 
            string City, DateTime? DOB, string TaxID, string SSN,string OrganizationName, string OrgPhone, string OrgEMail)
        {
            string stripeApiKey = System.Configuration.ConfigurationManager.AppSettings["StripeApiKey"];
            StripeConfiguration.ApiKey = StripeApiKey;
            var bankAccountOptions = new AccountBankAccountOptions();
            bankAccountOptions.AccountHolderName = AccountName.Trim();
            bankAccountOptions.AccountNumber = AccountNumber.Trim();
            bankAccountOptions.RoutingNumber = RoutingNumber.Trim();
            bankAccountOptions.Country = "US";
            bankAccountOptions.Currency = "USD";
            bankAccountOptions.AccountHolderType = "company";
            var accountLegalEntityOptions = new AccountCompanyOptions();
            //  accountLegalEntityOptions.SSNLast4 = "0000";
            accountLegalEntityOptions.Phone = OrgPhone.Trim();// MobileNumber;
            //accountLegalEntityOptions.FirstName = FirstName.Trim();
            //accountLegalEntityOptions.LastName = LastName.Trim();
        
            accountLegalEntityOptions.Name = OrganizationName.Trim();// FirstName.Trim() + " " + LastName.Trim();
            accountLegalEntityOptions.TaxId = TaxID;// "000000000";
            var abc = new PersonCreateOptions();
            PersonRelationshipOptions relationship = new Stripe.PersonRelationshipOptions()
            {
                Owner = true,
                Title = "CEO",
                PercentOwnership = 100
            };

            AddressOptions addressOptions = new Stripe.AddressOptions()
            {
                Country = "US",
                State = State.Trim(),
                City = City.Trim(),
                PostalCode = PostelCode.Trim(),
                Line1 = FirstLineAddress.Trim(),
                Line2 = SecoundLineAddress.Trim()
            };
            var options1 = new TaxIdCreateOptions
            {
                Type = "us_ein"
                // , Value = "DE123456789",

            };

            
            accountLegalEntityOptions.Address = addressOptions;
            AccountTosAcceptanceOptions AAO = new AccountTosAcceptanceOptions();
            AAO.Ip = Iph.Utilities.Common.GetUserIp();
            AAO.Date = DateTime.Now;
        

            var accountOptions = new AccountCreateOptions()
            {
                Email = EmailID.Trim(),
                Type = "custom",//StripeAccountType.Custom,
                Country = "US",
                BusinessType = "company",
                ExternalAccount = bankAccountOptions,
                Company = accountLegalEntityOptions,
                TosAcceptance = AAO,
                RequestedCapabilities = new List<string>
                {
                  "card_payments",
                    "transfers",

                },



                BusinessProfile = new AccountBusinessProfileOptions
                {
                    Mcc = "8011", //dont rmeove this . let it be hardcoded only
                    ProductDescription = "myphysicianplan",//dont rmeove this . let it be hardcoded only
                },
            };
            var accountService = new AccountService();
            Stripe.Account account = accountService.Create(accountOptions);


            //create Account Representative
            var options = new PersonCreateOptions
            {
                FirstName = FirstName.Trim(),
                LastName = LastName.Trim(),
                Email = EmailID
               , SSNLast4 = SSN,// "0000",
            };
            AddressOptions addressOptionsC = new Stripe.AddressOptions()
            {
                Country = "US",
                State = State.Trim(),
                City = City.Trim(),
                PostalCode = PostelCode.Trim(),
                Line1 =FirstLineAddress.Trim(),
                Line2 = ""
            };
            options.Address = addressOptionsC;
            DateTime date1 = Convert.ToDateTime(DOB);
            var DobOptions = new DobOptions()
            {
                Day = date1.Day,
                Month = date1.Month,
                Year = date1.Year
            };
            options.Dob = DobOptions;
            PersonRelationshipOptions person = new PersonRelationshipOptions()

            {
                Representative = true,
                Executive = true,
                Director = true,
                Owner = true,
                PercentOwnership = 100,
                Title = "Manager"

            };
            options.Relationship = person;
            options.Phone = MobileNumber;

            var service = new PersonService();
            service.Create(account.Id, options);

            return account;
        }
    }
}