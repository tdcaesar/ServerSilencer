namespace DigitalCaesar.ServerSilencer.Service;

public class Worker : BackgroundService
{
    private readonly ApplicationLogger _logger;
    private readonly int _pollingIntervalInMilliseconds;

    public Worker(ILogger<Worker> logger, ApplicationSettings settings)
    {
        _logger = new(logger);
        _pollingIntervalInMilliseconds = settings.PollingIntervalInSeconds * 1000;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogStart();
            await Task.Delay(_pollingIntervalInMilliseconds, stoppingToken);
        }
    }
}
