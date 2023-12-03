using DigitalCaesar.ServerSilencer.Service.Temperature;
using DigitalCaesar.Results;

namespace DigitalCaesar.ServerSilencer.Service.Converters;

public static class TemperatureConverter
{
    public static Result<TemperatureValue> To(TemperatureScale fromScale, int temperature, TemperatureScale toScale)
    {
        TemperatureValue testValue = TemperatureValue.Create(temperature, fromScale).Match(
            (success) => success,
            (failure) => throw new ArgumentException(failure.ToString()));
        return To(testValue, toScale);
    }

    public static Result<TemperatureValue> To(TemperatureValue temperature, TemperatureScale scale)
    {
        return temperature.Scale switch
        {
            TemperatureScale.Celsius =>  scale switch
            {
                TemperatureScale.Celsius => temperature,
                TemperatureScale.Fahrenheit =>
                    TemperatureValue.Create(
                        ToFahrenheitFromCelsius(temperature), 
                        TemperatureScale.Fahrenheit),
                TemperatureScale.Kelvin =>
                    TemperatureValue.Create(
                        ToKelvinFromCelsius(temperature), 
                        TemperatureScale.Kelvin),
                _ => throw TemperatureException.ThrowScaleException(scale)
            },
            TemperatureScale.Fahrenheit => scale switch
            {
                TemperatureScale.Celsius => TemperatureValue.Create(
                    ToCelsiusFromFahrenheit(temperature)),
                TemperatureScale.Fahrenheit => temperature,
                TemperatureScale.Kelvin => TemperatureValue.Create(
                    ToKelvinFromFahrenheit(temperature), 
                    TemperatureScale.Kelvin),
                _ => throw TemperatureException.ThrowScaleException(scale)
            },
            TemperatureScale.Kelvin => scale switch
            {
                TemperatureScale.Celsius => TemperatureValue.Create(
                    ToCelsiusFromKelvin(temperature)),
                TemperatureScale.Fahrenheit => TemperatureValue.Create(
                    ToFahrenheitFromKelvin(temperature), 
                    TemperatureScale.Fahrenheit),
                TemperatureScale.Kelvin => temperature,
                _ => throw TemperatureException.ThrowScaleException(scale)
            },
            _ => throw TemperatureException.ThrowScaleException(temperature.Scale)
        };
    }

    public static Result<TemperatureValue> ToCelsius(TemperatureValue temperature)
    {
        return temperature.Scale switch
        {
            TemperatureScale.Celsius => temperature,
            TemperatureScale.Fahrenheit => 
                TemperatureValue.Create(
                    ToCelsiusFromFahrenheit(temperature)),
            TemperatureScale.Kelvin => 
                TemperatureValue.Create(
                    ToCelsiusFromKelvin(temperature)),
            _ => throw TemperatureException.ThrowScaleException(temperature.Scale)
        };
    }

    public static Result<TemperatureValue> ToFahrenheit(TemperatureValue temperature)
    {
        return temperature.Scale switch
        {
            TemperatureScale.Celsius => 
                TemperatureValue.Create(
                    ToFahrenheitFromCelsius(temperature), 
                    TemperatureScale.Fahrenheit),
            TemperatureScale.Fahrenheit => temperature,
            TemperatureScale.Kelvin => 
                TemperatureValue.Create(
                    ToFahrenheitFromKelvin(temperature),
                TemperatureScale.Fahrenheit),
            _ => throw TemperatureException.ThrowScaleException(temperature.Scale)
        };
    }

    public static Result<TemperatureValue> ToKelvin(TemperatureValue temperature)
    {
        return temperature.Scale switch
        {
            TemperatureScale.Celsius => 
                TemperatureValue.Create(
                    ToKelvinFromCelsius(temperature),
                    TemperatureScale.Kelvin),
            TemperatureScale.Fahrenheit => 
                TemperatureValue.Create(
                    ToKelvinFromFahrenheit(temperature),
                    TemperatureScale.Kelvin),
            TemperatureScale.Kelvin => temperature,
            _ => throw TemperatureException.ThrowScaleException(temperature.Scale)
        };


    }
    private static int ToCelsiusFromFahrenheit(int temperature) => (int)Math.Round((temperature - 32) * 5 / 9.0, MidpointRounding.AwayFromZero);
    private static int ToCelsiusFromKelvin(int temperature) => temperature - 273;
    private static int ToFahrenheitFromCelsius(int temperature) => (int)Math.Round(temperature * 9 / 5.0 + 32, MidpointRounding.AwayFromZero);
    private static int ToFahrenheitFromKelvin(int temperature) => ToFahrenheitFromCelsius(ToCelsiusFromKelvin(temperature));
    private static int ToKelvinFromCelsius(int temperature) => temperature + 273;
    private static int ToKelvinFromFahrenheit(int temperature) => ToKelvinFromCelsius(ToCelsiusFromFahrenheit(temperature));
}