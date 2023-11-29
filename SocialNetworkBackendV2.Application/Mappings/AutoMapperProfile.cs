using AutoMapper;
using SocialNetworkBackendV2.Application.DTOs_and_Response_Models;
using SocialNetworkBackendV2.Application.Utility_Classes;
using SocialNetworkBackendV2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<UserRegisterDto, User>();     
            CreateMap<User, UserDto>()
                .AfterMap((src, dest) =>
                {
                    if (dest.ProfilePicture != "")
                        dest.ProfilePicture = Utilities.ImageToBase64(dest.ProfilePicture);
                });
        }
    }
}
