using AutoMapper;
using DanderiNetwork.Core.Application.Interfaces.Entities;
using DanderiNetwork.Core.Application.Interfaces.Repositories;
using DanderiNetwork.Core.Application.Interfaces.Services;
using DanderiNetwork.Core.Application.ViewModels.Comment;
using DanderiNetwork.Core.Domain.Entities;

namespace DanderiNetwork.Core.Application.Services
{
    public class CommentServices : GenericService<SaveCommentViewModel, CommentViewModel, Comment>, ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        private readonly IUserApplication _UserApplication;

        public CommentServices(ICommentRepository commentRepository, IMapper mapper, IUserApplication UserRepository) : base(commentRepository, mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;
            _UserApplication = UserRepository;


    }

        public override async Task<List<CommentViewModel>> GetAllViewModel()
        {
            var comments = await base.GetAllViewModel();

            List<CommentViewModel> mainComments = new();

            var mainComents = comments.Select(cm =>
            {   
                if (cm.IdReference != 0)
                {
                    mainComments.Add(cm);
                }
                return cm;
            }

            ).ToList();

            foreach (var comment in mainComments)
            {
                comment.Replies = comments.Where(reply => reply.IdReference == comment.ID).ToList();
            }

            return _mapper.Map<List<CommentViewModel>>(mainComents);

        }

        public  async Task<List<CommentViewModel>> GetCommentsByPostId(int postId)
        {
            var comments = await base.GetAllViewModel();
            var Users =  _UserApplication.GetAllUsers();


            List<CommentViewModel> mainComments = comments.Where(c => c.PostID == postId && c.IdReference == 0).ToList();


            foreach(var comment in mainComments)
            {
                var userMain = Users?.Where(u => u.ID == comment.UserID).FirstOrDefault();

                var userSecond = Users?.Where(u => u.ID == comment.UserIdReplied).FirstOrDefault();
                foreach(var user in Users)
                {
                    if(user.ID == comment.UserID)
                    {
                        comment.UserName = user.UserName;//esto tiene saco de disparate
                        comment.UserID = user.ID;
                    }
                }
               
                comment.PostID = postId; //posibles erroes en este atributo
                comment.UserIdReplied = userSecond.ID;
                comment.UserNameReplied = userSecond.UserName;

            }
            foreach (var comment in mainComments)
            {
                comment.Replies = comments.Where(c => c.IdReference == comment.ID).ToList();

            }

            return _mapper.Map<List<CommentViewModel>>(mainComments);
        }



    }
}
