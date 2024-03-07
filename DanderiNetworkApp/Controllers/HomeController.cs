using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetworkApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DanderiNetworkApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        private readonly IFollowingService _followingService;
        private readonly IMapper _mapper;

        public HomeController(IMapper mapper,ILogger<HomeController> logger, ICommentService commentService, IPostService postService, IFollowingService followingService)
        {
            _logger = logger;
            _commentService = commentService;
            _postService = postService;
            _followingService = followingService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {


            return View();

        }

        public async Task<IActionResult> EditComment(CommentViewModel vm)
        {
			SaveCommentViewModel svm = _mapper.Map<SaveCommentViewModel>(vm);
            await _commentService.Update(svm, svm.ID);

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(SavePostViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Suceess = "This post is invalid";
                return View("Index");

            }
            vm.Created = DateTime.Now;
            var postSaving = await _postService.Add(vm);

            if (postSaving != null)
            {
                ViewBag.Suceess = "Post was save successfully";
                return View("Index");
            }
            ViewBag.Suceess = "Problems while saving your post";
            return View("Index");


        }

        [HttpGet]
        public async Task<IActionResult> DeleteComent([FromRoute] int id)
        {
            await _commentService.Delete(id);
            return View("Index");

        }

        [HttpGet]
        public async Task<IActionResult> DeletePost([FromRoute] int id)
        {
            await _postService.Delete(id);
            return View("Index");

        }


        [HttpPost]
        public async Task<IActionResult> AddCommentToPost(SaveCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Suceess = "Your comment wasn't saved";
                return View("Index");

            }
            vm.Created = DateTime.Now;  
            var commentSaving = await _commentService.Add(vm);

            if (commentSaving != null)
            {
                
                return View("Index");
            }
            ViewBag.Suceess = "Problems while saving your post";
            return View("Index");
        }

      


        public IActionResult Privacy()
        {
            return View();
            
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
