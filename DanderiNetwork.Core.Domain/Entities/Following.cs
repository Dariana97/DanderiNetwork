using DanderiNetwork.Core.Domain.Common;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Following : BaseEntity
    {
        public string UserMainID { get; set; }
        public string FollowingUserID { get; set; }
     
    }
}
