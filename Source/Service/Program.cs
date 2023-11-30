using DigitalCaesar.ServerSilencer.Service;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(
        (hostContext,services) =>
    {
        services.AddHostedService<Worker>();
        services.Configure<ApplicationSettings>(
            hostContext.Configuration.GetSection("ApplicationSettings"));
    })
    .Build();

host.Run();
