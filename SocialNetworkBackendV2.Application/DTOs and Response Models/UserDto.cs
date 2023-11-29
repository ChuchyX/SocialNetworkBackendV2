using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.DTOs_and_Response_Models
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }
        public string ProfilePicture { get; set; }
    }
}
