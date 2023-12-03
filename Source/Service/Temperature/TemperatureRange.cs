namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public class TemperatureRange
{
    private const int DefaultMinimum = -100;
    private const int DefaultMaximum = 100;

    public TemperatureRange(int minimum = DefaultMinimum, int maximum = DefaultMaximum)
    {
        if(minimum > maximum)
            throw TemperatureException.ThrowRangeException(minimum, maximum);

        Minimum = minimum;
        Maximum = maximum;
    }

    public int Minimum { get; }
    public int Maximum { get; }

    public static TemperatureRange Celsius => new(-273, 273);
    public static TemperatureRange Fahrenheit => new(-460, 460);
    public static TemperatureRange Kelvin => new(0, 546);
}