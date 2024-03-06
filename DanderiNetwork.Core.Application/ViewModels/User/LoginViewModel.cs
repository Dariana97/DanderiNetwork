using System.ComponentModel.DataAnnotations;

namespace DanderiNetwork.Core.Application.ViewModels.User
{
    public class LoginViewModel
    {
		[Required(ErrorMessage = "You must enter the username.")]
		[DataType(DataType.Text)]
		public string Username { get; set; }

        [Required(ErrorMessage = "You must enter the password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
