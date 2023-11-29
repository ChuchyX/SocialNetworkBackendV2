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
        Task<bool> Add(User user, string password);
        Task<bool> ExistsEmail(string email);
        Task<IList<User>> GetAll();
        //void AssignToken(User user, string token);
    }
}
