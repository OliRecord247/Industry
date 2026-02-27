using Industry.Domain.Messaging;
using Industry.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Industry.Application.Workers;

public class TimetableWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly IMessageBroker _broker;

    public TimetableWorker(IServiceScopeFactory scopeFactory, IMessageBroker broker)
    {
        _scopeFactory = scopeFactory;
        _broker = broker;
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
                    await _broker.PublishAsync($"machines/{job.MachineId}/tasks", job);
                    await repo.MarkAsSentAsync(job.Id);
                }
            }
            await Task.Delay(10000, stoppingToken);
        }
    }
}