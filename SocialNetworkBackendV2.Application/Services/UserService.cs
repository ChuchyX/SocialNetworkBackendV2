using SocialNetworkBackendV2.Application.DTOs_and_Response_Models;
using SocialNetworkBackendV2.Application.Interfaces;
using SocialNetworkBackendV2.Domain.Entities;
using SocialNetworkBackendV2.Application.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserServiceResponse> RegisterUserAsync(UserRegisterDto userDto)
        {
            var result = _userRepository.GetByEmail(userDto.Email);
            if(result.Result)
                return new UserServiceResponse { Success = false, Message = "There is already a registered user with this email" };

            Utilities.CreatePasswordHash(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User()
            {
                Email = userDto.Email,
                Username = userDto.Username,
                Edad = userDto.Edad,
                Sexo = userDto.Sexo,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
            };
            await _userRepository.Add(user);

            return new UserServiceResponse { Success = true, Message = "The user was successfully registered" };
        }
    }
}
