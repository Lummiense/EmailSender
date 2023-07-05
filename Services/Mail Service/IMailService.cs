using EmailSender.Services.Models;

namespace EmailSender.Services
{
    /// <summary>
    /// Интерфейс сервиса формирования сообщений.
    /// </summary>
    public interface IMailService
    {
        Task<List<MailDTO>> SendMailAsync(MailDTO mailDTO);
        Task SaveMails(List<MailDTO> mails);

        Task<ICollection<MailDTO>> GetAllMailsAsync();
    }
}
