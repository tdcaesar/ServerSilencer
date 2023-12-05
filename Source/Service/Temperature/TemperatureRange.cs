namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public class TemperatureRange
{
    private const int cMinimum = -100;
    private const int cMaximum = 100;

    public int Minimum { get; }
    public int Maximum { get; }

    public TemperatureRange(int minimum = cMinimum, int maximum = cMaximum)
    {
        if(minimum > maximum)
            throw TemperatureException.ThrowRangeException(minimum, maximum);

        Minimum = minimum;
        Maximum = maximum;
    }

    public static TemperatureRange Default => new();
}