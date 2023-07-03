using EmailSender.Domain;

namespace EmailSender.Services.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task<Guid> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
