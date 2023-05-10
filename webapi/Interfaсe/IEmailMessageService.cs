using webapi.Models;

namespace webapi.Interfaсe
{
    public interface IEmailMessageService
    {
        Task<EmailMessage> AddEmailMessage(EmailMessage emailMessage);
        Task DeleteEmailMessage(int Id);
        Task<EmailMessage> ChangeEmailMessage(EmailMessage emailMessage);
        Task<List<EmailMessage>> GetEmailMessages();
        Task<EmailMessage> GetEmailMessage(int id);
        Task<List<EmailMessage>> GetUnSendEmailMessages();
    }
}
