namespace DigitalCaesar.ServerSilencer.Service.Ipmi;

public class IpmiLogger
{
    private readonly ILogger? _logger;

    public IpmiLogger(ILogger? logger)
    {
        _logger = logger;
    }

    public void LogError(string process, string args, int retries, TimeSpan delay)
    {
        _logger?.LogError(
            "The Process {process} with args {args} threw an exception. Trying next of {retries} attempt(s) after {delay} delay.",
            process,
            args,
            retries,
            delay);
    }

    public void LogError(Exception exception, string command)
    {
        _logger?.LogError(exception, "Failed to process command '{0}'.", command);
    }
}