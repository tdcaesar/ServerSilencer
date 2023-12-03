namespace DigitalCaesar.ServerSilencer.Service.Sensors;

[Serializable]
public class SensorIdException : Exception
{
    public SensorIdException() : base("There was a problem with the Sensor Id.")
    {
    }
    public SensorIdException(string message) 
        : base(message)
    {
    }
    public SensorIdException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public static SensorIdException ThrowOutOfRangeException(int value, int minimum, int maximum)
    {
        string minimumInHex = string.Format($"0x{minimum:X2}");
        string maximumInHex = string.Format($"0x{maximum:X2}");
        string message = string.Format($"The Sensor Id '{value}' but be between {minimum} ({minimumInHex}) and {maximum} ({maximumInHex}).");
        return new SensorIdException(message);
    }

    public static SensorIdException ThrowNullException()    
    {
        string message = string.Format($"The Sensor Id cannot be null or empty.");
        return new SensorIdException(message);
    }
}