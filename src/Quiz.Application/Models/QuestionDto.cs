using System;
using System.Collections.Generic;
using System.Text;

namespace Quiz.Application.Models
{
    public class QuestionDto
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public ICollection<string> Options { get; set; }
    }
}
