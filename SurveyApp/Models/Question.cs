using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class Question
    {
        public int Id { get; set; } = 0;
        public int SurveyId { get; set; }
        public string QuestionText { get; set; }
        public int QuestionTypeId { get; set; }

        public QuestionType QuestionType { get; set; }
        public List<Option>? Options { get; set; }
    }
}