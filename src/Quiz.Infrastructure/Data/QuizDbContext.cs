using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Quiz.Infrastructure.Data
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<QuestionOption> QuestionOptions { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<QuestionOption>().HasKey(qo => new { qo.QuestionId, qo.OptionId });
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
