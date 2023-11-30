using DigitalCaesar.ServerSilencer.Service;
using DigitalCaesar.ServerSilencer.Service.Application;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ServiceUnitTests.Application;

public class ApplicationSettingsTest
{
    private const string SettingsFileName = "appsettings.json";
    private const string SettingsRootSectionName = "ApplicationSettings";
    private const int DefaultPollingInterval = 60;

    [Fact]
    public void LoadSettings()
    {
        ApplicationSettings settings = new();
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(SettingsFileName, false, true)
            .Build()
            .GetSection(SettingsRootSectionName);  
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
        testSettings.PollingIntervalInSeconds.Should().Be(DefaultPollingInterval);
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