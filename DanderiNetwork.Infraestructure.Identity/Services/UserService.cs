using DanderiNetwork.Core.Application.Dtos.User;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Infraestructure.Identity.Entities;
using Microsoft.AspNetCore.Identity;

namespace DanderiNetwork.Infraestructure.Identity.Services
{
    public class UserService : IUserApplication
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<UserResponse> GetAllUsers()
        {
            return _userManager.Users.Select(user =>

            new UserResponse
            {

                ID = user.Id,
                Email = user.Email,
                ImageURL = user.ImageURL,
                UserName = user.UserName,
                Lastname = user.LastName,
                PhoneNumber = user.PhoneNumber,
                Name = user.FirstName

            }).ToList();
        }


    }
}
