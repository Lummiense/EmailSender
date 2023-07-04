using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Services.Repository
{
    public class MailRepository :Repository<Mail>,IMailRepository
    {
        public MailRepository(DataContext dbContext) : base(dbContext)
        {
        } 
     

        public async Task<IQueryable<Mail>> GetMailsAsync()
        {
            var result = await _dbContext.Set<Mail>().Include(r => r.MailRecipients).AsNoTracking().ToListAsync();
            return result.AsQueryable();
        }

        
    }
}
