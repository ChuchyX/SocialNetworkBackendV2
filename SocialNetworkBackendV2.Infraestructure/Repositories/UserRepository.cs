using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserRepository> _logger;

        public UserRepository(UserDbContext context, ILogger<UserRepository> logger)
        {
            _userContext = context;
            _logger = logger;
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

        public async Task<bool> ExistsAny(string email)
        {     
            return _userContext.Users.ToList().Any(x => x.Email == email); 
        }
    }
}
