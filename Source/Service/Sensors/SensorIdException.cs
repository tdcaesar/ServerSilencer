namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class SensorIdException : Exception
{
    public SensorIdException(int value) 
        : base(String.Format($"The Sensor Id '{value}' but be between 0 (0x00) and 255 (0xff)."))
    {
    }

    public SensorIdException()
        : base(string.Format($"The Sensor Id cannot be null or empty."))
    {
    }
}