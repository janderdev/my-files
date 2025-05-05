namespace Infra.SNS.Config;

public class AWSOptions
{
    public string? AccessKey { get; set; }
    public string? SecretKey { get; set; }
    public string? Region { get; set; }
    public string? DefaultTopicArn { get; set; }
}
