namespace Domain.Models.Response;

public class AuthResponse : BaseResponse
{
    public string? Token { get; set; }
    public DateTime? Expiration { get; set; }
}
