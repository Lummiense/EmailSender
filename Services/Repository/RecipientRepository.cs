using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmailSender.Services.Repository
{

    /// <summary>
    /// Реализация репозитория для работы с базой данных сущности Получатель.
    /// </summary>
    public class RecipientRepository : Repository<Recipient>, IRecipientRepository
    {
        public RecipientRepository(DataContext dbContext) : base(dbContext)
        {

        }

        /// <summary>
        /// Метод получения из базы данных сущности Получатель с применением поискового фильтра.
        /// </summary>
        /// <param name="predicate">Поисковый фильтр</param>
        /// <returns>Сущность Получатель.</returns>
        public async Task<MailRecipient> GetByFilter(Expression<Func<MailRecipient, bool>> predicate)
        {
            var result = await _dbContext.Set<MailRecipient>().AsNoTracking().Include(x=>x.Recipient).AsNoTracking().Where(predicate).FirstOrDefaultAsync();
            return result;
        }

       
    }
}
