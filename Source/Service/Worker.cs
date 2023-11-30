using DigitalCaesar.ServerSilencer.Service.Application;

namespace DigitalCaesar.ServerSilencer.Service;

public class Worker : BackgroundService
{
    private readonly ServiceController _service;

    public Worker(ILogger<Worker> logger, ServiceController serviceController)
    {
        _service = serviceController;
    }

    protected override async Task ExecuteAsync(CancellationToken cancellationToken)
    {
        _service.Start();
        
        while (!cancellationToken.IsCancellationRequested)
        {
            await _service.Run(cancellationToken);
            await _service.Wait(cancellationToken);
        }

        _service.Stop();
    }
}
