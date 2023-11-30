using DigitalCaesar.ServerSilencer.Service.Application;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ServiceUnitTests.Application;

public class ApplicationTest
{
    private const string SettingsSection = "ApplicationSettings";
    private const string SettingsFile = "appsettings.json";

    private ServiceController GetTestApplication()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(SettingsFile, false, true)
            .Build();

        config.GetSection(SettingsSection);
        
        return new(
            new Logger<ServiceController>(new NullLoggerFactory()), 
            new ApplicationSettings());
    }
    
    [Fact]
    public void ConstructorTest()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(SettingsFile, false, true)
            .Build();

        config.GetSection(SettingsSection);
        
        ServiceController service = new(
            new Logger<ServiceController>(new NullLoggerFactory()), 
            new ApplicationSettings());

        service.Should().NotBeNull();
    }

    [Fact]
    public void MethodStartTest()
    {
        ServiceController service = GetTestApplication();
        
        service.Start();
    }
    [Fact(Skip = "No Need to wait")]
    public async Task MethodWaitTest()
    {
        ServiceController service = GetTestApplication();
        
        await service.Wait(new CancellationToken());
    }
    [Fact]
    public void MethodStopTest()
    {
        ServiceController service = GetTestApplication();
        
        service.Stop();
    }
    [Fact(Skip = "save for integration")]
    public async Task MethodRunTest()
    {
        ServiceController service = GetTestApplication();
        
        await service.Run(new CancellationToken());
    }
}