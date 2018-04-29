using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using TodoManager.Core.Interfaces;
using TodoManager.Core.SharedKernel;

namespace TodoManager.Infrastructure.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : Entity
    {
        private readonly TodoContext _dbContext;

        public EfRepository()
        {
            _dbContext = new TodoContext();
        }

        public EfRepository(TodoContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
           await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
           await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}