using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace eFastFood_API.Util
{
    public static class EmailSender
    {
        //treba napravit email za slanje emailova
        static string EmailAdress = "";
        static string EmailHost = "";
        static int EmailPort = 0;
        static string EmailUsername = "";
        static string EmailPassword = "";

        public static void SendEmail(string body, string emailTo)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(EmailAdress);
            message.To.Add(emailTo);
            message.Subject = "Narudžba za Restoran eFastFood";
            message.IsBodyHtml = true;
            message.Body = body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Host = EmailHost;
            smtpClient.Port = EmailPort;
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailUsername, EmailPassword);
            smtpClient.Send(message);
        }
    }
}