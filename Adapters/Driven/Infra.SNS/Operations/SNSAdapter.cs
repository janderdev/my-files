using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Domain.Ports;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Infra.SNS.Config;

namespace Infra.SNS.Operations;

public class SNSAdapter : INotificationService
{
    private readonly AmazonSimpleNotificationServiceClient _snsClient;
    private readonly string? _defaultTopicArn;
    private readonly ILogger<SNSAdapter> _logger;

    public SNSAdapter(IOptions<AWSOptions> options, ILogger<SNSAdapter> logger)
    {
        _logger = logger;

        var awsOptions = options.Value;
        _defaultTopicArn = awsOptions.DefaultTopicArn;

        // Configura o cliente SNS
        if (!string.IsNullOrEmpty(awsOptions.AccessKey) && !string.IsNullOrEmpty(awsOptions.SecretKey) && !string.IsNullOrEmpty(awsOptions.Region))
        {
            var regionEndpoint = RegionEndpoint.GetBySystemName(awsOptions.Region);
            _snsClient = new AmazonSimpleNotificationServiceClient(awsOptions.AccessKey, awsOptions.SecretKey, regionEndpoint);
        }
        else
        {
            // Usa as credenciais padrão do ambiente
            _snsClient = new AmazonSimpleNotificationServiceClient();
        }
    }

    public async Task PublishMessageAsync(string subject, string message)
    {
        if (string.IsNullOrEmpty(_defaultTopicArn))
        {
            _logger.LogError("Default Topic ARN is not configured.");
            throw new InvalidOperationException("Default Topic ARN is not configured.");
        }

        await PublishMessageToTopicAsync(_defaultTopicArn, subject, message);
    }

    public async Task PublishMessageToTopicAsync(string topicArn, string subject, string message)
    {
        try
        {
            var request = new PublishRequest
            {
                TopicArn = topicArn,
                Subject = subject,
                Message = message
            };

            var response = await _snsClient.PublishAsync(request);
            _logger.LogInformation("Message {messageId} sent to SNS topic {topicArn}", response.MessageId, topicArn);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error publishing message to SNS topic {topicArn}", topicArn);
            throw;
        }
    }
}
