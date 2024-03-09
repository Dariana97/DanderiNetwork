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
        #region Settings
        private readonly ICommentService _commentService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFollowingService _followingService;
        private readonly AuthenticationResponse userViewModel;

        public PostService(IFollowingService followingService,IPostRepository postRepository, ICommentService commentService, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(postRepository,mapper)
        {
            _followingService = followingService;
            _commentService = commentService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
        }
        #endregion

        public override async Task<List<PostViewModel>> GetAllViewModel()
        {
            
            var modelList = await base.GetAllViewModel();
			var comments = await _commentService.GetAllViewModel();
            
			modelList = modelList.Where(p => p.UserID == userViewModel.Id).ToList();

			modelList.ForEach(async post => {
                post.UserName = userViewModel.UserName;
                post.Name = userViewModel.Name;
                post.LastName = userViewModel.Lastname;
                post.CommentList = comments.Where(p => p.PostID == post.ID).ToList();
            });

			return _mapper.Map<List<PostViewModel>>(modelList).OrderByDescending(i => i.Created).ToList(); 
        }

        public override async Task<PostViewModel> GetByIdViewModel(int id)
        {
            var comments = await _commentService.GetAllViewModel();
            PostViewModel model = await base.GetByIdViewModel(id);
            model.CommentList = comments.Where(cm => cm.PostID == id).ToList();

            return model;
        }

		//     public  async Task<List<PostViewModel>> GetPostForFollow()
		//     {
		//         var follow = await _followingService.GetAllFollows();
		//         var modelList = await base.GetAllViewModel();
		//         var comments = await _commentService.GetAllViewModel();
		//         List<PostViewModel> posts = new();

		//         foreach (var fw in follow) {
		//         posts.Add(modelList.Where(u => u.UserID == fw.FollowingUserID).FirstOrDefault());
		//         }

		//         posts.ForEach( post => {
		//             //post.UserName = follow.Where(u => u.FollowingUserID == post.UserID).FirstOrDefault().UsernameUserFollowed;
		//             //post.CommentList = comments.Where(p => p.PostID == post.ID).ToList();
		//             post.CommentList = new List<ViewModels.Comment.CommentViewModel>();

		//});

		//         return _mapper.Map<List<PostViewModel>>(modelList).OrderByDescending(i => i.Created).ToList();
		//     }
		//public async Task<List<PostViewModel>> GetPostForFollow()
		//{
		//	var follow = await _followingService.GetAllFollows();
		//	var modelList = await base.GetAllViewModel();
		//	var comments = await _commentService.GetAllViewModel();   Sirve pero solo me trae un post por cada follow
		//	List<PostViewModel> posts = new List<PostViewModel>();

		//	foreach (var fw in follow)
		//	{
		//		var post = modelList.FirstOrDefault(u => u.UserID == fw.FollowingUserID);
		//		if (post != null)
		//		{
		//			post.CommentList = comments.Where(p => p.PostID == post.ID).ToList();
		//			posts.Add(post);
		//		}
		//	}

		//	return posts.OrderByDescending(i => i.Created).ToList();
		//}

		public async Task<List<PostViewModel>> GetPostForFollow()
		{
			var follow = await _followingService.GetAllFollows();
			var modelList = await base.GetAllViewModel();
			var comments = await _commentService.GetAllViewModel();
			List<PostViewModel> posts = new List<PostViewModel>();

			foreach (var fw in follow)
			{
				var userPosts = modelList.Where(u => u.UserID == fw.FollowingUserID).ToList();
				foreach (var post in userPosts)
				{
					post.UserName = fw.UsernameUserFollowed;
				    post.Name = fw.NameUserFollowed;
					post.LastName = fw.LastNameUserFollowed;
					post.CommentList = comments.Where(p => p.PostID == post.ID).ToList();
					posts.Add(post);
				}
			}

			return posts.OrderByDescending(i => i.Created).ToList();
		}

		public override async Task<SavePostViewModel> Add(SavePostViewModel vm)
		{
            vm.UserID = userViewModel.Id; 
			

			return await base.Add(vm);
		}
	}
}
