using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Following;
using Microsoft.AspNetCore.Mvc;
namespace DanderiNetworkApp.Controllers




{
    public class FriendController : Controller
    {
        private readonly IFollowingService _followingService;

        public FriendController(IFollowingService followingService)
        {
            _followingService = followingService;
        }

        public async Task<IActionResult>  Index()
        {
            

            return View();
        }

        public async Task<IActionResult> Follow(SaveFollowingViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Suceess = "Invalid action";
                return View("Index");

            }
            vm.Created = DateTime.Now;
            var FollowingSaving = await _followingService.Add(vm);

            if (FollowingSaving != null)
            {
                return View("Index"); //vista para seguidores, se debe modificar el acceso al index
            }

            return View("Index"); //vista para seguidores, se debe modificar el acceso al index

        }

        public async Task<IActionResult> UnFollow(int id)
        {

            try
            {
                await _followingService.Delete(id);
                return View("Index"); //vista para seguidores, se debe modificar el acceso al index
            }
            catch (Exception ex)
            {
                return View("Index"); //vista para seguidores, se debe modificar el acceso al index
            }

        }



    }
}
