using DigitalCaesar.ServerSilencer.Service.Temperature;
using FluentAssertions;

namespace ServiceUnitTests.Temperature;

public class TemperatureRangeTest
{
    private const int DefaultMinimum = -100;
    private const int DefaultMaximum = 100;

    [Fact]
    public void Constructor_Default()
    {
        // Arrange
        // Act
        var temperatureRange = new TemperatureRange();

        // Assert
        temperatureRange.Minimum.Should().Be(DefaultMinimum);
        temperatureRange.Maximum.Should().Be(DefaultMaximum);
    }
    [Theory]
    [InlineData(-100, 100)]
    [InlineData(int.MinValue, int.MaxValue)]
    public void Constructor_WithValidParameters_ShouldNotThrowException(int minimum, int maximum)
    {
        // Arrange
        // Act
        var temperatureRange = new TemperatureRange(minimum, maximum);

        // Assert
        temperatureRange.Minimum.Should().Be(minimum);
        temperatureRange.Maximum.Should().Be(maximum);
    }


}