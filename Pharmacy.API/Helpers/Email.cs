using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;

namespace Pharmacy.Api.Mobile.Helpers
{
    public class Email
    {
        public static bool Send(string subject, string message, string emailFrom, string emailTo,
            IConfiguration configuration)
        {
            try
            {
                SmtpClient client = new SmtpClient
                {
                    Port = int.Parse(configuration["NoReplayEmailSettings:EmailPort"]),
                    Host = configuration["NoReplayEmailSettings:EmailHost"],
                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(configuration["NoReplayEmailSettings:NoReplayEmail"],
                        configuration["NoReplayEmailSettings:NoReplayEmailPassword"]),
                    EnableSsl = bool.Parse(configuration["NoReplayEmailSettings:EmailEnableSSL"])
                };

                MailMessage mailMessage =
                    new MailMessage(new MailAddress(emailFrom, "Ema Health"), new MailAddress(emailTo));
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

        public static bool Send(string subject, string message, string emailTo, IConfiguration configuration)
        {
            try
            {
                string emailFrom = configuration["NoReplayEmailSettings:NoReplayEmail"];

                SmtpClient client = new SmtpClient
                {
                    Port = int.Parse(configuration["NoReplayEmailSettings:EmailPort"]),
                    Host = configuration["NoReplayEmailSettings:EmailHost"],
                    Timeout = 100000,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(emailFrom,
                        configuration["NoReplayEmailSettings:NoReplayEmailPassword"]),
                    EnableSsl = bool.Parse(configuration["NoReplayEmailSettings:EmailEnableSSL"])
                };

                MailMessage mailMessage =
                    new MailMessage(new MailAddress(emailFrom, "Ema Health"), new MailAddress(emailTo));
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