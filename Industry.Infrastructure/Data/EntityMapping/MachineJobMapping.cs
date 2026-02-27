using Industry.Domain.Messaging;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Industry.Infrastructure.Data.EntityMapping;

public class MachineJobMapping : IEntityTypeConfiguration<MachineJob>
{
    public void Configure(EntityTypeBuilder<MachineJob> builder)
    {
        builder.HasKey(j => j.Id);
        
        builder.Property(j => j.ScheduledStart)
            .IsRequired()
            .HasColumnName("scheduled_start");
        
        builder.Property(j => j.MachineId)
            .IsRequired()
            .HasColumnName("machine_id");
        
        builder.Property(j => j.Command)
            .IsRequired();
        
        
        builder.HasIndex(j => j.ScheduledStart);
    }
}