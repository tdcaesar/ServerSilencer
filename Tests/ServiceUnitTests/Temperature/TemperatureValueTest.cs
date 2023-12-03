using DigitalCaesar.Results;
using DigitalCaesar.ServerSilencer.Service.Temperature;
using FluentAssertions;

namespace ServiceUnitTests.Temperature;

public class TemperatureValueTest
{
    private const TemperatureScale DefaultScale = TemperatureScale.Celsius;
    private const int DefaultTemperature = 0;

    [Fact]
    public void ConstructorDefaultTest()
    {
        var result = TemperatureValue.Create();
        result.Successful.Should().BeTrue();
        result.Switch((success) =>
            {
                success.Scale.Should().Be(DefaultScale);
                success.Value.Should().Be(DefaultTemperature);
            },
            (failure) => failure.Should().BeNull());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-237)]
    [InlineData(237)]
    public void ConstructorValueTest(int value)
    {
        var result = TemperatureValue.Create(value);
        result.Successful.Should().BeTrue();
        result.Switch(
            (success) => success.Value.Should().Be(value),
            (failure) => failure.Should().BeNull());
    }
    [Theory]
    [InlineData(-1000)]
    [InlineData(1000)]
    public void ConstructorValueInvalidTest(int value)
    {
        var result = TemperatureValue.Create(value);
        result.Successful.Should().BeFalse();
        result.Switch((success) => success.Should().BeNull(),
            (failure) => failure.Count.Should().Be(1));
    }
    [Theory]
    [InlineData(TemperatureScale.Celsius)]
    [InlineData(TemperatureScale.Fahrenheit)]
    [InlineData(TemperatureScale.Kelvin)]
    public void ConstructorScaleTest(TemperatureScale scale)
    {
        var result = TemperatureValue.Create(DefaultTemperature, scale);
        result.Successful.Should().BeTrue();
        result.Switch(
            (success) => success.Scale.Should().Be(scale),
            (failure) => failure.Should().BeNull());
    }
    [Theory(Skip = "How do you simulate an unknown enum value?")]
    [InlineData(TemperatureScale.Celsius)]
    [InlineData(TemperatureScale.Fahrenheit)]
    [InlineData(TemperatureScale.Kelvin)]
    public void ConstructorScaleInvalidTest(TemperatureScale scale)
    {
        var result = TemperatureValue.Create(DefaultTemperature, scale);
        result.Successful.Should().BeFalse();
        result.Switch(
            (success) => success.Should().BeNull(),
            (failure) => failure.Count.Should().Be(1));
    }



    [Theory]
    [InlineData(0)]
    [InlineData(-100)]
    [InlineData(100)]
    public void ImplicitValueTest(int value)
    {
        var result = TemperatureValue.Create(value);
        int resultValue = result.Match(
            (success) => success,
            failure => -10000);
        resultValue.Should().Be(value);
    }

    //[Theory]
    //[InlineData(0)]
    //[InlineData(-100)]
    //[InlineData(100)]
    //public void ExplicitValueTest(int value)
    //{
    //    TemperatureValue temperatureValue = (TemperatureValue)value;
    //    temperatureValue.Should().NotBeNull();
    //    int result = temperatureValue;
    //    result.Should().Be(value);
    //}

    [Theory]
    [InlineData(0, TemperatureScale.Celsius, "0°C")]
    [InlineData(100, TemperatureScale.Celsius, "100°C")]
    [InlineData(-100, TemperatureScale.Celsius, "-100°C")]
    [InlineData(0, TemperatureScale.Fahrenheit, "0°F")]
    [InlineData(100, TemperatureScale.Fahrenheit, "100°F")]
    [InlineData(-100, TemperatureScale.Fahrenheit, "-100°F")]
    [InlineData(0, TemperatureScale.Kelvin, "0°K")]
    [InlineData(546, TemperatureScale.Kelvin, "546°K")]
    [InlineData(0, TemperatureScale.Kelvin, "0°K")]
    public void MethodToStringTest(int value, TemperatureScale scale, string expectedValue)
    {
        var result = TemperatureValue.Create(value, scale);
        string resultValue = result.Match(
            (success) => success.ToString(),
            failure => "");
        resultValue.ToString().Should().Be(expectedValue);
    }
}