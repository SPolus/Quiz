using System.Collections.Generic;

namespace Quiz.Domain.Entities
{
    public class Option : EntityBase
    {
        public string Content { get; set; }
        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
