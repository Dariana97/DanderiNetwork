using System;
using System.Collections.Generic;
using System.Linq;


namespace DanderiNetwork.Core.Application.ViewModels.Following
{
    public class FollowingViewModel
    {
        public virtual string ID { get; set; }
        public DateTime Created { get; set; }
        //public int UserMainID { get; set; }      por ahora no es necesario//////
        public int FollowingUserID { get; set; }
        public string NameUserFollowed { get; set; }
        public string UserNameUserFollowed { get; set; }
    }
}
