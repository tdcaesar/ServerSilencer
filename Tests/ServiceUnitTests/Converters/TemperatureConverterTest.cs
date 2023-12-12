using DigitalCaesar.ServerSilencer.Service.Temperature;
using FluentAssertions;

namespace ServiceUnitTests.Converters;

public class TemperatureConverterTest
{
    [Theory]
    [InlineData(0, TemperatureScale.Celsius, TemperatureScale.Celsius, 0)]
    [InlineData(100, TemperatureScale.Celsius, TemperatureScale.Celsius, 100)]
    [InlineData(0, TemperatureScale.Fahrenheit, TemperatureScale.Fahrenheit, 0)]
    [InlineData(100, TemperatureScale.Fahrenheit, TemperatureScale.Fahrenheit, 100)]
    [InlineData(0, TemperatureScale.Kelvin, TemperatureScale.Kelvin, 0)]
    [InlineData(100, TemperatureScale.Kelvin, TemperatureScale.Kelvin, 100)]
    [InlineData(0, TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 32)]
    [InlineData(100, TemperatureScale.Celsius, TemperatureScale.Fahrenheit, 212)]
    [InlineData(32,TemperatureScale.Fahrenheit, TemperatureScale.Celsius, 0)]
    [InlineData(212, TemperatureScale.Fahrenheit, TemperatureScale.Celsius, 100)]
    [InlineData(0, TemperatureScale.Celsius, TemperatureScale.Kelvin, 273)]
    [InlineData(100, TemperatureScale.Celsius, TemperatureScale.Kelvin, 373)]
    [InlineData(-273, TemperatureScale.Celsius, TemperatureScale.Kelvin, 0)]
    [InlineData(273, TemperatureScale.Kelvin, TemperatureScale.Celsius,0)]
    [InlineData(373, TemperatureScale.Kelvin, TemperatureScale.Celsius, 100)]
    [InlineData(0, TemperatureScale.Kelvin, TemperatureScale.Celsius, -273)]
    [InlineData(0, TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 255)]
    [InlineData(100, TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 311)]
    [InlineData(-459, TemperatureScale.Fahrenheit, TemperatureScale.Kelvin, 0)]
    [InlineData(255, TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, 0)]
    [InlineData(311, TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, 100)]
    [InlineData(0, TemperatureScale.Kelvin, TemperatureScale.Fahrenheit, -459)]
    public void Method_To_Valid(int temperature, TemperatureScale fromScale, TemperatureScale toScale, int expectedValue)
    {
        // Arrange
        TemperatureValue testObject = TemperatureValue.Create(temperature, fromScale).Match(            
            (success) => success,
            (failure) => throw new ArgumentException(failure.ToString()));

        // Act
        var result = TemperatureConverter.To(testObject, toScale);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }

    [Theory]
    [InlineData(0,  0)]
    [InlineData(100, 100)]
    public void Method_FromCelsius_ToCelsius(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue);
        
        // Act
        var result = temperature.Match(
            TemperatureConverter.ToCelsius,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 100)]
    public void Method_FromFahrenheit_ToFahrenheit(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Fahrenheit);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToFahrenheit,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(0, 0)]
    [InlineData(100, 100)]
    public void Method_FromKelvin_ToKelvin(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Kelvin);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToKelvin,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(0, 32)]
    [InlineData(100, 212)]
    public void Method_FromCelsius_ToFahrenheit(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToFahrenheit,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(32, 0)]
    [InlineData(212, 100)]
    public void Method_FromFahrenheit_ToCelsius(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Fahrenheit);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToCelsius,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(0, 273)]
    [InlineData(100, 373)]
    [InlineData(-273, 0)]
    public void Method_FromCelsius_ToKelvin(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToKelvin,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(273, 0)]
    [InlineData(373, 100)]
    [InlineData(0, -273)]
    public void Method_FromKelvin_ToCelsius(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Kelvin);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToCelsius,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }

    [Theory]
    [InlineData(0, 255)]
    [InlineData(100, 311)]
    [InlineData(-459, 0)]
    public void Method_FromFahrenheit_ToKelvin(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Fahrenheit);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToKelvin,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
    [Theory]
    [InlineData(255, 0)]
    [InlineData(311, 100)]
    [InlineData(0, -459)]
    public void Method_FromKelvin_ToFahrenheit(int fromValue, int expectedValue)
    {
        // Arrange
        var temperature = TemperatureValue.Create(fromValue, TemperatureScale.Kelvin);

        // Act
        var result = temperature.Match(
            TemperatureConverter.ToFahrenheit,
            _ => null!);

        // Assert
        result.Successful.Should().BeTrue();
        result.Switch(
            (value) => value.Value.Should().Be(expectedValue),
            (errors) => errors.Should().BeNull());
    }
}