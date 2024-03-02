using DanderiNetwork.Core.Domain.Common;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Following : BaseEntity
    {
        public int UserMainID { get; set; }
        public int FollowingUserID { get; set; }
    }
}
