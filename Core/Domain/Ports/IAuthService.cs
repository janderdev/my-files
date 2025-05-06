using Domain.Entities;
using Domain.Models.Response;

namespace Domain.Ports;

public interface IAuthService
{
    Task<AuthResponse> AuthenticateAsync(Auth auth);
    Task<AuthResponse> AddNewAuthAsync(Auth auth);
}
