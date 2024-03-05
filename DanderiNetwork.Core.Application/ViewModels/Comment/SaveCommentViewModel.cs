using System.ComponentModel.DataAnnotations;

namespace DanderiNetwork.Core.Application.ViewModels.Comment
{
    public class SaveCommentViewModel
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public int? UserID { get; set; }
        public int? IdReference { get; set; }
        public int? UserIDReplied { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Created { get; set; }

        [Required(ErrorMessage = "You must write something.")]
        [DataType(DataType.Text)]
        public string Content { get; set; }
       
    }
}
