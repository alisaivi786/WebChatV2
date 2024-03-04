namespace EmailService;

public class EmailService(IEmailSender emailSender)
{
    private readonly IEmailSender _emailSender = emailSender;

    public void SendEmail(string FilePath,string Subject = "ARM SMTP Service", string BodyMessage= "Test Body",string SenderEmail = "alisaivi786@gmail.com", string RecipientEmail = "alisaivi786@gmail.com")
    {
        var email = new Email
        {
            SenderEmail = $"{SenderEmail}",
            RecipientEmail = $"{RecipientEmail}",
            Subject = $"{Subject}",
            Body = $"{BodyMessage}",
            AttachmentPath = $"{FilePath}"
        };

        _emailSender.SendEmail(email,null);
    }
}
