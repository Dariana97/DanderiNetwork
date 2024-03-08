using System.ComponentModel.DataAnnotations;

namespace DanderiNetwork.Core.Application.ViewModels.User
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Debe colocar el correo del usuario")]
        [DataType(DataType.Text)]
        public string Username { get; set; }   
        
        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
