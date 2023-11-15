using Microsoft.EntityFrameworkCore;
using SocialNetworkBackendV2.Application.Interfaces;
using SocialNetworkBackendV2.Domain.Entities;
using SocialNetworkBackendV2.Infraestructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Infraestructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _userContext;

        public UserRepository(UserDbContext context)
        {
            _userContext = context;
        }

        public async Task Add(User user)
        {
            await _userContext.Users.AddAsync(user);
            await _userContext.SaveChangesAsync();
        }   

        public async Task<IList<User>> GetAll()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            var user = await _userContext.Users.FirstOrDefaultAsync(u => u.Email == email);
            return user;
        }
    }
}
