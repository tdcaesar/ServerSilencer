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

    public void Start()
    {
        _logger.LogStart();
    }

    public async Task<bool> Wait(CancellationToken cancellationToken)
    {
        await Task.Delay(_pollingIntervalInMilliseconds, cancellationToken);
        return true;
    }

    public void Stop()
    {
        _logger.LogStopNormal();
    }

    public async Task Run(CancellationToken cancellationToken)
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
    }
}