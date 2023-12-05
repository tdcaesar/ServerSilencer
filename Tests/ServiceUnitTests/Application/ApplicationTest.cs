using DigitalCaesar.ServerSilencer.Service.Application;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace ServiceUnitTests.Application;

public class ApplicationTest
{
    private const string cSettingsSection = "ApplicationSettings";
    private const string cSettingsFile = "appsettings.json";

    private ServiceController GetTestApplication()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(cSettingsFile, false, true)
            .Build();

        config.GetSection(cSettingsSection);
        
        return new(
            new Logger<ServiceController>(new NullLoggerFactory()), 
            new ApplicationSettings());
    }
    
    [Fact]
    public void ConstructorTest()
    {
        // Arrange
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile(cSettingsFile, false, true)
            .Build();

        config.GetSection(cSettingsSection);
        
        // Act
        ServiceController service = new(
            new Logger<ServiceController>(new NullLoggerFactory()), 
            new ApplicationSettings());

        // Assert
        service.Should().NotBeNull();
    }

    [Fact]
    public void Method_Start_Test()
    {
        // Arrange
        ServiceController service = GetTestApplication();
        
        // Act
        var result = service.Start();

        // Assert
        result.Successful.Should().BeTrue();
    }
    [Fact(Skip = "No Need to wait")]
    public async Task Method_Wait_Test()
    {
        ServiceController service = GetTestApplication();
        
        await service.Wait(new CancellationToken());
    }
    [Fact]
    public void Method_Stop_Test()
    {
        // Arrange
        ServiceController service = GetTestApplication();
        
        // Act
        var result = service.Stop();

        // Assert
        result.Successful.Should().BeTrue();
    }
    [Fact]
    public async Task Method_Run_Test()
    {
        // Arrange
        ServiceController service = GetTestApplication();
        
        // Act
        var result = await service.Run(new CancellationToken());

        // Assert
        result.Successful.Should().BeTrue();
    }
    [Fact]
    public async Task Method_Run_WithCancellation_Test()
    {
        // Arrange
        CancellationTokenSource cts = new();
        cts.CancelAfter(0);
        CancellationToken token = cts.Token;
        ServiceController service = GetTestApplication();

        // Act
        var result = await service.Run(token);

        // Assert
        token.IsCancellationRequested.Should().BeTrue();
    }
}