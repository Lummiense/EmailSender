using EmailSender.Services.Models;

namespace EmailSender.Services
{
    /// <summary>
    /// Интерфейс сервиса формирования сообщений.
    /// </summary>
    public interface IMailService
    {
        Task<MailDTO> SendMailAsync(MailDTO mailDTO);        
        Task SaveMail(MailDTO mails);
        Task<ICollection<MailDTO>> GetAllMailsAsync();
    }
}
