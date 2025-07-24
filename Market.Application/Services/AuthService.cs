using Market.Application.DTOs;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Market.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtService _jwtService;
    private readonly PasswordService _passwordService;
    public readonly IConfiguration _configuration;

    public AuthService(IUserRepository userRepository, JwtService jwtService,
        IRefreshTokenRepository refreshTokenRepository, PasswordService passwordService, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordService = passwordService;
        _configuration = configuration;
    }

    public async Task<AuthResponse> RegisterAsync(RegisterDto dto)
    {
        var existingUser = await _userRepository.FindUserByEmail(dto.Email);
        if (existingUser is not null) throw new BadHttpRequestException("Email is already taken.");


        var user = new User()
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = _passwordService.HashPassword(dto.Password)
        };

        await _userRepository.SaveUserAsync(user);

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken(user.Id);

        await _refreshTokenRepository.SaveTokenAsync(refreshToken);


        return new AuthResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    public async Task<AuthResponse> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.FindUserByEmail(dto.Email);
        if (user is null) throw new BadHttpRequestException("User with given email does not exist.");

        var passwordMatched = _passwordService.VerifyPassword(dto.Password, user.Password);
        if (!passwordMatched)
            throw new BadHttpRequestException("Invalid Credentials");

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken(user.Id);

        await _refreshTokenRepository.SaveTokenAsync(refreshToken);

        return new AuthResponse()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    public async Task<AuthResponse> RefreshTokenAsync(string refreshToken)
    {
        var existingRefreshToken = await _refreshTokenRepository.FindTokenAsync(refreshToken);

        var accessToken = _jwtService.GenerateAccessToken(existingRefreshToken.User!);
        var newRefreshToken = _jwtService.GenerateRefreshToken(existingRefreshToken.UserId);

        existingRefreshToken.Token = newRefreshToken.Token;
        existingRefreshToken.Expiry =
            DateTime.UtcNow.AddDays(_configuration.GetValue<int>("Jwt:RefreshTokenExpiryDays"));

        await _refreshTokenRepository.UpdateTokenAsync(existingRefreshToken);

        return new AuthResponse()
        {
            AccessToken = accessToken,
            RefreshToken = newRefreshToken.Token,
        };
    }
}