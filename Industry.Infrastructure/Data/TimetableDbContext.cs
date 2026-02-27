using Industry.Domain.Messaging;
using Industry.Infrastructure.Data.EntityMapping;
using Microsoft.EntityFrameworkCore;

namespace Industry.Infrastructure.Data;

public class TimetableDbContext : DbContext
{
    public DbSet<MachineJob> MachineJobs => Set<MachineJob>();
    
    public TimetableDbContext(DbContextOptions<TimetableDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MachineJobMapping());
    }
}