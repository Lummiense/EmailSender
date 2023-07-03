using EmailSender.Services.Models;

namespace EmailSender.Services
{
    public interface IMailService
    {
        Task<Guid> SendMailAsync(MailDTO mailDTO);
        Task<ICollection<MailDTO>> GetAllMailsAsync();
    }
}
