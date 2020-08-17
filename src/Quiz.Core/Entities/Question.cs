using System.Collections.Generic;

namespace Quiz.Core.Entities
{
    public class Question : EntityBase
    {
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<QuestionOption> QuestionOptions { get; set; }
    }
}
