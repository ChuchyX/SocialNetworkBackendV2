using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SocialNetworkBackendV2.Domain.Entities;

namespace SocialNetworkBackendV2.Infraestructure.DbContexts
{
    public partial class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {

        }      
        public virtual DbSet<User> Users { get; set; }
    }
}
