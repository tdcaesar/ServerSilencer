using DigitalCaesar.Results;

namespace DigitalCaesar.ServerSilencer.Service.Application;

public class ServiceController
{
    private readonly ApplicationLogger _logger;
    private readonly int _pollingIntervalInMilliseconds;
    
    public ServiceController(ILogger<ServiceController> logger, ApplicationSettings settings)
    {
        _logger = new(logger);
        _pollingIntervalInMilliseconds = settings.PollingIntervalInSeconds * 1000;
    }

    public Result Start()
    {
        _logger.LogStart();
        return true;
    }

    public async Task<bool> Wait(CancellationToken cancellationToken)
    {
        await Task.Delay(_pollingIntervalInMilliseconds, cancellationToken);
        return true;
    }

    public Result Stop()
    {
        _logger.LogStopNormal();
        return true;
    }

    public async Task<Result> Run(CancellationToken cancellationToken)
    {
        // Retrieve Temperatures
        // Check if Automated Control
        //   Yes = Exit
        // Get Fan Speeds
        // Set Fan Speeds
        
        // TemperatureSensors
        //  TemperatureSensor
        //   ID
        //   Type
        return true;
    }
}