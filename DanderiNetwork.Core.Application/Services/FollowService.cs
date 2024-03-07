using AutoMapper;
using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Helpers;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Application.ViewModels.User;
using DanderiNetwork.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace DanderiNetwork.Core.Application.Services
{
    public class FollowService : GenericService<SaveFollowingViewModel,FollowingViewModel,Following>, IFollowingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IFollowingRepository _followingRepository;
        private readonly AuthenticationResponse userViewModel;

        private readonly IUserApplication _userApplication;

        public FollowService(IUserApplication userApplication,IFollowingRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(repository, mapper)
        {
            _followingRepository = repository;
            _httpContextAccessor = httpContextAccessor;
           
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _userApplication = userApplication;

        }

        public override async Task<SaveFollowingViewModel> Add(SaveFollowingViewModel vm)
        {

            vm.UserMainID = userViewModel.Id;

            return await base.Add(vm);
        }

        public override async Task<List<FollowingViewModel>> GetAllViewModel()
        {
            var User = _userApplication.GetAllUsers();

            List<FollowingViewModel> modelList = await base.GetAllViewModel();
             var Follows =    modelList.Select(Follow =>
            { 
                var FollowedUser = User.Where(U => U.ID == Follow.FollowingUserID).FirstOrDefault();

                Follow.UsernameUserFollowed = FollowedUser.UserName;
                Follow.NameUserFollowed = FollowedUser.Name;
                Follow.ImageURL = FollowedUser.ImageURL;


                return Follow;

            });

            List<FollowingViewModel> followedFilters = modelList.
                Where(F => F.UserMainID == userViewModel.Id)
                .ToList();

            return followedFilters;

           
        }



    }
}
