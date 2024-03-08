using DanderiNetwork.Core.Application.Dtos.Account;
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

        public  List<UserResponse> GetAllUsers()
        {
            return  _userManager.Users.Select(user =>

            new UserResponse
            {

                ID = user.Id,
                Name = user.FirstName,
                Email = user.Email,
                ImageURL = user.ImageURL,
                UserName = user.UserName,
                Lastname = user.LastName,
                PhoneNumber = user.PhoneNumber,
                

            }).ToList();
        }

        public async Task <UserResponse> GetByEmailUser(string email)
        {
            UserResponse response = new()
            {
                HasError = false,

            };
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                response.HasError = true;
                response.Error = "This user doesn't exist";
                return response;
            }
            response.ID = user.Id;
            response.ImageURL = user.ImageURL;
         

  
            return response;
        }


        public async Task<UserResponse> GetByUserName(string UserName)
        {
            UserResponse response = new()
            {
                HasError = false,

            };
            try
            {
				var user = await _userManager.FindByNameAsync(UserName);
                if (user != null)
                {
                    response.ID = user.Id;

                    response.ImageURL = user.ImageURL;
                }
                else
                {
                    throw new Exception();
                }
				return response;
			}
            catch(Exception ex) { 
				response.HasError = true;
				response.Error = "This user doesn't exist";
				return response;
			}
           
           



            
        }

        public async Task<UpdateUserResponse> Update(UpdateUserRequest request)
        {
            UpdateUserResponse response = new() { HasError = false };

            ApplicationUser user = await _userManager.FindByIdAsync(request.Id);
            if (user == null)
            {
                response.HasError = true;
                response.Error = "This user doesn't exit";
                return response;
            }

            user.ImageURL = request.ImageURL;
            var result = await _userManager.UpdateAsync(user);


            if (!result.Succeeded)
            {
                response.HasError = true;
                response.Error = $"An error occurred while update user";
                return response;
            }

            return response;


        }




    }
}
