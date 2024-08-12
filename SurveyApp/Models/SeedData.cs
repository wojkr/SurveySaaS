using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace SurveyApp.Models;

public static class SeedData
{
    private static SurveyDbContext context = null!;

    /// <summary>
    /// Entry point for seeding Db.
    /// </summary>
    /// <param name="app">Needed to create context scope.</param>
    /// <exception cref="ApplicationException">If could not get scope then stops whole program.</exception>
    public static void Invoke(IApplicationBuilder app)
    {
        context = app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<SurveyDbContext>();
        if (context == null) throw new ApplicationException("Could not get context");
        EnsurePopulated();
    }

    /// <summary>
    /// Main Function.
    /// </summary>
    public static void EnsurePopulated()
    {

        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }

        SeedUsers();
        SeedSurveyVisibilityTypes();
        SeedQuestionTypes();

        SeedSurvey();
        SeedQuestions();
        SeedOptions();
        SeedResponses();
        SeedAnswers();
    }

    /// <summary>
    /// Fields declaration.
    /// </summary>
    private static List<Survey> surveys;
    private static List<Response> responses;
    private static List<Question> questions;
    private static List<Option> options;
    private static List<Answer> answers;
    private static List<User> users = new()
    {
        new User("Adam", "adam@someMail.com", "somePass"),
        new User("Dennis", "dennis@otherMail.com", "passwordHardToBreak"),
        new User("Eve", "eve@otherMail.com", "ThatIsACleverPassword"),
        new User("John", "john@someMail.com", "easyPass"),
        new User("Jane", "jane@otherMail.com", "JaneRocks123"),
        new User("Mike", "mike@someMail.com", "MikeStrongPass")
    };
    private static List<SurveyVisibilityType> surveyVisibilityTypes = new()
    {
        new SurveyVisibilityType("Open", true, true),
        new SurveyVisibilityType("Private", false, false),
        new SurveyVisibilityType("AccessWithLink", false, true)
    };
    private static List<QuestionType> questionTypes = new()
    {
        new QuestionType("Closed"),
        new QuestionType("Numeric"),
        new QuestionType("Open")
    };

    /// <summary>
    /// Seed methods declaration. 
    /// </summary>
    private static void SeedAnswers()
    {
        if (!context.Answers.Any())
        {
            context.AddRange(GetAnswers());
            context.SaveChanges();
        }
        answers = context.Answers.ToList();
    }

    private static void SeedResponses()
    {
        if (!context.Responses.Any())
        {
            context.AddRange(GetResponses());
            context.SaveChanges();
        }
        responses = context.Responses.ToList();
    }

    private static void SeedOptions()
    {
        if (!context.Options.Any())
        {
            context.AddRange(GetOptions());
            context.SaveChanges();
        }
        options = context.Options.ToList();
    }

    private static void SeedQuestions()
    {
        if (!context.Questions.Any())
        {
            context.AddRange(GetQuestions());
            context.SaveChanges();
        }
        questions = context.Questions.ToList();
    }

    private static void SeedSurvey()
    {
        if (!context.Surveys.Any())
        {
            context.AddRange(GetSurveys());
            context.SaveChanges();
        }
        surveys = context.Surveys.ToList();
    }

    private static void SeedQuestionTypes()
    {
        if (!context.QuestionTypes.Any())
        {
            context.QuestionTypes.AddRange(questionTypes);
            context.SaveChanges();
        }
        questionTypes = context.QuestionTypes.ToList();
    }

    private static void SeedSurveyVisibilityTypes()
    {
        if (!context.SurveyVisibilityTypes.Any())
        {
            context.AddRange(surveyVisibilityTypes);
            context.SaveChanges();
        }
        surveyVisibilityTypes = context.SurveyVisibilityTypes.ToList();
    }

    private static void SeedUsers()
    {
        if (!context.Users.Any())
        {
            context.AddRange(users);
            context.SaveChanges();
        }
        users = context.Users.ToList();
    }

    /// <summary>
    /// Get method declaration. Has to be created for getting Ids from context. Fields declared to store raw data.
    /// </summary>
    /// <returns></returns>
    private static List<Survey> GetSurveys() => new()
    {
        new Survey(userId: users[0].Id,
                   surveyVisibilityTypeId: surveyVisibilityTypes[0].Id,
                   title: "Customer Satisfaction Survey",
                   description: "A survey to gauge customer satisfaction with our services.",
                   startAt: DateTime.Now,
                   closesAt: DateTime.Now.AddMonths(1)),
        new Survey(userId: users[1].Id, surveyVisibilityTypeId: surveyVisibilityTypes[0].Id, title: "Employee Engagement Survey",
                   description: "Survey to understand employee engagement and morale.",
                   startAt: DateTime.Now, closesAt: DateTime.Now.AddMonths(2)),
        new Survey(userId: users[2].Id, surveyVisibilityTypeId: surveyVisibilityTypes[2].Id, title: "Market Research Survey",
                   description: "A survey to research market trends and consumer behavior.",
                   startAt: DateTime.Now.AddDays(7), closesAt: DateTime.Now.AddMonths(3)),
        new Survey(userId: users[1].Id, surveyVisibilityTypeId: surveyVisibilityTypes[0].Id, title: "Product Feedback Survey",
                   description: "We want to hear your thoughts on our new product line."),
        new Survey(userId: users[2].Id, surveyVisibilityTypeId: surveyVisibilityTypes[1].Id, title: "Website Usability Survey",
                   description: "Help us improve our website by providing your feedback.",
                   startAt: DateTime.Now, closesAt: DateTime.Now.AddMonths(1))
    };

    private static List<Question> GetQuestions() => new()
    {
        new Question { SurveyId = surveys[0].Id, QuestionText = "How satisfied are you with our service?", QuestionTypeId = questionTypes[1].Id },
        new Question { SurveyId = surveys[0].Id, QuestionText = "Would you recommend us to others?", QuestionTypeId = questionTypes[0].Id },

        new Question { SurveyId = surveys[1].Id, QuestionText = "How engaged do you feel at work?", QuestionTypeId = questionTypes[1].Id },
        new Question { SurveyId = surveys[1].Id, QuestionText = "Do you feel supported by your manager?", QuestionTypeId = questionTypes[2].Id },

        new Question { SurveyId = surveys[2].Id, QuestionText = "Which products do you use most frequently?", QuestionTypeId = questionTypes[0].Id },
        new Question { SurveyId = surveys[2].Id, QuestionText = "What are your biggest challenges when using our products?", QuestionTypeId = questionTypes[2].Id },

        new Question { SurveyId = surveys[3].Id, QuestionText = "What do you like most about our new product?", QuestionTypeId = questionTypes[2].Id },
        new Question { SurveyId = surveys[3].Id, QuestionText = "What would you improve in our new product?", QuestionTypeId = questionTypes[2].Id },

        new Question { SurveyId = surveys[4].Id, QuestionText = "How easy is it to navigate our website?", QuestionTypeId = questionTypes[0].Id },
        new Question { SurveyId = surveys[4].Id, QuestionText = "What features would you like to see on our website?", QuestionTypeId = questionTypes[0].Id }
    };

    private static List<Option> GetOptions() => new()
    {
        new Option { QuestionId = questions[0].Id, OptionText = "Very Satisfied" },
        new Option { QuestionId = questions[0].Id, OptionText = "Satisfied" },
        new Option { QuestionId = questions[0].Id, OptionText = "Neutral" },
        new Option { QuestionId = questions[0].Id, OptionText = "Dissatisfied" },
        new Option { QuestionId = questions[0].Id, OptionText = "Very Dissatisfied" },

        // Options for "How engaged do you feel at work?" (SurveyId = 2, QuestionId = 3)
        new Option { QuestionId = questions[2].Id, OptionText = "Very Engaged" },
        new Option { QuestionId = questions[2].Id, OptionText = "Engaged" },
        new Option { QuestionId = questions[2].Id, OptionText = "Neutral" },
        new Option { QuestionId = questions[2].Id, OptionText = "Disengaged" },
        new Option { QuestionId = questions[2].Id, OptionText = "Very Disengaged" },

        // Options for "How easy is it to navigate our website?" (SurveyId = 5, QuestionId = 9)
        new Option { QuestionId = questions[8].Id, OptionText = "Very Easy" },
        new Option { QuestionId = questions[8].Id, OptionText = "Easy" },
        new Option { QuestionId = questions[8].Id, OptionText = "Neutral" },
        new Option { QuestionId = questions[8].Id, OptionText = "Difficult" },
        new Option { QuestionId = questions[8].Id, OptionText = "Very Difficult" }
    };

    private static List<Response> GetResponses() => new()
    {
        new Response {  UserId = users[0].Id, CreatedAt = DateTime.Now.AddDays(-10) },
        new Response {  UserId = users[1].Id, CreatedAt = DateTime.Now.AddDays(-9) },
        new Response {  UserId = users[2].Id, CreatedAt = DateTime.Now.AddDays(-8) },
        new Response {  UserId = users[3].Id, CreatedAt = DateTime.Now.AddDays(-7) },
        new Response {  UserId = users[4].Id, CreatedAt = DateTime.Now.AddDays(-6) },
        new Response {  UserId = users[5].Id, CreatedAt = DateTime.Now.AddDays(-5) },
        new Response {  UserId = users[0].Id, CreatedAt = DateTime.Now.AddDays(-4) },
        new Response {  UserId = users[1].Id, CreatedAt = DateTime.Now.AddDays(-3) },
        new Response {  UserId = users[2].Id, CreatedAt = DateTime.Now.AddDays(-2) },
        new Response {  UserId = users[3].Id, CreatedAt = DateTime.Now.AddDays(-1) },
        new Response {  UserId = users[4].Id, CreatedAt = DateTime.Now },
        new Response {  UserId = users[5].Id, CreatedAt = DateTime.Now.AddHours(-5) }
    };

    private static List<Answer> GetAnswers() => new()
    {
        // For QuestionId = 1, Numeric input (0-5)
        new Answer { ResponseId = responses[0].Id,QuestionId = questions[0].Id, UsersIntInput = 4 },
    
        // For QuestionId = 2, Closed input (uses options only)
        new Answer {ResponseId = responses[0].Id, QuestionId = questions[1].Id, OptionId = options[0].Id },
    
        // For QuestionId = 3, Numeric input (0-5)
        new Answer { ResponseId = responses[1].Id,QuestionId = questions[2].Id, UsersIntInput = 3 },
    
        // For QuestionId = 4, Open input (user text input)
        new Answer { ResponseId = responses[1].Id,QuestionId = questions[3].Id, UsersTextInput = "Yes, I feel supported." },
    
        // For QuestionId = 5, Closed input (uses options only)
        new Answer { ResponseId = responses[2].Id,QuestionId = questions[4].Id, OptionId = options[1].Id },
    
        // For QuestionId = 6, Open input (user text input)
        new Answer { ResponseId = responses[2].Id,QuestionId = questions[5].Id, UsersTextInput = "Navigating through the app is a bit challenging." },
    
        // For QuestionId = 7, Open input (user text input)
        new Answer { ResponseId = responses[3].Id,QuestionId = questions[6].Id, UsersTextInput = "The design and ease of use." },
    
        // For QuestionId = 8, Open input (user text input)
        new Answer { ResponseId = responses[3].Id,QuestionId = questions[7].Id, UsersTextInput = "Better integration with other services." },
    
        // For QuestionId = 9, Closed input (uses options only)
        new Answer { ResponseId = responses[4].Id,QuestionId = questions[8].Id, OptionId = options[2].Id },
    
        // For QuestionId = 10, Closed input (uses options only)
        new Answer { ResponseId = responses[4].Id,QuestionId = questions[9].Id, OptionId = options[3].Id },
    
        // Additional answers for variety
        new Answer { ResponseId = responses[5].Id,QuestionId = questions[0].Id, UsersIntInput = 5 },
        new Answer { ResponseId = responses[5].Id,QuestionId = questions[1].Id, OptionId = options[1].Id }
    };
}