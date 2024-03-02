using DanderiNetwork.Core.Application.Dtos.Email;
using DanderiNetwork.Core.Domain.Settings;

namespace DanderiNetwork.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings MailSettings { get; }
        Task SendAsync(EmailRequest request);
    }
}
