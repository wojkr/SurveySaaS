using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{
    public class SurveyVisibilityType
    {
        public SurveyVisibilityType(string name,bool isPublic,bool isAccessWithLink)
        {
            this.Name = name;
            this.IsPublic = isPublic;
            this.IsAccessWithLink = isAccessWithLink;
        }
        public int Id { get; set; } = 0;

        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public bool IsPublic { get; set; } = false;
        public bool IsAccessWithLink { get; set; } = false;

    }
}
