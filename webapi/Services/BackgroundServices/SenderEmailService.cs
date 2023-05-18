using webapi.Interfaсe;
using webapi.Models.Enum;
using webapi.Models;

namespace webapi.Services.BackgroundServices
{
    public class SenderEmailService: BackgroundService, IStartStopSenderEmail
    {
        private readonly ILogger<SenderEmailService> _logger;
        private IEmailMessageService _emailMessageService;
        private IEmailService _emailService;
        private IServiceScopeFactory _serviceScopeFactory;
        private TimeSpan _interval = TimeSpan.FromMinutes(1);
        private IConfiguration _configuration;


        public SenderEmailService(ILogger<SenderEmailService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            var scope = _serviceScopeFactory.CreateScope();
            _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
            _emailMessageService = scope.ServiceProvider.GetRequiredService<IEmailMessageService>();
            _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            _interval = _configuration["SenderEmail:interval"] == null ?
                _interval :
                new TimeSpan(0, Convert.ToInt32(_configuration["SenderEmail:interval"]), 0);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            

            _logger.LogInformation("Сервис рассылки почты начал работать");
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    List<EmailMessage> emailMessages = await _emailMessageService.GetUnSendEmailMessages();
                    foreach (EmailMessage message in emailMessages)
                    {
                        await _emailService.SendEmailAsync(message);
                    }
                    _logger.LogInformation($"Отправлено {emailMessages.Count} писем");
                    await Task.Delay(_interval, stoppingToken);
                }
                catch(Exception ex)
                {
                    //_logger.LogError(ex,"неудачная оправка письма");
                }
            }
        }

        async Task IStartStopSenderEmail.StopAsync(CancellationToken token = default)
        {
            await base.StopAsync(token);
        }
    }
}
