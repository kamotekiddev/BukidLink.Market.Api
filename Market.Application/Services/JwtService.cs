using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Market.Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Market.Application.Services;

public class JwtService
{
	private readonly IConfiguration _config;

	public JwtService(IConfiguration config)
	{
		_config = config;
	}


	public string GenerateAccessToken(User user)
	{
		var claims = new List<Claim>
		{
			new Claim(JwtRegisteredClaimNames.Sub, user.Email),
			new Claim(ClaimTypes.NameIdentifier, user.Name),
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetValue<string>("Jwt:Key")!));
		var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
		var expiry = DateTime.UtcNow.AddMinutes(_config.GetValue<int>("Jwt:AccessTokenExpiryMinutes"));

		var token = new JwtSecurityToken(
			issuer: _config.GetValue<string>("Jwt:Issuer"),
			audience: _config.GetValue<string>("Jwt:Audience"),
			claims: claims,
			expires: expiry,
			signingCredentials: creds
		);

		return new JwtSecurityTokenHandler().WriteToken(token);
	}

	public RefreshToken GenerateRefreshToken(Guid userId)
	{
		var expiry = DateTime.UtcNow.AddDays(int.Parse(_config["Jwt:RefreshTokenExpiryDays"] ?? string.Empty));

		return new RefreshToken
		{
			UserId = userId,
			Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
			Expiry = expiry
		};


	}

}
