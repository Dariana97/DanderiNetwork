using DanderiNetwork.Core.Application.Dtos.User;


namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IUserApplication
    {
        List<UserResponse> GetAllUsers();
    }
}
