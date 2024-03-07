using AutoMapper;
using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Helpers;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetwork.Core.Application.ViewModels.User;
using DanderiNetwork.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DanderiNetwork.Core.Application.Services
{
    public class PostService : GenericService<SavePostViewModel, PostViewModel, Post>, IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AuthenticationResponse userViewModel;

        public PostService(IPostRepository postRepository, ICommentService commentService, IUserService userService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(postRepository,mapper)
        {
            _postRepository = postRepository;
            _commentService = commentService;
            _userService = userService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {
            
            var modelList = await base.GetAllViewModel();
			var comments = await _commentService.GetAllViewModel();
			modelList = modelList.Where(p => p.UserID == userViewModel.Id).ToList();

			modelList.ForEach(async post => {

                post.UserName = userViewModel.UserName;
                post.CommentList = comments.Where(p => p.PostID == post.ID).ToList();
            

            }); 

            return _mapper.Map<List<PostViewModel>>(modelList);
        }

		public override async Task<SavePostViewModel> Add(SavePostViewModel vm)
		{
            vm.UserID = userViewModel.Id;
			

			return await base.Add(vm);
		}
	}
}
