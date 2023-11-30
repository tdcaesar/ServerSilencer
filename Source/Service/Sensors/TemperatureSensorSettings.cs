namespace DigitalCaesar.ServerSilencer.Service.Sensors;

//public record TemperatureSensorSettings(string[] Ids, int Minimum, int Maximum);

public class TemperatureSensorSettings
{
    public List<string> Ids { get; set; }
    public int Minimum { get; set;  } 
    public int Maximum { get; set; }

    public TemperatureSensorSettings()
    {
        Ids = new(); 
        Minimum = 0;
        Maximum = 0;
    }
    public TemperatureSensorSettings(string[] ids, int minimum, int maximum)
    {
        Ids = new List<string>(ids);
        Minimum = minimum;
        Maximum = maximum;
    }
}