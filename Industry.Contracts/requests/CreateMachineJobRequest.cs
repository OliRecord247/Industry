namespace Industry.Contracts.requests;

public class CreateMachineJobRequest
{
    public required string MachineId { get; init; }
    public required string ScheduledTime { get; init; }
    public required string Action { get; init; }
    public required bool IsProcessed { get; init; } = false;
}