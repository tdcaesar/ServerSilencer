namespace DigitalCaesar.ServerSilencer.Service.Temperature;
[Serializable]
public class TemperatureException : Exception
{
    public TemperatureException() { }
    public TemperatureException(string message) : base(message) { }
    public TemperatureException(string message, Exception inner) : base(message, inner) { }

    public static TemperatureException ThrowValueOutOfRangeException(int temperature, TemperatureRange range)
    {
        string message = $"TemperatureValue Thresholds {temperature} must be between {range.Minimum} and {range.Maximum}.";
        return new TemperatureException(message);
    }
    public static TemperatureException ThrowRangeException(int minimum, int maximum) 
    {
        string message = $"Minimum {minimum} must be less than Maximum {maximum}.";
        return new TemperatureException(message);
    }

    public static TemperatureException ThrowScaleException(TemperatureScale? scale)
    {
        string message = $"TemperatureValue Scale {scale} is not supported.";
        return new TemperatureException(message);
    }
}