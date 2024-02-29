using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Domain.Common
{
    public class BaseEntityForComments : BaseEntity
    {
        public int PostID { get; set; }
        public int UserID { get; set; }
        public string Content { get; set; }
    }
}
