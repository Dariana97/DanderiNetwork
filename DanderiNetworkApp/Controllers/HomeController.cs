using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.User;
using DanderiNetworkApp.Midleware;
using DanderiNetworkApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DanderiNetworkApp.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [ServiceFilter(typeof(LoginAuthorize))]
        public async Task< IActionResult> Index()
        {
            SaveUserViewModel vm = new();

            vm.FirstName = "tu";
            vm.LastName = "Mismo";
            vm.Email = "dariana.cabreja.inpha@gmail.com";
            vm.UserName = "ti";
            vm.Password = "@Danderi2910";
            vm.ConfirmPassword = "@Danderi2910";
            vm.Phone = "+1(829) 802-1292";
            vm.ImageURL = @"https://i.pinimg.com/736x/ab/15/be/ab15bedf8a466846e415a64fa1933941.jpg";


            //var origin = Request.Headers["Origin"];
            /* var origin = Request.Headers["origin"];*/
            //HttpRequest context = _httpContextAccessor.HttpContext;



            var origin = Request.Host.Value;

            //string origin = context.Request.Headers["Origin"].ToString();


            RegisterResponse response = await _userService.RegisterAsync(vm, origin);
            return View();

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
