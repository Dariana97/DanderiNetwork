﻿using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.User;
using DanderiNetworkApp.Midleware;
using DanderiNetwork.Core.Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using DanderiNetwork.Core.Application.Dtos.User;


namespace DanderiNetworkApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
       
        private readonly ICommentService _commentService;
        private readonly IUserApplication _userApplication;

        public UserController(IUserService userService, IUserApplication userApplication,  ICommentService commentService)
        {
            _userService = userService;
           
            _commentService = commentService;
            _userApplication = userApplication;
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult Index()
        {
            return View();
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            AuthenticationResponse userVm = await _userService.LoginAsync(vm);
            if (userVm != null && userVm.HasError != true)
            {

                HttpContext.Session.Set<AuthenticationResponse>("user", userVm);

                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                vm.HasError = userVm.HasError;
                vm.Error = userVm.Error;
                return View(vm);
            }

        }

        
        private string UploadFile(IFormFile file, string ID, bool isEditMode = false, string imageURL = "")
        {
            if (isEditMode && file == null)
            {
                return imageURL;
            }
            /* Get file directory */

            string basePath = $"/images/users/{ID}";
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


    

        public async Task<IActionResult> Register()
        {
            return View(new SaveUserViewModel());
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> Register(SaveUserViewModel vm)
        {

			//var origin = Request.Host.Value;
			//Esto de acceder al Host directamente es provicional

			var origin = Request.Headers["origin"];

			RegisterResponse response = await _userService.RegisterAsync(vm, origin);

            UserResponse user = await _userApplication.GetByEmailUser(vm.Email);

            UpdateUserViewModel UpdateReVM = new()
            {
                Id = user.ID,
                Email = user.Email
            };
            
            if (response.HasError != true)
            {
                UpdateReVM.ImageURL = UploadFile(vm.Photo, UpdateReVM.Id);
                await _userService.Update(UpdateReVM);
                return View("Index");
            }
            
            return View();
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            string response = await _userService.ConfirmEmailAsync(userId, token);
            return View("ConfirmEmail", response);
        }

        public async Task<IActionResult> LogOut()
        {
            await _userService.SignOutAsync();
            HttpContext.Session.Remove("user");
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var origin = Request.Headers["origin"];
            ForgotPasswordResponse response = await _userService.ForgotPasswordAsync(vm, origin);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }


        [ServiceFilter(typeof(LoginAuthorize))]
        public IActionResult ResetPassword(string token)
        {
            return View(new ResetPasswordViewModel { Token = token });
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            ResetPasswordResponse response = await _userService.ResetPasswordAsync(vm);
            if (response.HasError)
            {
                vm.HasError = response.HasError;
                vm.Error = response.Error;
                return View(vm);
            }
            return RedirectToRoute(new { controller = "User", action = "Index" });
        }

        public async Task<IActionResult> AccessDenied()
        {
            
           
            return View(await _commentService.GetCommentsByPostId(2));
            

        }
    }
}