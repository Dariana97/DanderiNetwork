using DanderiNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class Reply : BaseEntityForComments
    {
        public int ReferenceCommentID { get; set; }
        public int ReplyID { get; set; }
        public ICollection<Reply> Replies { get; set; }
    }
}
