using System;
using Microsoft.EntityFrameworkCore;
using MP.ApiDotNet6.Domain.Entities;
using MP.ApiDotNet6.Domain.Repositories;
using MP.ApiDotNet6.Infra.Data.Context;

namespace MP.ApiDotNet6.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;

        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<User?> GetUserByEmailAndPasswordAsync(string email, string password)
        {
            return await _db.Users
                            .Include(x => x.UserPermissions).ThenInclude(x => x.Permission)
                            .FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}

