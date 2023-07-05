using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Services.Repository
{
    /// <summary>
    /// Реализация репозитория для работы с базой данных сущности Письмо.
    /// </summary>
    public class MailRepository :Repository<Mail>,IMailRepository
    {
        public MailRepository(DataContext dbContext) : base(dbContext)
        {
        }     

        /// <summary>
        /// Метод получения из базы данных списка сформированных писем, включая получателей.
        /// </summary>
        /// <returns>Список сформированных писем.</returns>
        public async Task<ICollection<Mail>> GetMailsAsync()
        {
            var result = await _dbContext.Set<Mail>().Include(r => r.MailRecipients).AsNoTracking().Include("MailRecipients.Recipient").ToListAsync();
            return result;
        }

        
    }
}
