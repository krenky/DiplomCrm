using webapi.Models;

namespace webapi.Interfaсe
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}