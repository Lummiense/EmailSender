using EmailSender.Domain;
using System.Linq.Expressions;

namespace EmailSender.Services.Repository
{
    public interface IRepository<T> where T : IEntity
    {
        Task AddRangeAsync(List<T> entities);
        Task<T> GetByFilter(Expression<Func<T, bool>> predicate);
        Task<IQueryable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
