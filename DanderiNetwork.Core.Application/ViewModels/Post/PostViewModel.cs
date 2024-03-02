﻿

namespace DanderiNetwork.Core.Application.ViewModels.Post
{
    public class PostViewModel
    {
        public virtual string ID { get; set; }
        public string? VideoUrl { get; set; }
        public string Caption { get; set; }
        public int UserID { get; set; }

        public string? ImageURL { get; set; }
        public DateTime Created { get; set; }

        public List<CommentViewModel>? Comments { get; set; }
    }
}
