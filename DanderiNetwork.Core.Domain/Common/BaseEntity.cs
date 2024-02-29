using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Domain.Common
{
    public class BaseEntity
    {
        public virtual string ID { get; set; }
        public DateTime Created { get; set; }
    }
}
