using Industry.Domain.Messaging;

namespace Industry.Infrastructure.Repositories;

public interface IJobRepository
{
    Task AddJobAsync(MachineJob job, CancellationToken cancellationToken);
    Task<List<MachineJob>> GetPendingJobsAsync();
    Task MarkAsSentAsync(int jobId);
}