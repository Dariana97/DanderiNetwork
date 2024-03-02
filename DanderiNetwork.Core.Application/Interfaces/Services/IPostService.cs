using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetwork.Core.Domain.Entities;


namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IPostService : IGenericService<SavePostViewModel, PostViewModel, Post>
    {

    }
}
