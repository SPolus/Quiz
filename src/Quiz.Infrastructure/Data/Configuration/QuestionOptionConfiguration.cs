using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Quiz.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Infrastructure.Data.Configuration
{
    public class QuestionOptionConfiguration : IEntityTypeConfiguration<QuestionOption>
    {
        public void Configure(EntityTypeBuilder<QuestionOption> builder)
        {
            builder.HasKey(qo => new { qo.QuestionId, qo.OptionId });

            //builder.HasOne(q => q.Question)
            //    .WithMany(qo => qo.QuestionOptions)
            //    .HasForeignKey(fk => fk.QuestionId)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(o => o.Option)
            //    .WithMany(qo => qo.QuestionOptions)
            //    .HasForeignKey(fk => fk.OptionId)
            //    .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.IsCorrect)
                .IsRequired();
        }
    }
}
