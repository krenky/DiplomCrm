using Microsoft.EntityFrameworkCore;
using webapi.Data;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class EmailMessageService : IEmailMessageService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public EmailMessageService(ApplicationDbContext context, ILogger<EmailMessageService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<EmailMessage> AddEmailMessage(EmailMessage emailMessage)
        {
            try
            {
                EmailMessage message = _context.EmailMessages.Add(emailMessage).Entity;
                _context.SaveChanges();
                return message;
            }
            catch
            {
                _logger.LogError("Сообщение не добавлено", emailMessage);
                throw;
            }
        }

        public async Task<EmailMessage> ChangeEmailMessage(EmailMessage emailMessage)
        {
            if (emailMessage.Id == 0)
            {
                throw new ArgumentException("Id письма не может быть равен 0", "customer.Id");
            }

            if (!_context.EmailMessages.Find(emailMessage.Id).IsSend)
            {
                _context.Entry(emailMessage).State = EntityState.Modified;
            }
            try
            {
                await _context.SaveChangesAsync();
                
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailMessageExists(emailMessage.Id))
                {
                    throw new Exception("Письмо не найдено");
                }
                else
                {
                    throw;
                }
            }

            return emailMessage;
        }

        public async Task DeleteEmailMessage(int Id)
        {
            EmailMessage message = _context.EmailMessages.Find(Id);
            if(message == null)
                throw new Exception("Письмо не найдено");

            if (!_context.EmailMessages.Find(Id).IsSend)
            {
                _context.EmailMessages.Remove(message);
                _context.SaveChanges();
            }
        }

        public async Task<EmailMessage> GetEmailMessage(int Id)
        {
            EmailMessage message = _context.EmailMessages.Find(Id);
            if (message == null)
                throw new Exception("Письмо не найдено");
            return message;
        }

        public async Task<List<EmailMessage>> GetEmailMessages()
        {
            return _context.EmailMessages.ToList();
        }

        public async Task<List<EmailMessage>> GetUnSendEmailMessages()
        {
            return _context.EmailMessages.Where(x => x.IsSend == false).ToList();
        }

            private bool EmailMessageExists(int id)
        {
            return (_context.EmailMessages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
