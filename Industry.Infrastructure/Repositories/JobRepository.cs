using Industry.Domain.Messaging;
using Industry.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Industry.Infrastructure.Repositories;

public class JobRepository : IJobRepository
{
    private readonly TimetableDbContext _context;
    
    public JobRepository(TimetableDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<MachineJob>> GetPendingJobsAsync()
    {
        return await _context.MachineJobs
            .Where(j => !j.IsSent && j.ScheduledStart <= DateTime.UtcNow)
            .ToListAsync();
    }

    public async Task MarkAsSentAsync(int jobId)
    {
        var job = await _context.MachineJobs.FindAsync(jobId);
        if (job != null) job.IsSent = true;
        await _context.SaveChangesAsync();
    }
}