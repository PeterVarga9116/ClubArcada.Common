using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace ClubArcada.Common.Mailer
{
    public class Mailer
    {
        public static async void SendMailAsync(MailObject mail)
        {
            Action send = () =>
            {
                var message = GetMessage(mail);

                var smtp = new SmtpClient(mail.SmtpClient, mail.Port);
                smtp.Credentials = new System.Net.NetworkCredential(mail.UserName, mail.Password);

                smtp.Send(message);
            };

            await Task.Run(send);
        }

        public static void SendMail(MailObject mail)
        {
            var message = GetMessage(mail);

            var smtp = new SmtpClient(mail.SmtpClient, mail.Port);
            smtp.Credentials = new System.Net.NetworkCredential(mail.UserName, mail.Password);

            smtp.Send(message);
        }

        public static void SendErrorMail(string subject, string message)
        {
            var errorMail = new Common.Mailer.MailObject()
            {
                Subject = subject,
                Body = message,
                To = "petervarga@arcade-group.sk".CreateList(),
                From = "service@arcade-group.sk",
                Password = "vape6931",
                SmtpClient = "smtp.websupport.sk",
                Port = 25,
                UserName = "service@arcade-group.sk"
            };

            SendMail(errorMail);
        }

        private static MailMessage GetMessage(MailObject mail)
        {
            var message = new MailMessage();

            mail.To.ForEach(to => message.To.Add(to));

            if (mail.CC.IsNotNull())
                mail.CC.ForEach(cc => message.CC.Add(cc));

            message.From = message.Sender = new MailAddress(mail.From);
            message.Subject = mail.Subject;
            message.Body = mail.Body;

            if (mail.Attachment != null)
                message.Attachments.Add(new Attachment(mail.Attachment, mail.AttachmentName));

            return message;
        }
    }

    public class MailObject
    {
        public string SmtpClient { get; set; }

        public int Port { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string From { get; set; }

        public List<string> To { get; set; }

        public List<string> CC { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string AttachmentName { get; set; }

        public Stream Attachment { get; set; }
    }
}