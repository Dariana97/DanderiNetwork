using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DanderiNetwork.Core.Application.ViewModels.User
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageURL { get; set; }

        public string Email { get; set; }

        public bool HasError { get; set; }
        public string? Error { get; set; }
    }
}
