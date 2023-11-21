using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Application.DTOs_and_Response_Models
{
    public class UserServiceResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        //dos propiedades mas un user y un lsta de users qu pueden ser nulos
    }
}
