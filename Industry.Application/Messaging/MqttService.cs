using Industry.Domain.Messaging;

namespace Industry.Application.Messaging;

public class MqttService : IMqttService
{
    private readonly IMessageBroker _broker;
    
    public MqttService(IMessageBroker broker)
    {
        _broker = broker;
    }
    
    public async Task SendMachineCommand(MachineJob job)
    {
        string topic = $"factory/halls/1/machines/{job.MachineId}/commands";
        
        var payload = new { 
            Action = job.Command, 
            Timestamp = DateTime.UtcNow,
            Priority = 1 
        };
        
        await _broker.PublishAsync(topic, payload);
    }
}