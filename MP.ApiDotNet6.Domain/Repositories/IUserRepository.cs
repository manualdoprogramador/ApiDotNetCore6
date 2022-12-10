using System;
using MP.ApiDotNet6.Domain.Entities;

namespace MP.ApiDotNet6.Domain.Repositories
{
	public interface IUserRepository
	{
		Task<User?> GetUserByEmailAndPasswordAsync(string email, string password);
	}
}

