using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Services
{
    public class CommentServices : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;

        public CommentServices(ICommentRepository commentRepository, IMapper mapper) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
        }

        public override async Task<List<CommentViewModel>> GetAllViewModel()
        {
            var comments = await base.GetAllViewModel();

            List<CommentViewModel> mainComments = new();

            var mainComents = comments.Select(cm =>
            {   
                if (cm.IdReference != 0)
                {
                    mainComments.Add(cm);
                }
                return cm;
            }

            ).ToList();

            foreach (var comment in mainComments)
            {
                comment.Replies = comments.Where(reply => reply.IdReference == comment.ID).ToList();
            }

            return _mapper.Map<List<CommentViewModel>>(mainComents);

        }

        public virtual async Task<List<CommentViewModel>> GetCommentsByPostId(int postId)
        {
            var comments = await base.GetAllViewModel();

            List<CommentViewModel> mainComments = comments.Where(c => c.PostID == postId && c.IdReference == 0).ToList();

            foreach (var comment in mainComments)
            {
                comment.Replies = comments.Where(c => c.IdReference == comment.ID).ToList();
            }

            return _mapper.Map<List<CommentViewModel>>(mainComments);
        }



    }
}
