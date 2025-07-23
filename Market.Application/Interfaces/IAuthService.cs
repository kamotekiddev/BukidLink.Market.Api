using Market.Application.DTOs;

namespace Market.Application.Interfaces;

public class RegisterResponse
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}

public interface IAuthService
{
    Task<RegisterResponse> RegisterAsync(RegisterDto dto);
}