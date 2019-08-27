using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace eFastFood_API.Util
{
    public static class EmailSender
    {
        static string EmailHost = "smtp.gmail.com";
        static int EmailPort = 587;
        static string EmailUsername = "restoran.testemail@gmail.com";
        static string EmailPassword = "ezg2#JyJ#D@gzJK78Lj&KGRr8";

        public static void SendEmail(string body, string emailTo)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailUsername);
            message.To.Add(emailTo);
            message.Subject = "Narudžba za Restoran eFastFood";
            message.IsBodyHtml = true;
            message.Body = body;
            message.Priority = MailPriority.High;


            SmtpClient smtpClient = new SmtpClient();
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Host = EmailHost;
            smtpClient.Port = EmailPort;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailUsername, EmailPassword);
            smtpClient.Send(message);
        }
    }
}