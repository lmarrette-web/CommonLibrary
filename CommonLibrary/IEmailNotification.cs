namespace CommonLibrary
{
    public interface IEmailNotification
    {
        string MailFrom { get; set; }
        string Subject { get; set; }
        string Body { get; set; }
        string SmtpServer { get; set; }

        void SendNotificationEmail(string[] recipient,
                                   string[] copies);
    }
}