using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EmailSender.Services.Repository
{
    /// <summary>
    /// Реализация generic-репозитория для работы с базой данных.
    /// </summary>
    /// <typeparam name="T">Любая сущность domain-слоя, унаследованная от базовой сущности.</typeparam>
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        protected DataContext _dbContext;
        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Метод добавления сущностей.
        /// </summary>
        /// <param name="entity">Сущность.</param>
        public async Task AddAsync(T entity)
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();            
        }

        /// <summary>
        /// Метод получения списка всех сущностей.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result.AsQueryable();
        }               

        /// <summary>
        /// Метод сохранения изменений в базе данных.
        /// </summary>
        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
