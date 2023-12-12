namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class TemperatureSensor
{
    public List<SensorId> Ids { get; }
    public int Minimum { get; }
    public int Maximum { get; }
    public bool HasSensors => Ids.Count > 0;

    public TemperatureSensor(TemperatureSensorSettings settings)
    {
        Ids = new();
        foreach (string inletId in settings.Ids)
        {
            SensorId currentId = SensorId.Create(inletId);
            Ids.Add(currentId);
        }

        if (settings.Minimum > settings.Maximum)
            throw TemperatureSensorException.ThrowOutOfRangeException(Minimum, Maximum);
        
        Minimum = settings.Minimum;
        Maximum = settings.Maximum;
    }
}