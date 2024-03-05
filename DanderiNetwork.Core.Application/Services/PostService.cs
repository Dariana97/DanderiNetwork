using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentService _commentService;

        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper, ICommentService commentService) : base(postRepository, mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
            _commentService = commentService;
        }

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {
            
            var modelList = await base.GetAllViewModel();

            var postWithComment = modelList.Select(async post =>  {

                post.CommentList = await _commentService.GetCommentsByPostId(post.ID);

            }) ;

            return _mapper.Map<List<PostViewModel>>(modelList);
        }
    }
}
