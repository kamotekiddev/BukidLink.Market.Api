using Market.Application.DTOs;
using Market.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Internal;

namespace Market.Application.Services;

public class AuthService : IAuthService
{
    public async Task<RegisterResponse> RegisterAsync(RegisterDto dto)
    {
        return new RegisterResponse()
        {
            AccessToken = "accesstoken",
            RefreshToken = "refreshtoken"
        };
    }
}