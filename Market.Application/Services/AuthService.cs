using Market.Application.DTOs;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IRefreshTokenRepository _refreshTokenRepository;
    private readonly JwtService _jwtService;
    private readonly PasswordService _passwordService;

    public AuthService(IUserRepository userRepository, JwtService jwtService,
        IRefreshTokenRepository refreshTokenRepository, PasswordService passwordService)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordService = passwordService;
    }

    public async Task<RegisterResponseDto> RegisterAsync(RegisterDto dto)
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


        return new RegisterResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }

    public async Task<LoginResponseDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepository.FindUserByEmail(dto.Email);
        if (user is null) throw new BadHttpRequestException("User with given email does not exist.");

        var passwordMatched = _passwordService.VerifyPassword(dto.Password, user.Password);
        if (!passwordMatched)
            throw new BadHttpRequestException("Invalid Credentials");

        var accessToken = _jwtService.GenerateAccessToken(user);
        var refreshToken = _jwtService.GenerateRefreshToken(user.Id);

        await _refreshTokenRepository.SaveTokenAsync(refreshToken);

        return new LoginResponseDto()
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken.Token
        };
    }
}