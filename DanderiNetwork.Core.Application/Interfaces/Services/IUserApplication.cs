using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Dtos.User;
using DanderiNetwork.Core.Application.ViewModels.User;


namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IUserApplication
    {
        Task<UpdateUserResponse> Update(UpdateUserRequest request);

        Task<UserResponse> GetByEmailUser(string email);
        List<UserResponse> GetAllUsers();
    }
}
