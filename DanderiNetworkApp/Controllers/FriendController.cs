using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Following;
using Microsoft.AspNetCore.Mvc;
namespace DanderiNetworkApp.Controllers

{
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
            ViewData["UserViewModel"] = _userApplication.GetAllUsers();
            return View(await _postService.GetAllViewModel());
        }

        //public async Task<IActionResult> Follow(string username)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        ViewBag.Suceess = "Invalid action";
        //        return View("Index");

        //    }

        //    var user = await _userApplication.GetByUserName(username);
        //    vm.Created = DateTime.Now;
        //    var FollowingSaving = await _followingService.Add(user);

        //    if (FollowingSaving != null)
        //    {
        //        return View("Index"); //vista para seguidores, se debe modificar el acceso al index
        //    }

        //    return View("Index"); //vista para seguidores, se debe modificar el acceso al index

        //}

        //public async Task<IActionResult> UnFollow(int id)
        //{

        //    try
        //    {
        //        await _followingService.Delete(id);
        //        return View("Index"); //vista para seguidores, se debe modificar el acceso al index
        //    }
        //    catch (Exception ex)
        //    {
        //        return View("Index"); //vista para seguidores, se debe modificar el acceso al index
        //    }

        //}



    }
}
