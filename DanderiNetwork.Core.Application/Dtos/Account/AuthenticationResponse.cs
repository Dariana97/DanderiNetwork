

namespace DanderiNetwork.Core.Application.Dtos.Account
{
    public class AuthenticationResponse
    {
        public string Name { get; set; }
        public string Lastname { get; set; }
        //agregando nuevos atributos arriba
        public string Id { get; set; }
        public string UserName { get; set; }
        public string ImageUrl { get; set; }

        public string Email { get; set; }
        public bool IsVerified { get; set; }
        public bool HasError { get; set; }
        public string? Error { get; set; }
        public List<string> Roles { get; set; }
    }
}
