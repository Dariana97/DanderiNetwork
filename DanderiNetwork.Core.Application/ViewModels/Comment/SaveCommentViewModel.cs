using System.ComponentModel.DataAnnotations;

namespace DanderiNetwork.Core.Application.ViewModels.Comment
{
    public class SaveCommentViewModel
    {
        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }
        public int PostID { get; set; }
        public int? UserID { get; set; }

        [Required(ErrorMessage = "you must write something for the content post")]
        [DataType(DataType.Text)]
        public string Content { get; set; }
        public int? IdReference { get; set; }
       
    }
}
