using Industry.Domain.Messaging;

namespace Industry.Application.Messaging;

public interface IMqttService
{
    Task SendMachineCommand(MachineJob job);
}