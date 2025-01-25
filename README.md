Task Management System

This is a Task Management System designed to help organizations manage tasks efficiently. The system supports user registration, role-based access, task assignment, and status updates. It also includes a dashboard for task statistics and notifications for task updates using Hangfire.
Features
Core Features

    User Management:
        Register and log in with JWT authentication.
        Role-based access control (Admin, Manager, Employee).

    Task Management:
        Create, assign, and manage tasks.
        Update task status (Pending, In Progress, Completed).
        Prioritize tasks (Low, Medium, High).

    Dashboard:
        View task statistics (e.g., pending, completed, overdue tasks).

    Notifications:
        Email notifications for task assignment, updates, and deletions.

Technical Highlights

    Backend: ASP.NET Core 6 Web API with Clean Architecture.
    Database: SQL Server using Entity Framework Core.
    Notifications: Hangfire for background tasks.
    Frontend: HTML, CSS, Bootstrap, and JavaScript/jQuery.
    Cloud Deployment: Hosted on Microsoft Azure App Service.
    Version Control: Managed with GitHub.

Getting Started
Prerequisites

    .NET 6 SDK.
    SQL Server.
    Microsoft Azure account (optional for cloud deployment).
    Git installed on your system.

Installation

    Clone the Repository:

git clone https://github.com/your-username/task-management-system.git
cd task-management-system

Set Up the Database:

    Update the appsettings.json file with your SQL Server connection string.

"ConnectionStrings": {
    "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagementDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;"
}

    Apply migrations:

    dotnet ef database update

Run the Application:

    dotnet run

    Access the Application:
        Backend API: http://localhost:5000/api
        Frontend: Open index.html in the wwwroot folder.

Deployment
Azure Deployment

    Create an Azure App Service instance.

    Publish the application to Azure:

    dotnet publish -c Release

    Use the Azure Deployment Center in the Azure portal or deploy via Visual Studio.

    Configure Azure App Service settings:
        Add your database connection string under "Configuration" in the Azure App Service settings.

Usage

    Admin:
        Create and manage users.
        Assign tasks to managers or employees.

    Manager:
        Assign tasks to employees.
        Monitor task progress.

    Employee:
        Update task status.
        View assigned tasks.

Technologies Used

    Backend: ASP.NET Core 6, Entity Framework Core.
    Frontend: HTML, CSS, Bootstrap, JavaScript/jQuery.
    Database: SQL Server.
    Notifications: Hangfire for email notifications.
    Cloud: Microsoft Azure App Service.
    Version Control: GitHub.

Project Structure

TaskManagementSystem/
│
├── Controllers/          # API Controllers
├── Data/                 # Entity Framework DbContext and Migrations
├── Models/               # Entity Models
├── Services/             # Notification Service, Business Logic
├── wwwroot/              # Static Frontend (HTML, CSS, JS)
├── appsettings.json      # Configuration
└── Program.cs            # Application Entry Point

Future Enhancements

    Pagination and search for tasks.
    Angular or React frontend integration.
    Implement Test-Driven Development (TDD).
    Add Docker support for containerization.

Contributing

    Fork the repository.
    Create a feature branch:

git checkout -b feature-name

Commit your changes:

git commit -m "Add feature description"

Push to the branch:

    git push origin feature-name

    Create a pull request.

License

This project is licensed under the MIT License. See the LICENSE file for details.
Contact

If you have any questions or suggestions, feel free to contact me:

    Name: Maha Almogeira
    Email: maha.mmr5@gmail.com
    Location: Makkah, Saudi Arabia

Happy Coding! 🎉
