

namespace DanderiNetwork.Core.Application.ViewModels.Comment
{
    public class CommentViewModel
    {
        public virtual string ID { get; set; }
        public DateTime Created { get; set; }
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
        public int? IdReference { get; set; }
        public List<CommentViewModel>? Replies { get; set; }

    }
}
