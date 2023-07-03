using EmailSender.Domain;

namespace EmailSender.Services.Repository
{
    public interface IMailRepository:IRepository<Mail>
    {
        Task <List<Mail>> GetMailsAsync();
    }
}
