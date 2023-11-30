namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class TemperatureSensorPackage
{
    public TemperatureSensor Inlet { get; set; }
    public TemperatureSensor Exhaust { get; set; }
    public TemperatureSensor Cpu { get; set; }

    public TemperatureSensorPackage(TemperatureSensorPackageSettings settings)
    {
        Inlet = new(settings.Inlet);
        Exhaust = new(settings.Exhaust);
        Cpu = new(settings.Cpu);
    }
}