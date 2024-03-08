using AutoMapper;
using DanderiNetwork.Core.Application.Dtos.Account;
using DanderiNetwork.Core.Application.Interfaces.Entities;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Domain.Entities;
using DanderiNetwork.Core.Application.Dtos.User;
using Microsoft.AspNetCore.Http;
using DanderiNetwork.Core.Application.Helpers;

namespace DanderiNetwork.Core.Application.Services
{
    public class CommentServices : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserApplication _UserApplication;
        private readonly AuthenticationResponse userViewModel;
		private readonly IHttpContextAccessor _httpContextAccessor;
		private readonly AuthenticationResponse _userViewModel;


		public CommentServices(IHttpContextAccessor httpContextAccessor,ICommentRepository commentRepository, IMapper mapper, IUserApplication UserRepository) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _UserApplication = UserRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = userViewModel = _httpContextAccessor.HttpContext.Session.Get<AuthenticationResponse>("user");



		}

		public override async Task<SaveCommentViewModel> Add(SaveCommentViewModel vm)
		{

            vm.UserID = _userViewModel.Id;
			SaveCommentViewModel Comment = await base.Add(vm);
      
			return Comment;
		}

		//public override async Task<List<CommentViewModel>> GetAllViewModel()
		//{
		//    var comments = await base.GetAllViewModel();

		//    List<CommentViewModel> mainComments = new();

		//    var mainComents = comments.Select(cm =>
		//    {
		//        if (cm.IdReference != 0)
		//        {
		//            mainComments.Add(cm);
		//        }
		//        return cm;
		//    }

		//    ).ToList();

		//    foreach (var comment in mainComments)
		//    {
		//        comment.Replies = comments.Where(reply => reply.IdReference == comment.ID).ToList();
		//    }

		//    return _mapper.Map<List<CommentViewModel>>(mainComents);

		//}

		public async Task<List<CommentViewModel>> GetAllViewModel()
        {
            //    var comments = await base.GetAllViewModel();
            //    var Users =  _UserApplication.GetAllUsers();


            //    List<CommentViewModel> mainComments = comments.Where(c => c.PostID == postId && c.IdReference == null).ToList();


            //    foreach(var comment in mainComments)
            //    {
            //        var userMain = Users?.Where(u => u.ID == comment.UserID).FirstOrDefault();




            //                comment.UserName = userMain.UserName;//esto tiene saco de disparate
            //                comment.UserID = userMain.ID;


            //        comment.PostID = postId; //posibles erroes en este atributo



            //    }
            //    foreach (var comment in mainComments)
            //    {

            //        var commentsReplies = comments.Where(c => c.IdReference == comment.ID).ToList();



            //        commentsReplies.ForEach(comment =>
            //        {
            //            var userSecond = Users?.Where(u => u.ID == comment.UserIDReplied).FirstOrDefault();
            //            comment.UserName = userSecond.UserName;
            //            comment.UserID = userSecond.ID;

            //        });    


            //        comment.Replies = commentsReplies;



            //    }

            //    return _mapper.Map<List<CommentViewModel>>(mainComments);
            //}

            var comments = await base.GetAllViewModel();
			var users = _UserApplication.GetAllUsers();

			List<CommentViewModel> mainComments = comments
                .Where(c => c.IdReference == null)
                .ToList();

            mainComments.ForEach(comment =>
            {
                var userMain = users?.FirstOrDefault(u => u.ID == comment.UserID);
                if (userMain != null)
                {
                    comment.UserName = userMain.UserName;
                    comment.UserID = userMain.ID;
                }

                //comment.PostID = postId;

                comment.Replies = comments
                    .Where(c => c.IdReference == comment.ID)
                    .ToList();

                comment.Replies.ForEach(reply =>
                {
                    var userSecond = users?.FirstOrDefault(u => u.ID == reply.UserIDReplied);
                    if (userSecond != null)
                    {
                        reply.UserName = userMain.UserName;
                        reply.UserNameReplied = userSecond.UserName;
                        reply.UserID = userSecond.ID;
                    }
                });
            });

            return _mapper.Map<List<CommentViewModel>>(mainComments);




        }



	}


}