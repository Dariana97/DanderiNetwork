

namespace DanderiNetwork.Core.Application.ViewModels.Following
{
    public class SaveFollowingViewModel
    {
        public int ID { get; set; }
        public DateTime? Created { get; set; }
        public int? UserMainID { get; set; }      
        public int FollowingUserID { get; set; }
    }
}
