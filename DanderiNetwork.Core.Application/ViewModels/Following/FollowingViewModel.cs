using System;
using System.Collections.Generic;
using System.Linq;


namespace DanderiNetwork.Core.Application.ViewModels.Following
{
    public class FollowingViewModel
    {
        public int ID { get; set; }

        public DateTime Created { get; set; }
        public string UserMainID { get; set; }      

        public string FollowingUserID { get; set; }
        public string NameUserFollowed { get; set; }
        public string UsernameUserFollowed { get; set; }

        public string ImageURL { get; set; }
    }
}
