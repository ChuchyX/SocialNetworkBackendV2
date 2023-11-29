using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SocialNetworkBackendV2.Application.Interfaces;
using SocialNetworkBackendV2.Domain.Entities;
using SocialNetworkBackendV2.Infraestructure.DbContexts;
using SocialNetworkBackendV2.Infraestructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetworkBackendV2.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")/*, b => b.MigrationsAssembly("SocialNetworkBackendV2.API")*/).EnableSensitiveDataLogging();
            });
                              
            services.AddScoped<IUserRepository, UserRepository>();
           
            return services;
        }
    }
}
