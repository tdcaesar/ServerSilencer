namespace DigitalCaesar.ServerSilencer.Service.Application;

public class ApplicationLogger
{
    private const string cStartMessage = "Log Service started at: {time}.";
    private const string cNormalStopMessage = "Log Service stopped at {0} after running for {1} days.";
    private const string cDurationFormat = @"dd\.hh\:mm\:ss";
    private readonly ILogger? _logger;
    private DateTime _logStartTime;

    public ApplicationLogger(ILogger? logger)
    {
        _logger = logger;
    }
    
    public void LogStart()
    {
        _logStartTime = DateTime.Now;
        _logger?.LogInformation(cStartMessage, _logStartTime);
    }

    public void LogStopNormal()
    {
        DateTime logEndTime = DateTime.Now;
        TimeSpan logDuration = logEndTime - _logStartTime;
        

        _logger?.LogInformation(cNormalStopMessage, logEndTime.ToLongDateString(), logDuration.ToString(cDurationFormat));
    }
}