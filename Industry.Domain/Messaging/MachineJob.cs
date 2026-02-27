namespace Industry.Domain.Messaging;

public class MachineJob
{
    public int Id { get; set; }
    public string MachineId { get; set; } = string.Empty;
    public DateTime ScheduledStart { get; set; }
    public string Command { get; set; } = string.Empty;
    public bool IsSent { get; set; } = false;
    
    public bool IsValid() => ScheduledStart > DateTime.UtcNow.AddMinutes(-5);
}