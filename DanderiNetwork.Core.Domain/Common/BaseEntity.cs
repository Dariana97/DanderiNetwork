
using System.ComponentModel.DataAnnotations;


namespace DanderiNetwork.Core.Domain.Common
{
    public class BaseEntity
    {
        [Key]
        public virtual int ID { get; set; }
        public DateTime Created { get; set; }
    }
}
