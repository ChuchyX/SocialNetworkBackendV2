using SocialNetworkBackendV2.Application.DTOs_and_Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.Interfaces
{
    public interface IUserService
    {
        Task<UserServiceResponse> RegisterUserAsync(UserRegisterDto userDto);
        Task<UserServiceResponse> LoginUserAsync(UserLoginDto userLoginDto);
    }
}
