using webapi.Interfaсe;
using webapi.Models;
using webapi.Models.Enum;

namespace webapi.Services.BackgroundServices
{
    public class CheckBirthdayBoyService: BackgroundService, IStartStopCheckBirtdayService
    {
        private ILogger<CheckBirthdayBoyService> _logger;
        private IEmailMessageService _emailMessageService;
        private ICustomerService _customerService;
        private IEmailService _emailService;
        private IServiceScopeFactory _serviceScopeFactory;
        private IConfiguration _configuration;
        private TimeSpan _interval = TimeSpan.FromMinutes(1);
        

        public CheckBirthdayBoyService(ILogger<CheckBirthdayBoyService> logger, IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;

            var scope = _serviceScopeFactory.CreateScope();
            _logger = logger;
            _configuration = scope.ServiceProvider.GetRequiredService<IConfiguration>();
            _emailService = scope.ServiceProvider.GetRequiredService<IEmailService>();
            _customerService = scope.ServiceProvider.GetRequiredService<ICustomerService>();
            _emailMessageService = scope.ServiceProvider.GetRequiredService<IEmailMessageService>();
            _interval = _configuration["CheckBirthdayBoy:interval"] == null ? 
                _interval : 
                new TimeSpan(0,Convert.ToInt32(_configuration["CheckBirthdayBoy:interval"]), 0);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation($@"Сервис начал рассылку поздравлений
Период проверки : {_interval.Minutes} Мин") ;
                List<Customer> customers = await _customerService.GetBirthdayBoy();
                _logger.LogDebug($"Колличетсво именинников {customers.Count}");
                foreach (Customer customer in customers)
                {
                    EmailMessage message = new EmailMessage()
                    {
                        Subject = "Поздравление с Днем Рождения!",
                        Message = $@"Добрый день, {customer.FirstName } {customer.LastName}!!! Сегодня замечательный день и мы хотим вас поздравить с днем рождения.
В честь это мы зачислим на ваш счет бонус в размере 500 баллов.

P.S. 1 балл = 1 руб",
                        Type = TypeEmailMessage.birthday,
                        Destination = customer.Email
                    };
                    _emailMessageService.AddEmailMessage(message);
                }
                _logger.LogInformation($"{customers.Count} писем добалвено в очередь на отправку", DateTimeOffset.Now);
                await Task.Delay(_interval, stoppingToken);
            }
        }
        async Task IStartStopCheckBirtdayService.StopAsync(CancellationToken token = default)
        {
            await base.StopAsync(token);
        }
    }
}
