using System.Runtime.InteropServices.ComTypes;
using DigitalCaesar.ServerSilencer.Service.Sensors;
using FluentAssertions;

namespace ServiceUnitTests.Sensors;

public class TemperatureSensorTest
{
    public static IEnumerable<object[]> ValidTemperatureSettings =>
        new List<object[]>
        {
            new object[] { new TemperatureSensorSettings(new[] { "00h" }, 0, 10) }
        };
    public static IEnumerable<object[]> InvalidTemperatureSettings =>
        new List<object[]>
        {
            new object[] { new TemperatureSensorSettings(new[] { "00h" }, 10, 0) }
        };
    public static IEnumerable<object[]> NullTemperatureSettings =>
        new List<object[]>
        {
            new object[] { new TemperatureSensorSettings(new string[] { }, 0, 10) }
        };


    [Theory]
    [MemberData(nameof(ValidTemperatureSettings))]
    public void ConstructorTest(TemperatureSensorSettings settings)
    {
        TemperatureSensor testObject = new(settings);
        testObject.Should().NotBeNull();
    }
    [Theory]
    [MemberData(nameof(InvalidTemperatureSettings))]
    public void ConstructorInvalidTest(TemperatureSensorSettings settings)
    {
        // Arrange
        TemperatureSensor Action() => new(settings);
        // Act
        // Assert
        FluentActions.Invoking(Action).Should().Throw<TemperatureSensorException>();
        //Assert.Throws<TemperatureSensorException>(() => new TemperatureSensor(settings));
    }

    [Theory]
    [MemberData(nameof(ValidTemperatureSettings))]
    public void HasSensorsValid(TemperatureSensorSettings settings)
    {
        TemperatureSensor testObject = new(settings);
        testObject.HasSensors.Should().BeTrue();
    }
    
    [Theory]
    [MemberData(nameof(NullTemperatureSettings))]
    public void HasSensorsNull(TemperatureSensorSettings settings)
    {
        TemperatureSensor testObject = new(settings);
        testObject.HasSensors.Should().BeFalse();
    }
}