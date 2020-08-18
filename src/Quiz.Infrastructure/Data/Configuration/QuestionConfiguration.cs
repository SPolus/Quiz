using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Infrastructure.Data.Configuration
{
    public class QuestionConfiguration : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(p => p.Content)
                .IsRequired();

            //builder.HasOne(q => q.Category)
            //    .WithMany(c => c.Questions)
            //    .IsRequired()
            //    .HasForeignKey(q => q.CategoryId)
            //    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
