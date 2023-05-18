using MailKit.Net.Smtp;
using MimeKit;
using webapi.Interfaсe;
using webapi.Models;

namespace webapi.Services
{
    public class EmailService : IEmailService
    {
        private readonly ISmtpClient smtpClient;
        private readonly IConfiguration _configuration;
        private readonly IEmailMessageService _messageService;
        private string host;
        private int port;
        private bool useSsl;
        private string login;
        private string password;

        public EmailService(ISmtpClient smtpClient, IConfiguration configuration, IEmailMessageService messageService)
        {
            this.smtpClient = smtpClient;
            _configuration = configuration;
            host = _configuration["EmailClient:host"];
            port = Convert.ToInt32(_configuration["EmailClient:port"]);
            useSsl = Convert.ToBoolean(_configuration["EmailClient:UseSsl"]);
            login = _configuration["EmailClient:login"];
            password = _configuration["EmailClient:password"];
            _messageService = messageService;
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            using var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", login));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message
            };
            await smtpClient.DisconnectAsync(false);
            await ConnectAsync();

            await smtpClient.SendAsync(emailMessage);

            await smtpClient.DisconnectAsync(false);
        }
        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            try
            {
                await SendEmailAsync(emailMessage.Destination, emailMessage.Subject, emailMessage.Message);
                emailMessage.IsSend = true;
                _messageService.ChangeEmailMessage(emailMessage);
            }
            catch
            {
                throw;
            }
        }
        private async Task ConnectAsync()
        {
            await smtpClient.ConnectAsync(host, port, useSsl);
            //await smtpClient.AuthenticateAsync(login, password);
        }
    }
}
