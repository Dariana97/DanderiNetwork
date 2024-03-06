

namespace DanderiNetwork.Core.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public int ID { get; set; }
        public DateTime Created { get; set; }
        public int? PostID { get; set; }
        public string UserID { get; set; }
        public string? UserIDReplied { get; set; }
        public string UserName { get; set; }
        public string? UserNameReplied { get; set; }
        public string Content { get; set; }
        public int? IdReference { get; set; }
        public List<CommentViewModel>? Replies { get; set; }

    }
}
