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
            SensorId currentId = new(inletId);
            Ids.Add(currentId);
        }

        if (settings.Minimum > settings.Maximum)
            throw new TemperatureSensorException(Minimum, Maximum);
        
        Minimum = settings.Minimum;
        Maximum = settings.Maximum;
    }
}