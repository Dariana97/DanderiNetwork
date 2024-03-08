using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IFollowingService 
    {
        Task<FollowingViewModel> Follow(string ID);

        Task<List<FollowingViewModel>> GetAllFollows();
        Task UnFollow(int ID);
    }
}
