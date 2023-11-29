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
        // 1. Mandar user y token al frontend y empezar a refactorizar frontend en base a eso, arreglar login y register (Si es posible comentar todo lo relacionado con Posts y Comentarios para que no interfiera, dejar para ultimo), y la forma de guardar el state
        //    Revisar si es posible actualizar a angular 17 tanto local como el proyecto, actualizarnos en ngrx y ver como usamos signals para el state
        // 2. Implementar subir foto de perfil
        // 3. Refactorizar todo en componentes
        // 4. Implementar Posts y Comentarios
        
    }
}
