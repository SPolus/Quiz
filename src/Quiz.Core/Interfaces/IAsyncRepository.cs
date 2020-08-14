using Quiz.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Core.Interfaces
{
    public interface IAsyncRepository<T> where T : EntityBase
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
