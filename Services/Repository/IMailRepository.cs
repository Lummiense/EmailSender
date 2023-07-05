using EmailSender.Domain;

namespace EmailSender.Services.Repository
{
    /// <summary>
    /// Интерфейс репозитория для работы с базой данных для сущности Письмо.
    /// </summary>
    public interface IMailRepository:IRepository<Mail>
    {
        Task <ICollection<Mail>> GetMailsAsync();
    }
}
