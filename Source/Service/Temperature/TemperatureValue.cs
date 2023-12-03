using DigitalCaesar.Results;

namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public sealed record TemperatureValue : Temperature
{
    private const int DefaultValue = 0;
    private const TemperatureScale DefaultScale = TemperatureScale.Celsius;
//    private readonly TemperatureRange _range;
    //private readonly int _value;
    //public int Value { get; }
    //public TemperatureScale Scale { get; }

    private TemperatureValue(int temperature, TemperatureScale scale) : base(temperature, scale) {}
    //{
    //    Value = temperature;
    //    Scale = scale;
    //}

    public static Result<TemperatureValue> Create(int temperature = DefaultValue, TemperatureScale scale = DefaultScale)
    {
        //TemperatureScale Scale = scale ?? DefaultScale;
        TemperatureRange? range = scale switch
        {
            TemperatureScale.Celsius => TemperatureRange.Celsius,
            TemperatureScale.Fahrenheit => TemperatureRange.Fahrenheit,
            TemperatureScale.Kelvin => TemperatureRange.Kelvin,
            _ => null //throw TemperatureException.ThrowScaleException(scale),
        };

        if (range is null)
            return TemperatureException.ThrowScaleException(scale);

        if (temperature < range.Minimum || temperature > range.Maximum)
            return TemperatureException.ThrowValueOutOfRangeException(temperature, range);

        return new TemperatureValue(temperature, scale);
    }

    public static implicit operator int(TemperatureValue temperatureValue) => (int)temperatureValue.Value;
    //public static explicit operator TemperatureValue(int temperature) => Create(temperature).Match(
    //    (success) => success, 
    //    (failure) => throw new ArgumentException(failure.ToString()));

    public override string ToString() => $"{Value}°{(char)Scale}";
}