using AutoMapper;
using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Application.ViewModels.Following;
using DanderiNetwork.Core.Application.ViewModels.Post;
using DanderiNetwork.Core.Application.ViewModels.User;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region PostProfile
            CreateMap<Post, PostViewModel>()
                .ForMember(dest => dest.CommentList, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Post, SavePostViewModel>()
                .ForMember(dest => dest.Photo, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region CommentProfile

            CreateMap<Comment, CommentViewModel>()
                .ForMember(dest => dest.Replies, opt => opt.Ignore())
                .ReverseMap()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            CreateMap<Comment, SaveCommentViewModel>()
                .ReverseMap()
                .ForMember(dest => dest.Comments, opt => opt.Ignore())
                .ForMember(dest => dest.Post, opt => opt.Ignore());

            #endregion

            #region FollowingProfile

            CreateMap<Following, FollowingViewModel>()
                .ForMember(dest => dest.NameUserFollowed, opt => opt.Ignore())
                .ForMember(dest => dest.UsernameUserFollowed, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<Following, SaveFollowingViewModel>()
                .ReverseMap();

            #endregion

            #region UserProfile

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<RegisterRequest, SaveUserViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPasswordViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            #endregion
        }
    }
}
