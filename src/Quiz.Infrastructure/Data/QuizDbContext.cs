using Microsoft.EntityFrameworkCore;
using Quiz.Core.Entities;
using System;
using System.Collections.Generic;
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
            modelBuilder.Entity<Question>(entity =>
            {
                entity.HasKey(k => k.Id);
                entity.Property(p => p.Content).IsRequired();
            });


            modelBuilder.Entity<QuestionOption>(entity =>
            {
                entity.HasKey(qo => new { qo.QuestionId, qo.OptionId });
                
                entity.HasOne(q => q.Question)
                    .WithMany(qo => qo.QuestionOptions)
                    .HasForeignKey(k => k.QuestionId); // ondelete

                entity.HasOne(o => o.Option)
                    .WithMany(qo => qo.QuestionOptions)
                    .HasForeignKey(fk => fk.OptionId); // ondelete
            });
        }
    }
}
