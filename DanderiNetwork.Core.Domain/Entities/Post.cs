using DanderiNetwork.Core.Domain.Common;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Post : BaseEntityWithImage
    {
        public string? VideoUrl { get; set; }
        public string Caption { get; set; }
        public int UserID { get; set; }

        //navigator properties
        public User? User { get; set; }

        public ICollection<Comment>? Comments { get; set; }
    }
}
