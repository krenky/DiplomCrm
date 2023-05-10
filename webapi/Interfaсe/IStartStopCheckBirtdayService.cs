namespace webapi.Interfaсe
{
    public interface IStartStopCheckBirtdayService
    {
        Task StopAsync(CancellationToken token = default);
        Task StartAsync(CancellationToken token = default);
    }
}
