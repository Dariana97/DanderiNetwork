using DanderiNetwork.Core.Application.Enums;
using DanderiNetwork.Core.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Data;


namespace DanderiNetwork.Infraestructure.Identity.Seeds
{
    public static class DefaultUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser defaultUser = new();
            defaultUser.UserName = "Coquito1010";
            defaultUser.Email = "darianacabreja@gmail.com";
            defaultUser.FirstName = "Dariana";
            defaultUser.LastName = "Cabreja";
            defaultUser.PhoneNumber = "+1(829) 802-1292";
            defaultUser.ImageURL = "https://img.maspormas.com/2015/12/2-Chihuahua-1160x1160.jpeg";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "@Coquito1010");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());

                }
            }



        }
    }
}
