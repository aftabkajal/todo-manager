using System.Collections.Generic;
using System.Threading.Tasks;
using TodoManager.Core.SharedKernel;

namespace TodoManager.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : Entity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);

    }
}