using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Domain.Entities
{
    public partial class User : IdentityUser
    {
        public int Id { get; set; }
        public int Edad { get; set; }
        public string Sexo { get; set; }    
        public string ProfilePicture { get; set; } = string.Empty;
    }
}
