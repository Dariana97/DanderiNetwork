using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Application.ViewModels.User
{
    public class SaveUserViewModel
    {   
        [Required(ErrorMessage = "Must enter your firtname")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Must enter your lastname")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Must enter a Username")]
        [DataType(DataType.Text)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Must enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "The password no match")]
        [DataType(DataType.Password)]
        public string? ConfirmPassword { get; set; }       

        [Required(ErrorMessage = "Must enter a email address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Must enter a phonenumber")]
        [DataType(DataType.Text)]
        public string Phone { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Photo { get; set; }

        public string? ImageURL { get; set; }

        public bool? HasError { get; set; }
        public string? Error { get; set; }
    }
}
