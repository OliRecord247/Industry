using Industry.Application.Messaging;
using Industry.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Industry.Application.Workers;

public class TimetableWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMqttService _mqttService;

    public TimetableWorker(IServiceScopeFactory scopeFactory, IMqttService mqttService)
    {
        _scopeFactory = scopeFactory;
        _mqttService = mqttService;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var repo = scope.ServiceProvider.GetRequiredService<IJobRepository>();
                var jobs = await repo.GetPendingJobsAsync();

                foreach (var job in jobs)
                {
                    await _mqttService.SendMachineCommand(job);
                    await repo.MarkAsSentAsync(job.Id);
                }
            }
            await Task.Delay(10000, stoppingToken);
        }
    }
}