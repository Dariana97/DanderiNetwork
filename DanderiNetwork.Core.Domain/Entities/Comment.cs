using DanderiNetwork.Core.Domain.Common;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Comment : BaseEntityForComments
    {
        public int? IdReference { get; set; }

        //Navigator Properties
        public Post? Post { get; set; }
        public ICollection<Comment>? Comments { get; set;}
    }
}
