using Quiz.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Domain.Interfaces
{
    public interface IQuestionRepository : IAsyncRepository<Question>
    {
        Task<Question> GetByIdAsync(int id, bool includeOptions = true);
        Task<IReadOnlyCollection<Question>> GetAllAsync(bool includeOptions = true);
    }
}
