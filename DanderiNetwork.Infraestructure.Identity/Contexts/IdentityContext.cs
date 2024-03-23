using DanderiNetwork.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace DanderiNetwork.Infraestructure.Identity.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            base.OnModelCreating(modelBuilder);

            //modelBuilder.HasDefaultSchema("Identity");  Esto usa el schema de identity, en caso de querer usar el dbo
            //se debe quitar el hasdefaultschema

            modelBuilder.Entity<ApplicationUser>(entity => {entity.ToTable(name: "Users");});
			modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable(name: "Claims"); });
			modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable(name: "RoleClaims"); });
			modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable(name: "UserTokens"); });

			modelBuilder.Entity<IdentityRole>(entity => {entity.ToTable(name: "Roles");});

            modelBuilder.Entity<IdentityUserRole<string>>(entity => {entity.ToTable(name: "UserRoles");});
                    
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => {entity.ToTable(name: "UserLogin");});







        }
    }
}

