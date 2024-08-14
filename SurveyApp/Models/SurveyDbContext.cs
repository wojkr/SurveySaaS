using Microsoft.EntityFrameworkCore;

namespace SurveyApp.Models
{
    public class SurveyDbContext:DbContext
    {
        public SurveyDbContext(DbContextOptions<SurveyDbContext> options):base(options) { }
        
        public DbSet<Answer> Answers { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Option> Options { get; set; } 
        public DbSet<Question> Questions { get; set; }
        public DbSet<Response> Responses { get; set; }
        public DbSet<Survey> Surveys { get; set; }
        public DbSet<SurveyVisibilityType> SurveyVisibilityTypes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
