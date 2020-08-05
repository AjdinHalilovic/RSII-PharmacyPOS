//using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Pharmacy.Core.Helpers
{
    public class EmailHelper
    {
        #region Constants
        private static readonly string NoReplayEmail = "noreply@ema.health";
        private static readonly string NoReplayEmailPassword = "EmaHealth123!";
        private static string EmailHost = "smtp.ionos.com";
        private static int EmailPort = 587;
        private static readonly bool EmailEnableSSL = true;

        #endregion

        public static bool Send(string subject, string message, string emailFrom, string emailTo)
        {
            try
            {
                SmtpClient client = new SmtpClient()
                {
                    Port = EmailPort,
                    Host = EmailHost,
                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(NoReplayEmail, NoReplayEmailPassword),
                    EnableSsl = EmailEnableSSL
                };

                MailMessage mailMessage = new MailMessage(new MailAddress(emailFrom, "Ema Health"), new MailAddress(emailTo));
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static bool Send(string subject, string message, string emailTo)
        {
            try
            {
                string emailFrom = NoReplayEmail;

                SmtpClient client = new SmtpClient()
                {
                    Port = EmailPort,
                    Host = EmailHost,
                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailFrom, NoReplayEmailPassword),
                    EnableSsl = EmailEnableSSL
                };

                MailMessage mailMessage = new MailMessage(new MailAddress(emailFrom, "Ema Health"), new MailAddress(emailTo));
                mailMessage.Subject = subject;
                mailMessage.Body = message;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

                client.Send(mailMessage);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
