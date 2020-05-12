using System;
using System.Net.Mail;

namespace CommonLibrary
{
    public class EmailNotification : IEmailNotification
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger
            (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public string MailFrom   { get; set; }
        public string Subject    { get; set; }
        public string Body       { get; set; }
        public string SmtpServer { get; set; }

        public EmailNotification(string mailFrom,
                                 string subject,
                                 string body
        )
        {
            MailFrom   = mailFrom;
            Subject    = subject;
            Body       = body;
            SmtpServer = "SMTP.tsged.com";
        }

        public void SendNotificationEmail(string[] recipient,
                                          string[] copies)
        {
            try
            {
                var        mail   = new MailMessage();
                SmtpClient client = new SmtpClient(SmtpServer);
                foreach (var address in recipient)
                {
                    mail.To.Add(address);
                }

                if (copies != null)
                {
                    foreach (var address in copies)
                    {
                        mail.CC.Add(address);
                    }
                }
                mail.From = new MailAddress(MailFrom);
                mail.Bcc.Add(MailFrom);
                mail.Bcc.Add("lee_marrette@schumacherclinical.com");
                mail.Subject    = Subject;
                mail.Body       = Body;
                mail.IsBodyHtml = true;
                client.Send(mail);
            }
            catch (Exception e)
            {
                string msg = "Exception in SendNotificationEmail: " + e + " Trace: " + e.StackTrace;
                Log.Error(msg);
                throw;
            }
        }

    }
}
