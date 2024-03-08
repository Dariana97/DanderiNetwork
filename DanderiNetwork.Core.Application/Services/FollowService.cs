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
    public class FollowService : IFollowingService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public readonly IFollowingRepository _followingRepository;
        private readonly AuthenticationResponse userViewModel;
        private readonly IMapper _mapper;
        private readonly IUserApplication _userApplication;

        public FollowService(IUserApplication userApplication, IFollowingRepository repository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _followingRepository = repository;
            _httpContextAccessor = httpContextAccessor;
            _mapper = mapper;
            userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");
            _userApplication = userApplication;

        }

        public async Task<List<FollowingViewModel>> GetAllFollows()
        {
            var user = _userApplication.GetAllUsers();

            List<Following> modelList = await _followingRepository.GetAllAsync();
            var follows = modelList.Select(x => new FollowingViewModel {
                ID = x.ID,
                UserMainID = x.UserMainID,
                NameUserFollowed = user.Where(u => u.ID == x.FollowingUserID).FirstOrDefault().Name,
                FollowingUserID = x.FollowingUserID,
                Created = x.Created,
                UsernameUserFollowed = user.Where(u => u.ID == x.FollowingUserID).FirstOrDefault().UserName,
                ImageURL = user.Where(u => u.ID == x.FollowingUserID).FirstOrDefault().ImageURL,
                LastNameUserFollowed = user.Where(u => u.ID == x.FollowingUserID).FirstOrDefault().ImageURL

            });

            List<FollowingViewModel> followedfilters = 
                follows.
                Where(F => F.UserMainID == userViewModel.Id)
                .ToList();

            return followedfilters;

            


        }


        public async Task<FollowingViewModel> Follow(string ID)
        {
            SaveFollowingViewModel vm = new();
            vm.UserMainID = userViewModel.Id;
            vm.FollowingUserID = ID;
            vm.Created = DateTime.Now;
            var mapModel = _mapper.Map<Following>(vm);
            mapModel = await _followingRepository.AddAsync(mapModel);

            var mapModels = _mapper.Map<FollowingViewModel>(mapModel);

            return mapModels;
        }

        public async Task UnFollow(int ID)
        {
            var relationship = await _followingRepository.GetByIdAsync(ID);
            await _followingRepository.DeleteAsync(relationship);
            
        }




        }


}



    


