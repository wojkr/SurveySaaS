using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SurveyApp.Models
{
    public class Survey
    {
        public Survey(){}
        public Survey(int userId, int surveyVisibilityTypeId, string title, string description, DateTime? startAt=null, DateTime? closesAt=null)
        {
            UserId = userId;
            SurveyVisibilityTypeId = surveyVisibilityTypeId;
            Title = title;
            Description = description;
            if (startAt != null)
            {
                StartsAt = startAt;
            }
            if (closesAt != null)
            {
                ClosesAt = closesAt;
            }
        }

        public int Id { get; set; } = 0;
        public int UserId { get; set; }

        [Required(ErrorMessage = "Please choose a survey type.")]
        public int SurveyVisibilityTypeId { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [MaxLength(200, ErrorMessage = "Title cannot be longer than 200 characters.")]
        public string Title { get; set; } = string.Empty;

        [MaxLength(1000, ErrorMessage = "Description cannot be longer than 1000 characters.")]
        public string? Description { get; set; }

        public bool IsScheduled => StartsAt.HasValue && ClosesAt.HasValue;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime LastUpdatedAt { get; set; } = DateTime.Now;
        public DateTime? StartsAt { get; set; }
        public DateTime? ClosesAt { get; set; }

        public List<Question> Questions { get; set; }
        public SurveyVisibilityType SurveyVisibilityType { get; set; }
    }
}
