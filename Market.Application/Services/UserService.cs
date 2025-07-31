using System.Security.Claims;
using AutoMapper;
using Market.Application.DTOs.User;
using Market.Application.Interfaces;
using Market.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUserRolesRepository _userRolesRepository;
    private readonly IRoleRepository _roleRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor,
        IUserRolesRepository userRolesRepository, IRoleRepository roleRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
        _userRolesRepository = userRolesRepository;
        _roleRepository = roleRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> CreateUserAsync(AddUserDto dto)
    {
        var existingUser = await GetUserByEmailAsync(dto.Email);
        if (existingUser is not null) throw new BadHttpRequestException("Email is already taken");

        var user = new User()
        {
            Email = dto.Email,
            Name = dto.Name,
            Password = dto.Password
        };

        await _userRepository.SaveUserAsync(user);

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> UpdateUserAsync(Guid userId, UpdateUserDto dto)
    {
        var existingUser = await _userRepository.FindUserByIdAsync(userId) ??
                           throw new BadHttpRequestException("User does not exist");

        existingUser.Name = dto.Name;

        await _userRepository.UpdateUserAsync(existingUser);

        return _mapper.Map<UserDto>(existingUser);
    }

    public async Task<UserDto> AssignRoleToUserAsync(Guid userId, Guid roleId)
    {
        var user = await _userRepository.FindUserByIdAsync(userId) ??
                   throw new BadHttpRequestException("User does not exist.");
        var role = await _roleRepository.GetRoleByIdAsync(roleId) ??
                   throw new BadHttpRequestException("Role doest not exist.");


        await _userRolesRepository.AddUserRole(new UserRole()
        {
            UserId = user.Id,
            RoleId = role.Id
        });

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var user = await _userRepository.FindUserByEmailAsync(email) ??
                   throw new KeyNotFoundException("User not found.");

        return _mapper.Map<UserDto>(user);
    }

    public async Task<UserDto> GetCurrentUser()
    {
        var httpContext = _httpContextAccessor.HttpContext;
        var userEmail = httpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrWhiteSpace(userEmail)) throw new BadHttpRequestException("Unauthorized");
        return await GetUserByEmailAsync(userEmail) ?? throw new UnauthorizedAccessException("User not found.");
    }
}