using EmailSender.Domain;
using EmailSender.Services.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

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
        public async Task AddRangeAsync(List<T> entities)
        {
            await _dbContext.AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();            
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            var result = await _dbContext.Set<T>().ToListAsync();
            return result.AsQueryable();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> predicate)
        {
            var result =await _dbContext.Set<T>().AsNoTracking().Where(predicate).FirstOrDefaultAsync();
            return result;
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
