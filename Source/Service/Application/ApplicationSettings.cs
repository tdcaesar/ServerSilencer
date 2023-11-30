using DigitalCaesar.ServerSilencer.Service.Ipmi;
using DigitalCaesar.ServerSilencer.Service.Sensors;

namespace DigitalCaesar.ServerSilencer.Service.Application;

public class ApplicationSettings
{
    private const int DefaultPollingIntervalInSeconds = 60;

    public int PollingIntervalInSeconds { get; set;  } = DefaultPollingIntervalInSeconds;

    public TemperatureSensorPackageSettings TemperatureSensors { get; set; } = new ();
    public IpmiCommandSettings IpmiCommand { get; set; } = new();
}