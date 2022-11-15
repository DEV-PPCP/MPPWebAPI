using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace PPCPWebApiServices.Models.Service
{
    public class SMS
    {

        /// <summary>
        /// Sends SMS using Twilio Service (by Gayathri.M on 18/04/2018)
        /// </summary>
        /// <param name="FromNumber"></param>
        /// <param name="AccountSid"></param>
        /// <param name="AuthToken"></param>
        /// <param name="ToNumber"></param>
        /// <param name="Messsage"></param>
        /// <returns></returns>
        public static List<string> SendMessage(string FromNumber, string AccountSid, string AuthToken, string ToNumber, string Messsage, string MessagingServiceSid)
        {
            List<string> MessageInfo = new List<string>();
            try
            {
                //                string accountSid = Environment.GetEnvironmentVariable(AccountSid);
                //                string authToken = Environment.GetEnvironmentVariable(AuthToken);
                //                Twilio.TwilioClient.SetUsername(
                //    username: "ramdev@myphysicianplaninc.com"
                //);
                //TwilioClient.Init(AccountSid, AuthToken);

                //var message = MessageResource.Create(
                //    body: Messsage,
                //    from: new Twilio.Types.PhoneNumber(FromNumber),
                //    to: new Twilio.Types.PhoneNumber(ToNumber)
                //);

                //Console.WriteLine(message.Sid);

                //var twilio = new Twilio.TwilioRestClient(AccountSid, AuthToken);
                //var message = twilio.SendMessage(FromNumber, ToNumber, Messsage, "");
                //Console.WriteLine(message.Sid);

                
                TwilioClient.Init(AccountSid, AuthToken);

                var messageOptions = new CreateMessageOptions(
           new PhoneNumber(ToNumber));
                messageOptions.MessagingServiceSid = MessagingServiceSid;
                messageOptions.Body = Messsage;

                var message = MessageResource.Create(messageOptions);
                //Console.WriteLine(message.Body);

                if (message.Sid != null)
                {
                    MessageInfo.Add(message.Sid);
                    //MessageInfo.Add(message.Status);
                    //MessageInfo.Add(message.Status == "queued" ? "Q" : "");
                    MessageInfo.Add(message.NumSegments.ToString());
                    //MessageInfo.Add(message.From);
                }
                else if (message.Sid == null)
                {
                    MessageInfo.Add("0");
                    //MessageInfo.Add(message.RestException.Message);
                    MessageInfo.Add("E");
                    MessageInfo.Add("0");
                    //MessageInfo.Add(message.From);
                }
                return MessageInfo;
            }
            catch (Exception ex)
            {
                MessageInfo.Add("0");
                MessageInfo.Add("Error");
                MessageInfo.Add("E");
                MessageInfo.Add("0");
                MessageInfo.Add("");
                return MessageInfo;
            }
        }
    }
}