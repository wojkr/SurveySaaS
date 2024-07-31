# Website Navigation Design for Survey SaaS

## Unauthenticated Routes (Public Access)

- **Landing Page (`/`)**

  - Description: General information about the app, how to use it, and links to sign up or log in.

- **Surveys**

  - **Most Popular Surveys (`/surveys/popular`)**
    - Description: Publicly accessible list of the most popular surveys.

- **Auth**
  - **Register (`/register`)**
    - Description: User registration page.
  - **Login (`/login`)**
    - Description: User login page.

## Authenticated Routes (User Access)

- **Landing Page (`/dashboard`)**

  - Description: User dashboard with a summary of activity and shortcuts to main features.

- **Surveys**

  - **My Surveys (`/surveys/mine`)**
    - Description: List of surveys created by the logged-in user.
  - **All Surveys (`/surveys`)**
    - Description: List of all surveys accessible to the user.

- **Survey Management**

  - **Create Survey (`/surveys/create`)**
    - Description: Page to create a new survey.
  - **Edit Survey (`/surveys/edit/{id}`)**
    - Description: Edit an existing survey.
  - **Delete Survey (`/surveys/delete/{id}`)**
    - Description: Remove a survey (potentially move to Bin/Trash).
  - **Bin (`/surveys/bin`)**
    - Description: List of deleted surveys with the option to restore or permanently delete after 30 days.
  - **Survey Details (`/surveys/{id}`)**
    - Description: View detailed information about a specific survey, including responses and analytics.

- **Survey Completion**

  - **Complete Survey (`/surveys/complete/{id}`)**
    - Description: Page where users can complete a survey.
  - **Serial Complete Mode (`/surveys/serial/{id}`)**
    - Description: A mode for conducting surveys on a shared device, with quick transitions between participants.

- **Survey Analysis**
  - **Analytics & Diagrams (`/surveys/analytics/{id}`)**
    - Description: View graphical representations and analysis of survey data.

## Admin Routes (Admin Access)

- **User Management (`/admin/users`)**

  - Description: Manage user accounts, including viewing, editing, and deleting users.

- **Survey Moderation (`/admin/surveys`)**
  - Description: Oversee all surveys, including the ability to review, edit, and delete.

## Additional Considerations

1. **Error Pages (`/404`, `/500`, etc.)**

   - Custom error pages for various HTTP error codes.

2. **Account Management (`/account`)**

   - **Profile (`/account/profile`)**: View and edit user profile details.
   - **Change Password (`/account/password`)**: Change password functionality.

3. **API Routes (`/api/...`)**
   - If the app includes a RESTful API for external interactions.
