using DigitalCaesar.ServerSilencer.Service.Temperature;
using FluentAssertions;

namespace ServiceUnitTests.Temperature;

public class TemperatureRangeTest
{
    private const int cMinimum = -100;
    private const int cMaximum = 100;

    [Fact]
    public void Constructor_Default()
    {
        // Arrange
        // Act
        var temperatureRange = new TemperatureRange();

        // Assert
        temperatureRange.Minimum.Should().Be(cMinimum);
        temperatureRange.Maximum.Should().Be(cMaximum);
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