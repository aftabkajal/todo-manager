

using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Core.Interfaces;
using TodoManager.Core.SharedKernel;

namespace TodoManager.Infrastructure.Data
{
    public class Repository<T> : IAsyncRepository<T> where T : Entity
    {
        public Task<T> AddAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteAsync(T entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<T>> ListAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}