namespace Domain.Ports;

public interface INotificationService
{
    Task PublishMessageAsync(string subject, string message);
    Task PublishMessageToTopicAsync(string topicArn, string subject, string message);
}
