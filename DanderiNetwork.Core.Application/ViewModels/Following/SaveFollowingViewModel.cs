

using System.ComponentModel.DataAnnotations;

namespace DanderiNetwork.Core.Application.ViewModels.Following
{
    public class SaveFollowingViewModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime? Created { get; set; }
        public string? UserMainID { get; set; }      
        public string FollowingUserID { get; set; }
    }
}
