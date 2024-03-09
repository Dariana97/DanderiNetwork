using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetworkApp.Midleware;
using DanderiNetworkApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DanderiNetworkApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        #region Configuration
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
        #endregion


        #region Post
        
        public async Task<IActionResult> EditPost([FromRoute] int id)
        {
           SavePostViewModel vm = _mapper.Map<SavePostViewModel>(await _postService.GetByIdViewModel(id));
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(SavePostViewModel vm)
        {


            vm.Created = DateTime.Now;
            if (vm.VideoUrl == null && vm.Photo != null)
            {
                vm.ImageURL = UploadFile(vm.Photo, vm.ID, true, vm.ImageURL);
                await _postService.Update(vm, vm.ID);
            }
            await _postService.Update(vm, vm.ID);



            return RedirectToRoute(new { controller = "Home", action = "Index" });


           
        }

		public async Task<IActionResult> Index()
        {
            
			return View(await _postService.GetAllViewModel());

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

			if (vm.VideoUrl == null && vm.Photo != null)
            {
				postSaving.ImageURL = UploadFile(vm.Photo, postSaving.ID);
				await _postService.Update(postSaving, postSaving.ID);
			}
	


            if (postSaving != null)
            {
                ViewBag.Suceess = "Post was save successfully";
                return RedirectToRoute(new { controller = "Home", action = "Index" }); 
            }
            ViewBag.Suceess = "Problems while saving your post";
            return View("Index");


        }

        #endregion


        #region CommentsServices
        public async Task<IActionResult> Comments(int ID)
        {
            var vm = await _postService.GetByIdViewModel(ID);

            return View(vm);
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

        public async Task<IActionResult> EditComment(CommentViewModel vm)
        {
            SaveCommentViewModel svm = _mapper.Map<SaveCommentViewModel>(vm);
            await _commentService.Update(svm, svm.ID);

            return View("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddCommentToPost(SaveCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Suceess = "Your comment wasn't saved";
                return RedirectToRoute(new { controller = "Home", action = "Index" });

            }
            vm.Created = DateTime.Now;  
            var commentSaving = await _commentService.Add(vm);

            if (commentSaving != null)
            {
                
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            ViewBag.Suceess = "Problems while saving your post";
            return RedirectToRoute(new { controller = "Home", action = "Index" });
        }

        [HttpPost]
        public async Task<IActionResult> Replies(SaveCommentViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Suceess = "Your comment wasn't saved";
                return RedirectToAction("Comments", new { ID = vm.PostID });

            }
            vm.Created = DateTime.Now;
            var commentSaving = await _commentService.Add(vm);

            if (commentSaving != null)
            {

                return RedirectToAction("Comments", new { ID = vm.PostID });
            }
            ViewBag.Suceess = "Problems while saving your post";
            return RedirectToAction("Comments", new { ID = vm.PostID });
        }

        #endregion


        #region Secondary services

        private string UploadFile(IFormFile file, int ID, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }
            /* Get file directory */

            string basePath = $"/images/imagePost/{ID}";
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot{basePath}");

            // Create user folder if not exists
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            /* Get file path */

            // Gets the name of the original file
            FileInfo fileInfo = new(file.FileName);

            //Create a unique ID
            Guid guid = Guid.NewGuid();

            string fileName = guid + fileInfo.Extension;
            string fileNameWithPath = Path.Combine(path, fileName);

            using (var stream = new FileStream(fileNameWithPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            if (isEditMode)
            {
                string[] oldImagePart = imageURL.Split('/');
                string oldImageName = oldImagePart[^1];
                string completeImageOldPath = Path.Combine(path, oldImageName);

                if (System.IO.File.Exists(completeImageOldPath))
                {
                    System.IO.File.Delete(completeImageOldPath);
                }
            }

            return $"{basePath}/{fileName}";
        }
        #endregion
    }
}
