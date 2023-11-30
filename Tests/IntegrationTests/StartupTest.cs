using DigitalCaesar.ServerSilencer.Service;
using DigitalCaesar.ServerSilencer.Service.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace IntegrationTests;

public class StartupTest
{
    [Fact]
    public void TestConfig()
    {
        IHost host = Host.CreateDefaultBuilder()
            .ConfigureServices(
                (hostContext, services) =>
                {
                    services.Configure<ApplicationSettings>(
                        hostContext.Configuration.GetSection("ApplicationSettings"));
                })
            .Build();
    }
}