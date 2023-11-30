namespace DigitalCaesar.ServerSilencer.Service.Application;

public class ApplicationLogger
{
    private const string StartMessage = "Log Service started at: {time}.";
    private const string NormalStopMessage = "Log Service stopped at {0} after running for {1} days.";
    private const string DurationFormat = @"dd\.hh\:mm\:ss";
    private readonly ILogger? _logger;
    private DateTime _logStartTime;

    public ApplicationLogger(ILogger? logger)
    {
        _logger = logger;
    }
    
    public void LogStart()
    {
        _logStartTime = DateTime.Now;
        _logger?.LogInformation(StartMessage, _logStartTime);
    }

    public void LogStopNormal()
    {
        DateTime logEndTime = DateTime.Now;
        TimeSpan logDuration = logEndTime - _logStartTime;
        

        _logger?.LogInformation(NormalStopMessage, logEndTime.ToLongDateString(), logDuration.ToString(DurationFormat));
    }
}