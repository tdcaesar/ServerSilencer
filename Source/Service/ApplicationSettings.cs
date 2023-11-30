namespace DigitalCaesar.ServerSilencer.Service;

public class ApplicationSettings
{
    private const int DefaultPollingIntervalInSeconds = 60;

    public int PollingIntervalInSeconds { get; } = DefaultPollingIntervalInSeconds;
}