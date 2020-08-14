using Quiz.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Core.Interfaces
{
    public interface IQuizRepository : IAsyncRepository<Question>
    {
        Task<Question> GetByIdAsync(int id, bool includeOptions = true);
        Task<IReadOnlyCollection<Question>> GetAllAsync(bool includeOptions = true);
    }
}
