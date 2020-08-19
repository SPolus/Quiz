﻿using Microsoft.EntityFrameworkCore;
using Quiz.Domain.Entities;
using Quiz.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Quiz.Infrastructure.Data
{
    public class QuestionRepository : EfRepository<Question>, IQuestionRepository
    {
        private readonly QuizDbContext _context;

        public QuestionRepository(QuizDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Question> GetByIdAsync(int id, bool includeOptions)
        {
            if (includeOptions)
            {
                return await _context.Questions
                    .Include(c => c.Category)
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
                    .Include(c => c.Category)
                    .Include(qo => qo.QuestionOptions)
                    //.ThenInclude(o => o.Option)
                    .ToListAsync();
            }

            return await base.GetAllAsync();
        }
    }
}
