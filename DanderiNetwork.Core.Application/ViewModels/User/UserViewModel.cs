using DanderiNetwork.Core.Application.ViewModels.Post;

namespace DanderiNetwork.Core.Application.ViewModels.User
{
    public class UserViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string? ImageURL { get; set; }

		public string Email { get; set; }
 
        public string Phone { get; set; }

        public ICollection<PostViewModel>? Posts { get; set; }
    }
}
