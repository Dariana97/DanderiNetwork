
using DanderiNetwork.Core.Application.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;

namespace DanderiNetwork.Infraestructure.Identity.Entities
{
    public class ApplicationUser : IdentityUser, IUserApp
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ImageURL { get; set; }

    }
}
