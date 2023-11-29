using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        public Task<bool> Add(User user, string password)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExistsEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<IList<User>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
