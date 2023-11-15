using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.DTOs_and_Response_Models
{
    public class UserRegisterDto
    {
        [Required]
        [NotNull]
        public string Username { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string Password { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public string Email { get; set; } = string.Empty;

        [Required]
        [NotNull]
        public int Edad { get; set; }

        [Required]
        [NotNull]
        public string Sexo { get; set; } = string.Empty;
    }
}
