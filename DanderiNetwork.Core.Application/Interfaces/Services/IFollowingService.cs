using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IFollowingService : IGenericService<SaveFollowingViewModel, FollowingViewModel, Following>
    {
 
    }
}
