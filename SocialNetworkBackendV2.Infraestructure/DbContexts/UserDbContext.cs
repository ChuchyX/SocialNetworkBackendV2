using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBackendV2.Domain.Entities;

namespace SocialNetworkBackendV2.Infraestructure.DbContexts
{
    public partial class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }      
        public virtual DbSet<User> Users { get; set; }


        // siguiente:
        // 2. modificar la creacion de los JWT
        // 4. Definir como vamos a identificar al usuario de la solicitud por su token
        
    }
}
