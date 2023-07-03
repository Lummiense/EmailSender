using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;

namespace EmailSender.Services.Repository
{
    public class Repository<T> : IRepository<T>
        where T : IEntity
    {
        protected DataContext _dbContext;
        public Repository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Guid> AddAsync(T entity)
        {
            var result = await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return result.Entity.Id;
        }

        public async Task<List<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
