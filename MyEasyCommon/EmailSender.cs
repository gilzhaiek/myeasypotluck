using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace MyEasy.Common
{
    static public class EmailSender
    {
        public enum EEmailAccount
        {
            eEmailSupport,
            eEmailInvitation,
            eEmailReminder
        };

        static public void SendEmail(EEmailAccount emailAccount, string email, string subject, string body)
        {
            MailAddress from, to;
            if (EEmailAccount.eEmailInvitation == emailAccount)
            {
                from = new MailAddress("invite@myeasypotluck.com", "MyEasyPotluck");
                to = new MailAddress(email);
            }
            else if (EEmailAccount.eEmailSupport == emailAccount)
            {
                from = new MailAddress("support@myeasypotluck.com", "MyEasyPotluck");
                to = new MailAddress("myeasypotluck@gmail.com");
                body = "Email: " + email + "\n" + body;
            }
            else if (EEmailAccount.eEmailReminder == emailAccount)
            {
                from = new MailAddress("reminder@myeasypotluck.com", "MyEasyPotluck");
                to = new MailAddress(email);
            }
            else
            {
                return;
            }

            MailMessage mailMessage = new MailMessage(from, to);

            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = subject;
            mailMessage.Body = body;

            SmtpClient client = new SmtpClient("relay-hosting.secureserver.net");
            //SmtpClient client = new SmtpClient("smtp.secureserver.net");

            if (EEmailAccount.eEmailInvitation == emailAccount)
                client.Credentials = new System.Net.NetworkCredential("invite@myeasypotluck.com", "invite245go");
            else if (EEmailAccount.eEmailInvitation == emailAccount)
                client.Credentials = new System.Net.NetworkCredential("support@myeasypotluck.com", "support19go");
            else
                client.Credentials = new System.Net.NetworkCredential("reminder@myeasypotluck.com", "reminder452go");

            client.Port = 25;
            client.EnableSsl = false;
            client.Send(mailMessage);
        }
    }
}
