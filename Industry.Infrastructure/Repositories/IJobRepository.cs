using Industry.Domain.Messaging;

namespace Industry.Infrastructure.Repositories;

public interface IJobRepository
{
    Task<List<MachineJob>> GetPendingJobsAsync();
    Task MarkAsSentAsync(int jobId);
}