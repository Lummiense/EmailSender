using EmailSender.Services.Models;

namespace EmailSender.Services
{
    public interface IMailService
    {
        Task<List<MailDTO>> SendMailAsync(MailDTO mailDTO);
        Task SaveMails(List<MailDTO> mails);

        Task<IQueryable<MailDTO>> GetAllMailsAsync();
    }
}
