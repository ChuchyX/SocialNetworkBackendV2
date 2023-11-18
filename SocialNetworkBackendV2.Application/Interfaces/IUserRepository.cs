using SocialNetworkBackendV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.Interfaces
{
    public interface IUserRepository
    {
        Task Add(User user);
        Task<bool> GetByEmail(string email);
        Task<IList<User>> GetAll();
    }
}
