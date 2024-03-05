using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Domain.Entities;


namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface ICommentService : IGenericService<SaveCommentViewModel, CommentViewModel, Comment>
    {

        Task<List<CommentViewModel>> GetCommentsByPostId(int postId);
    }
}
