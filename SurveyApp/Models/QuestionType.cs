namespace SurveyApp.Models
{
    public class QuestionType
    {
        public QuestionType(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; } = 0;
        public string Name { get; set; }

    }
}
