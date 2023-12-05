namespace DigitalCaesar.ServerSilencer.Service.Temperature;

public record Temperature
{
    private const decimal cValue = 0;
    private const TemperatureScale cScale = TemperatureScale.Celsius;
    private const char cDegreeSymbol = '\u00b0';
    public decimal Value { get; }
    public TemperatureScale Scale { get; }

    protected Temperature(decimal value = cValue, TemperatureScale scale = cScale)
    {
        Scale = scale;
        Value = value;
    }

    public static implicit operator decimal(Temperature value) => value.Value;

    public override string ToString() => $"{Value}{cDegreeSymbol}{(char)Scale}";
}