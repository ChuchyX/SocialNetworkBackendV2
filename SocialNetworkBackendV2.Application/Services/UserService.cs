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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SocialNetworkBackendV2.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<UserServiceResponse> RegisterUserAsync(UserRegisterDto userDto)
        {
            var result = _userRepository.ExistsEmail(userDto.Email).Result;
            if(result)
                return new UserServiceResponse { Success = false, Message = "There is already a registered user with this email" };

            User user = _mapper.Map<User>(userDto);
            await _userRepository.Add(user);

            return new UserServiceResponse { Success = true, Message = "The user was successfully registered" };
        }
        public async Task<UserServiceResponse> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = _userRepository.GetAll().Result.FirstOrDefault(u => u.Email == userLoginDto.Email && Utilities.VerifyPasswordHash(userLoginDto.Password, u.PasswordHash, u.PasswordSalt));
            if (user == null) return new UserServiceResponse { Success = false, Message = "User Not Found. Wrong Username or Password" };

            _userRepository.AssignToken(user, CreateToken(user));

            if (user.ProfilePicture != "")
                user.ProfilePicture = Utilities.ImageToBase64(user.ProfilePicture);

            return new UserServiceResponse { Success = true, User = _mapper.Map<UserDto>(user) };
        }
        public string CreateToken(User user)
        {
            string role = "User";
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
