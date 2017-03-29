using System.Collections.Generic;

namespace Models
{
    public class LoadQuestionDto
    {
        public int    QuestionNumber { get; set; }
        public string Text { get; set; }
        public IEnumerable<LoadAnswerDto> Answers { get; set; }
        public string AnswerText { get; set; }
    }
}
