namespace webapi.Interfaсe
{
    public interface IStartStopSenderEmail
    {
        Task StopAsync(CancellationToken token = default);
        Task StartAsync(CancellationToken token = default);
    }
}
