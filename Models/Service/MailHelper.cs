using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace PPCPWebApiServices.Models.Service
{
    public class MailHelper
    {
        readonly MailMessage _m = new MailMessage();
        readonly SmtpClient _sc = new SmtpClient();





        /// <summary>
        /// To Send Email to the User (by Gayathri.M on 18/04/2018)
        /// </summary>
        /// <param name="tolist"></param>
        /// <param name="cclist"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void SmtpMail(string tolist, string cclist, string subject, string body, string FromMail, string Password)
        {
            try
            {
                //string fromMail = "support@ihealthpay.co";
                _m.From = new MailAddress(FromMail, Convert.ToString("MyPhysicianPlan"));
                _m.ReplyTo = new MailAddress(Convert.ToString(FromMail));
                string[] validemails = ValidEmails(tolist);
                _m.To.Clear();
                foreach (var validemail in validemails.Where(validemail => validemail != null))
                {
                    _m.To.Add(new MailAddress(validemail, validemail));
                }
                _m.Subject = subject;
                _m.IsBodyHtml = true;
                _m.Body = body;

                // _m.Bcc.Add(new MailAddress(fromMail));
                _sc.Host = "smtp.1and1.com";
                _sc.Port = 587;
                _sc.UseDefaultCredentials = false;
                _sc.Credentials = new System.Net.NetworkCredential(FromMail, Password);
                _sc.EnableSsl = Convert.ToBoolean(Convert.ToInt32("1"));
                _sc.Send(_m);

            }
            catch (Exception ex)
            {
                //throw ex;
            }
        }
        /// <summary>
        /// To validate the Email (by Gayathri.M on 18/04/2018)
        /// </summary>
        /// <param name="validateList"></param>
        /// <returns></returns>
        private static string[] ValidEmails(string validateList)
        {
            var emails = new string[10];
            int i = 0;
            var validationExpression = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            MatchCollection matchCollection = validationExpression.Matches(validateList);
            foreach (var matchedEmailAddress in matchCollection)
            {
                emails[i] = matchedEmailAddress.ToString();
                i += 1;
            }
            return emails;


        }
    }
}