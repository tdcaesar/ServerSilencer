namespace DigitalCaesar.ServerSilencer.Service.Sensors;

[Serializable]
public class TemperatureSensorException : Exception
{
    public TemperatureSensorException() : base("There was a problem with the Temperature Sensor.")
    {
    }
    public TemperatureSensorException(string message)
        : base(message)
    {
    }
    public TemperatureSensorException(string message, Exception inner)
        : base(message, inner)
    {
    }

    public static TemperatureSensorException ThrowOutOfRangeException(int minimum, int maximum)
    {
        string message = $"The minimum value {minimum} must be less than the {maximum} value.";
        return new TemperatureSensorException(message);
    }

}