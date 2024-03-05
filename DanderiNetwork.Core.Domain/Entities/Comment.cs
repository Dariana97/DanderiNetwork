using DanderiNetwork.Core.Domain.Common;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public int? IdReference { get; set; }
        public int PostID { get; set; }
        public string UserID { get; set; }
        public string? UserIDReplied { get; set; }
        public string Content { get; set; }

        //Navigation Properties
        public Post? Post { get; set; }
        
    }
}
