using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Application.ViewModels.Post
{
    public class SavePostViewModel
    {
        // Se puede quitar el null?
        public int? ID { get; set; }

        [DataType(DataType.Url)]
        public string? VideoUrl { get; set; }

        [Required(ErrorMessage = "You must enter a caption for you post")]
        [DataType(DataType.Text)]
        public string Caption { get; set; }
       
        public int? UserID { get; set; }
        [DataType(DataType.Url)]
        public string? ImageURL { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? Photo { get; set; }
    }
}
