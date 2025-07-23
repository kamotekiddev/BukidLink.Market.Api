using System;
using Market.Domain.Entities;

namespace Market.Application.Interfaces;

public interface IRefreshTokenRepository
{
	Task<RefreshToken> SaveTokenAsync(RefreshToken token);
}
