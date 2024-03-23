using DanderiNetwork.Core.Application.Enums;
using DanderiNetwork.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;


namespace DanderiNetwork.Infraestructure.Identity.Seeds
{
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));

        }
    }
}
