using DigitalCaesar.ServerSilencer.Service.Application;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ServiceUnitTests.Application;

public class ApplicationSettingsTest
{
    private const string cSettingsFileName = "appsettings.json";
    private const string cSettingsRootSectionName = "ApplicationSettings";
    private const int cPollingInterval = 60;

    [Fact]
    public void LoadSettings()
    {
        ApplicationSettings settings = new();
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(cSettingsFileName, false, true)
            .Build()
            .GetSection(cSettingsRootSectionName);  
        config.Bind(settings);
        settings.PollingIntervalInSeconds.Should().Be(60);
        settings.TemperatureSensors.Inlet.Ids.Count.Should().Be(1);
        settings.TemperatureSensors.Exhaust.Ids.Count.Should().Be(1);
        settings.TemperatureSensors.Cpu.Ids.Count.Should().Be(2);
    }
    
    [Fact]
    public void PollingIntervalDefault()
    {
        ApplicationSettings testSettings = new();
        testSettings.PollingIntervalInSeconds.Should().Be(cPollingInterval);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(100)]
    public void PollingInterval(int testValue)
    {
        ApplicationSettings testSettings = new()
        {
            PollingIntervalInSeconds = testValue
        };
        testSettings.PollingIntervalInSeconds.Should().Be(testValue);
    }
}