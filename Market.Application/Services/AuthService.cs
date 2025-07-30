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
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IConfiguration _configuration;
    private readonly IRoleService _roleService;

    public AuthService(IUserRepository userRepository, JwtService jwtService,
        IRefreshTokenRepository refreshTokenRepository, PasswordService passwordService, IConfiguration configuration,
        IRoleService roleService, IUserRolesRepository userRolesRepository)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
        _refreshTokenRepository = refreshTokenRepository;
        _passwordService = passwordService;
        _configuration = configuration;
        _roleService = roleService;
        _userRolesRepository = userRolesRepository;
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

        var existingRole = (await _roleService.GetAllRolesAsync()).FirstOrDefault(role => role.Name == dto.Role);
        if (existingRole is null) throw new BadHttpRequestException("Role does not exist.");

        await _userRepository.SaveUserAsync(user);
        await _userRolesRepository.AddUserRole(new UserRole() { RoleId = existingRole.Id, UserId = user.Id });

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