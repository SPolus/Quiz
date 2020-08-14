namespace Quiz.Core.Entities
{
    public class QuestionOption
    {
        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int OptionId { get; set; }
        public Option Option { get; set; }

        public bool Correct { get; set; }
    }
}
