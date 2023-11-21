using SocialNetworkBackendV2.Application.DTOs_and_Response_Models;
using SocialNetworkBackendV2.Application.Interfaces;
using SocialNetworkBackendV2.Domain.Entities;
using SocialNetworkBackendV2.Application.Utility_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace SocialNetworkBackendV2.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
   
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserServiceResponse> RegisterUserAsync(UserRegisterDto userDto)
        {
            var result = _userRepository.ExistsAny(userDto.Email);
            if(result.Result)
                return new UserServiceResponse { Success = false, Message = "There is already a registered user with this email" };

            User user = _mapper.Map<User>(userDto);
            await _userRepository.Add(user);

            return new UserServiceResponse { Success = true, Message = "The user was successfully registered" };
        }
    }
}
