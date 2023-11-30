namespace DigitalCaesar.ServerSilencer.Service.Sensors;

//public record TemperatureSensorsSettings(TemperatureSensorSettings Inlet, TemperatureSensorSettings Exhaust, TemperatureSensorSettings Cpu);
public class TemperatureSensorPackageSettings
{
    public TemperatureSensorSettings Inlet { get; set; } = new();
    public TemperatureSensorSettings Exhaust { get; set;  } = new();
    public TemperatureSensorSettings Cpu { get; set;  } = new();

}