using System.Text.Json;
using Industry.Domain.Messaging;
using Microsoft.Extensions.Configuration;
using MQTTnet;
using MQTTnet.Protocol;

namespace Industry.Infrastructure.Messaging;

public class MqttMessageBroker : IMessageBroker
{
    private readonly IMqttClient _client;
    private readonly MqttClientOptions _options;

    public MqttMessageBroker(IConfiguration config)
    {
        var factory = new MqttClientFactory();
        _client = factory.CreateMqttClient();
        _options = new MqttClientOptionsBuilder()
            .WithTcpServer("localhost", 1883)
            .Build();
    }
    
    public async Task PublishAsync<T>(string topic, T message)
    {
        if (!_client.IsConnected) await _client.ConnectAsync(_options);
        
        var payload = JsonSerializer.Serialize(message);
        var mqttMessage = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(payload)
            .WithQualityOfServiceLevel(MqttQualityOfServiceLevel.AtLeastOnce)
            .Build();
        
        await _client.PublishAsync(mqttMessage);
    }
}