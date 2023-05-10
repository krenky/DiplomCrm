using Microsoft.AspNetCore.Mvc;
using webapi.Interfaсe;
using webapi.Services.BackgroundServices;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackgroundServiceController : ControllerBase
    {
        private IStartStopCheckBirtdayService _startStopCheckBirthday;
        private IStartStopSenderEmail _startStopSenderEmail;

        public BackgroundServiceController(IStartStopCheckBirtdayService startStopBackground, IStartStopSenderEmail startStopSenderEmail)
        {
            _startStopCheckBirthday = startStopBackground;
            _startStopSenderEmail = startStopSenderEmail;
        }

        [HttpPost]
        public async Task StopService()
        {
            await _startStopCheckBirthday.StopAsync();
            await _startStopSenderEmail.StopAsync();
            //_lifetime.StopApplication();
            //CancellationTokenSource cancelTokenSource = new CancellationTokenSource();
            //CancellationToken token = cancelTokenSource.Token;
            //await _checkBirthdayBoyService.StopAsync(token);
            //await _enderEmailService.StopAsync(token);
        }
    }
}
