namespace EmailService;

public interface IEmailSender
{
    void SendEmail(Email email, string? Password);
}
