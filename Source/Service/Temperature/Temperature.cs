namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public class Temperature
{
    private const decimal DefaultValue = 0;
    private const TemperatureScale DefaultScale = TemperatureScale.Celsius;
    public decimal Value { get; }
    public TemperatureScale Scale { get; }

    public Temperature(decimal value = DefaultValue, TemperatureScale scale = DefaultScale)
    {
        Scale = scale;
        Value = value;
    }

    public static implicit operator decimal(Temperature value) => value.Value;

    public override string ToString() => $"{Value}\u00b0{(char)Scale}";
}