using Microsoft.AspNetCore.Components;
using System.ComponentModel.DataAnnotations;

namespace SurveyApp.Models
{
    public class User
    {
        public User() { }
        public User(string name, string email, string password)
        {
            this.Name = name;
            this.Email = email;
            this.PasswordHashed = password;
        }

        public int Id { get; set; } = 0;

        [Required(ErrorMessage = "Please enter a name.")]
        [MaxLength(100, ErrorMessage = "Name cannot be longer than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a email.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        public string PasswordHashed { get; set; }

        public virtual List<Survey> Surveys { get; set;}
        public virtual List<Response> Responses { get; set; }
    }
}
