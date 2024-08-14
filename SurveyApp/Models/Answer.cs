using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{
    public class Answer
    {
        public int Id { get; set; } = 0;
        public int QuestionId { get; set; }
        public int? OptionId { get; set; }

        public int ResponseId { get; set; }

        [Range(0, 5, ErrorMessage = "Please enter value between 0 and 5")]
        public int? UsersIntInput { get; set; }
        public string? UsersTextInput { get; set; }

    }
}
