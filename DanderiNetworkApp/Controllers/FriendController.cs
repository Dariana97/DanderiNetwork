using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace DanderiNetworkApp.Controllers

{
	[Authorize]
	public class FriendController : Controller
	{
		private readonly IFollowingService _followingService;
		private readonly IUserApplication _userApplication;
		private readonly ICommentService _commentService;
		private readonly IPostService _postService;
		private readonly IMapper _mapper;

		public FriendController(IFollowingService followingService, IUserApplication userApplication, ICommentService commentService, IPostService postService, IMapper mapper)
		{
			_followingService = followingService;
			_userApplication = userApplication;
			_commentService = commentService;
			_postService = postService;
			_mapper = mapper;
		}

		public async Task<IActionResult> Index()
		{
			ViewData["FollowViewModel"] = await _followingService.GetAllFollows();
			ViewBag.AmoAFiguereo = await _followingService.GetAllFollows();

			return View(await _postService.GetAllViewModel());
		}

		public async Task<IActionResult> Follow(string username)
		{
			var user = await _userApplication.GetByUserName(username);


			if (!user.HasError)
			{
				var FollowingSaving = await _followingService.Follow(user.ID);

				if (FollowingSaving != null)
				{
					return RedirectToRoute(new { controller = "Friend", action = "Index" });
				}

			}

			return RedirectToRoute(new { controller = "Friend", action = "Index" });

		}
		[HttpGet]
		public async Task<IActionResult> UnFollow([FromRoute]int id)
		{

			try
			{
				await _followingService.UnFollow(id);
                return RedirectToRoute(new { controller = "Friend", action = "Index" });
            }
			catch (Exception ex)
			{
                return RedirectToRoute(new { controller = "Friend", action = "Index" });
            }

		}



	}
}
