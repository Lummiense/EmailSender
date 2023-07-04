using EmailSender.Domain;

namespace EmailSender.Services.Repository
{
    public interface IMailRepository:IRepository<Mail>
    {
        Task <IQueryable<Mail>> GetMailsAsync();
    }
}
