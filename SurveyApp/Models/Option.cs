namespace SurveyApp.Models
{
    public class Option
    {
        public int Id { get; set; } = 0;
        public int QuestionId { get; set; }
        public string OptionText { get; set; }
        
        public List<Answer> Answers { get; set; }
    }
}
