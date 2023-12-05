using DigitalCaesar.Results;

namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public sealed record TemperatureValue : Temperature
{
    private const int cValue = 0;
    private const TemperatureScale cScale = TemperatureScale.Celsius;

    private TemperatureValue(int temperature, TemperatureScale scale) : base(temperature, scale) {}

    public static Result<TemperatureValue> Create(int temperature = cValue, TemperatureScale scale = cScale, TemperatureRange? range = null)
    {
        if(range is not null)
            if (temperature < range.Minimum || temperature > range.Maximum)
                return TemperatureException.ThrowValueOutOfRangeException(temperature, range);

        return new TemperatureValue(temperature, scale);
    }

    public static implicit operator int(TemperatureValue temperatureValue) => (int)temperatureValue.Value;

    public override string ToString() => $"{Value}°{(char)Scale}";
}