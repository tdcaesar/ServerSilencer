using DigitalCaesar.ServerSilencer.Service.Ipmi;
using FluentAssertions;
using Microsoft.Extensions.Configuration;

namespace ServiceUnitTests.Ipmi;

public class IpmiCommandSettingsTest
{
    private const string SettingsFileName = "appsettings.json";
    private const string SettingsRootSectionName = "Ipmi";
    
    [Fact]
    public void ConstructorTest()
    {
        IpmiCommandSettings testObject = new();
        testObject.Should().NotBeNull();
        testObject.Connection.Should().NotBeNull();
        testObject.Tool.Should().NotBeNull();
        testObject.RetryCount.Should().Be(0);
        testObject.InitialDelayInSeconds.Should().Be(5);
        testObject.Factor.Should().Be(2.0);
    }

    [Fact]
    public void LoadSettingsTest()
    {
        IpmiCommandSettings testObject = new();
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(SettingsFileName, false, true)
            .Build()
            .GetSection(SettingsRootSectionName);  
        config.Bind(testObject);
        testObject.Should().NotBeNull();
        testObject.Connection.Should().NotBeNull();
        testObject.Tool.Should().NotBeNull();
        testObject.RetryCount.Should().Be(0);
        testObject.InitialDelayInSeconds.Should().Be(5);
        testObject.Factor.Should().Be(2.0);
        
    }
}