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
using Microsoft.AspNetCore.Identity;

namespace SocialNetworkBackendV2.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;

        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration, UserManager<User> userManager)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
            _userManager = userManager;
        }

        public async Task<UserServiceResponse> RegisterUserAsync(UserRegisterDto userDto)
        {
            var userExist = await _userManager.FindByEmailAsync(userDto.Email);
            if (userExist != null) 
                return new UserServiceResponse { Success = false, Message = "There is already a registered user with this email" };

            var result = await _userManager.CreateAsync(_mapper.Map<User>(userDto), userDto.Password);
            if(!result.Succeeded)
                return new UserServiceResponse { Success = false, Message = "There was a problem trying to register the user. Please, try again" };

            return new UserServiceResponse { Success = true, Message = "The user was successfully registered" };
        }
        public async Task<UserServiceResponse> LoginUserAsync(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, userLoginDto.Password))
            {
                return new UserServiceResponse { Success = true, Message = "The user was successfully login", User = _mapper.Map<UserDto>(user), Token = CreateToken(user) };
            }

            return new UserServiceResponse { Success = false, Message = "There was a problem trying to login the user. Wrong email or password" };

        }
        public string CreateToken(User user)
        {
            string role = "User";
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("JWT:Key").Value));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                issuer: _configuration.GetSection("JWT:Issuer").Value,
                claims: claims,
                expires: DateTime.Now.AddDays(double.Parse(_configuration.GetSection("JWT:Lifetime").Value)),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        public async Task<UserServiceResponse> Test(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            return new UserServiceResponse { Success = true, Message = "The user was successfully login", User = _mapper.Map<UserDto>(user) };
        }
    }
}
