namespace DigitalCaesar.ServerSilencer.Service.Sensors;

public class TemperatureSensorException : Exception
{
    public TemperatureSensorException(int minimum, int maximum)
        : base($"The minimum value {minimum} must be less than the {maximum} value.")
    {
    }

}