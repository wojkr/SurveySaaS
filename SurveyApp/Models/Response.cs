namespace SurveyApp.Models
{
    public class Response
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public User User { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
