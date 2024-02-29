using DanderiNetwork.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Domain.Entities
{
    public class User : BaseEntityWithImage
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Token { get; set; }
        public bool? IsActived { get; set; }

        //Navigation Properties

        public ICollection<Following>? Following { get; set; }
        public ICollection<Post>? Posts { get; set; }

    }
}
