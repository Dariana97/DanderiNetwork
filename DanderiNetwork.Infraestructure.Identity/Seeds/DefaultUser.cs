using DanderiNetwork.Core.Application.Enums;
using DanderiNetwork.Infraestructure.Identity.Entities;
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
            defaultUser.ImageURL = @"https://encrypted-tbn0.gstatic.com/images?q=tb
                                     n:ANd9GcRJyH1ZHxlyhepoZNoWyodFO5Z5ejy4WckSSLSjisP4zQ&s";
            defaultUser.EmailConfirmed = true;
            defaultUser.PhoneNumberConfirmed = true;

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "@Danderi2910");
                    await userManager.AddToRoleAsync(defaultUser, Roles.User.ToString());

                }
            }



        }
    }
}
