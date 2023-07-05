using EmailSender.Domain;
using System.Linq.Expressions;

namespace EmailSender.Services.Repository
{
    /// <summary>
    /// Интерфейс репозитория для работы с базой данных сущности Получатель.
    /// </summary>
    public interface IRecipientRepository:IRepository<Recipient>
    {
        Task<MailRecipient> GetByFilter(Expression<Func<MailRecipient, bool>> predicate);
    }
}
