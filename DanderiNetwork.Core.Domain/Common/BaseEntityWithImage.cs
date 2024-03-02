using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Domain.Common
{
    public class BaseEntityWithImage : BaseEntity
    {
        public string? ImageURL { get; set; }
        
    }
}
