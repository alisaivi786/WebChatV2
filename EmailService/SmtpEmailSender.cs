namespace EmailService;

public class SmtpEmailSender : IEmailSender
{
    public void SendEmail(Email email, string? Password)
    {
        using MailMessage mail = new (email.SenderEmail, email.RecipientEmail);
        mail.Subject = email.Subject;
        mail.Body = email.Body;

        if (!string.IsNullOrEmpty(email.AttachmentPath) && File.Exists(email.AttachmentPath))
        {
            Attachment attachment = new(email.AttachmentPath);
            mail.Attachments.Add(attachment);
        }


        using SmtpClient smtpClient = new ("smtp.gmail.com");
        smtpClient.Port = 587;
        smtpClient.Credentials = new NetworkCredential(email.SenderEmail, "sdkt qbqs ljnu nrat");
        smtpClient.EnableSsl = true;

        try
        {
            smtpClient.Send(mail);
            Console.WriteLine("Email sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to send email. Error: {ex.Message}");
        }
    }
}
