namespace Industry.Domain.Messaging;

public interface IMessageBroker
{
    Task PublishAsync<T>(string topic, T message);
}