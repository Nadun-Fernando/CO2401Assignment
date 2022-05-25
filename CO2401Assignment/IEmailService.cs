namespace CO2401Assignment;

public interface IEmailService
{
    void SendMail(string emailAddress, string subject, string message);
}