using DigitalCaesar.ServerSilencer.Service.Sensors;
using FluentAssertions;

namespace ServiceUnitTests.Sensors;

public class TemperatureSensorsTest
{
    public static IEnumerable<object[]> ValidTemperatureSettings =>
        new List<object[]>
        {
            new object[]
            {
                new TemperatureSensorPackageSettings()
                {
                    Cpu = new TemperatureSensorSettings(new[] { "00h" }, 0, 10),
                    Inlet = new TemperatureSensorSettings(new[] { "00h" }, 0, 10),
                    Exhaust = new TemperatureSensorSettings(new[] { "00h" }, 0, 10)
                }
            }
        };
    
    
    [Theory]
    [MemberData(nameof(ValidTemperatureSettings))]
    public void ConstructorTest(TemperatureSensorPackageSettings settings)
    {
        TemperatureSensorPackage sensorPackage = new(settings);
        sensorPackage.Should().NotBeNull();
        sensorPackage.Cpu.Should().NotBeNull();
        sensorPackage.Inlet.Should().NotBeNull();
        sensorPackage.Exhaust.Should().NotBeNull();
    }
}