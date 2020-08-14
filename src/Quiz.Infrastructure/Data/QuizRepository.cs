using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using Quiz.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Data
{
    public class QuizRepository : EfRepository<Question>, IQuizRepository
    {
        private readonly QuizDbContext _context;

        public QuizRepository(QuizDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int id, bool includeOptions)
        {
            if (includeOptions)
            {
                return await _context.Questions
                    .Include(qo => qo.QuestionOptions)
                    .ThenInclude(o => o.Option)
                    .FirstOrDefaultAsync(q => q.Id == id);
            }

            return await base.GetByIdAsync(id);
        }

        public async Task<IReadOnlyCollection<Question>> GetAllAsync(bool includeOptions)
        {
            if (includeOptions)
            {
                return await _context.Questions
                    .Include(qo => qo.QuestionOptions)
                    //.ThenInclude(o => o.Option)
                    .ToListAsync();
            }

            return await base.GetAllAsync();
        }
    }
}
