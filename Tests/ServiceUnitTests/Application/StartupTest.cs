using DigitalCaesar.ServerSilencer.Service.Application;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServiceUnitTests.Application;

public class StartupTest
{
    [Fact]
    public void TestConfig()
    {
        Host.CreateDefaultBuilder()
            .ConfigureServices(
                (hostContext, services) =>
                {
                    services.Configure<ApplicationSettings>(
                        hostContext.Configuration.GetSection("ApplicationSettings"));
                })
            .Build();
    }
}