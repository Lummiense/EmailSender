using EmailSender.Domain;
using System.Linq.Expressions;

namespace EmailSender.Services.Repository
{
    /// <summary>
    /// Интерфейс generic-репозитория.
    /// </summary>
    /// <typeparam name="T">Любая сущность domain-слоя, унаследованная от базовой сущности.</typeparam>
    public interface IRepository<T> where T : IEntity
    {
        Task AddRangeAsync(List<T> entities);      
        Task<IQueryable<T>> GetAllAsync();
        Task SaveChangesAsync();
    }
}
