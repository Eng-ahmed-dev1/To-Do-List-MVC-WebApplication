# Task Management System

A comprehensive web-based task management application built with ASP.NET Core MVC, designed to help teams organize projects, assign tasks, and track progress efficiently.

![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-8.0-blue)
![C#](https://img.shields.io/badge/C%23-12.0-purple)
![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-green)
![License](https://img.shields.io/badge/License-MIT-yellow)

## 📋 Table of Contents

- [Overview](#overview)
- [Features](#features)
- [Technologies Used](#technologies-used)
- [System Architecture](#system-architecture)
- [Getting Started](#getting-started)
- [Project Structure](#project-structure)
- [Database Schema](#database-schema)
- [Usage Guide](#usage-guide)
- [Contributing](#contributing)
- [License](#license)

## 🎯 Overview

The Task Management System is a full-featured web application that enables teams to manage their projects and tasks effectively. It provides a clean, intuitive interface for creating projects, assigning tasks to team members, and tracking task status and priority levels.

## ✨ Features

### Project Management
- Create, read, update, and delete projects
- Track project start and end dates
- Detailed project descriptions
- View all projects in a centralized dashboard

### Task Management
- Comprehensive task CRUD operations
- Task status tracking (Pending, In Progress, Completed)
- Priority levels (Low, Medium, High)
- Deadline management
- Task assignment to team members
- Link tasks to specific projects

### Team Member Management
- Manage team member profiles
- Role-based access (Admin, User)
- Email and contact information tracking
- View all assigned tasks per member

### User Experience
- Responsive Bootstrap-based UI
- Real-time validation feedback
- Success and error notifications using TempData
- Clean and intuitive navigation

## 🛠 Technologies Used

### Backend
- **Framework**: ASP.NET Core MVC 8.0
- **Language**: C# 12.0
- **ORM**: Entity Framework Core
- **Database**: SQL Server (configurable)

### Frontend
- **UI Framework**: Bootstrap 5
- **Template Engine**: Razor Pages
- **Validation**: jQuery Validation
- **Icons**: Bootstrap Icons

### Architecture Patterns
- **MVC Pattern**: Model-View-Controller separation
- **Repository Pattern**: Data access abstraction
- **ViewModel Pattern**: Separate DTOs for different operations
- **Dependency Injection**: Built-in ASP.NET Core DI

## 🏗 System Architecture

The application follows a clean, layered architecture:

```
┌─────────────────────────────────────┐
│         Presentation Layer          │
│    (Views, Controllers, ViewModels) │
└─────────────────────────────────────┘
                  │
┌─────────────────────────────────────┐
│         Business Logic Layer        │
│       (Controllers, Services)       │
└─────────────────────────────────────┘
                  │
┌─────────────────────────────────────┐
│          Data Access Layer          │
│     (Entity Framework, DbContext)   │
└─────────────────────────────────────┘
                  │
┌─────────────────────────────────────┐
│            Database Layer           │
│           (SQL Server)              │
└─────────────────────────────────────┘
```

## 🚀 Getting Started

### Prerequisites

- .NET 8.0 SDK or later
- SQL Server 2019 or later (or SQL Server Express)
- Visual Studio 2022 or JetBrains Rider (recommended)
- Git

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/Eng-ahmed-dev1/task-management-system.git
   cd task-management-system
   ```

2. **Configure the database connection**
   
   Update the connection string in `appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=TaskManagementDB;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True"
     }
   }
   ```

3. **Apply database migrations**
   ```bash
   dotnet ef database update
   ```

4. **Build the project**
   ```bash
   dotnet build
   ```

5. **Run the application**
   ```bash
   dotnet run
   ```

6. **Access the application**
   
   Open your browser and navigate to:
   - HTTPS: `https://localhost:7001`
   - HTTP: `http://localhost:5000`

## 📁 Project Structure

```
Managment_SYS/
├── Controllers/
│   ├── ProjectController.cs
│   ├── TaskController.cs
│   └── TeamMemberController.cs
├── Models/
│   ├── Project.cs
│   ├── Task.cs
│   └── TeamMember.cs
├── ViewModels/
│   ├── Project/
│   │   ├── ProjectCreateVM.cs
│   │   ├── ProjectReadVM.cs
│   │   ├── ProjectEditVM.cs
│   │   └── ProjectDeleteVM.cs
│   ├── Task/
│   │   ├── TaskCreateVM.cs
│   │   ├── TaskReadVM.cs
│   │   ├── TaskEditVM.cs
│   │   └── TaskDeleteVM.cs
│   └── TeamMember/
│       ├── TeamMemberCreateVM.cs
│       ├── TeamMemberReadVM.cs
│       ├── TeamMemberEditVM.cs
│       └── TeamMemberDeleteVM.cs
├── Views/
│   ├── Project/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   ├── Task/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   └── Delete.cshtml
│   └── TeamMember/
│       ├── Index.cshtml
│       ├── Create.cshtml
│       ├── Edit.cshtml
│       └── Delete.cshtml
├── Data/
│   └── TaskManagementSystemDB.cs
└── wwwroot/
    ├── css/
    ├── js/
    └── lib/
```

## 🗄 Database Schema

### Tables

#### Projects
- `Id` (int, PK)
- `Name` (nvarchar)
- `Description` (nvarchar)
- `StartDate` (datetime)
- `EndDate` (datetime)

#### Tasks
- `Id` (int, PK)
- `Title` (nvarchar)
- `Description` (nvarchar)
- `Deadline` (datetime)
- `Status` (enum: Pending, InProgress, Completed)
- `Priority` (enum: Low, Medium, High)
- `ProjectId` (int, FK)
- `TeamMemberId` (int, FK)

#### TeamMembers
- `Id` (int, PK)
- `Name` (nvarchar)
- `Email` (nvarchar)
- `Role` (enum: Admin, User)

### Relationships

```
Project (1) ──────< (Many) Task
TeamMember (1) ───< (Many) Task
```

## 📖 Usage Guide

### Managing Projects

1. **Create a Project**
   - Navigate to Projects → Create New
   - Fill in project name, description, start date, and end date
   - Click "Create"

2. **View Projects**
   - Go to Projects → Index
   - View all projects in a table format

3. **Edit a Project**
   - Click "Edit" next to any project
   - Update the details
   - Click "Save"

4. **Delete a Project**
   - Click "Delete" next to any project
   - Confirm deletion

### Managing Tasks

1. **Create a Task**
   - Navigate to Tasks → Create New
   - Enter task title, description, and deadline
   - Select status and priority
   - Assign to a project and team member
   - Click "Create"

2. **Track Task Status**
   - View all tasks with their current status
   - Update status as work progresses

### Managing Team Members

1. **Add Team Members**
   - Go to Team Members → Create New
   - Enter name, email, and role
   - Click "Create"

2. **Assign Roles**
   - Admin: Full access to all features
   - User: Standard access

## 🤝 Contributing

We welcome contributions to improve the Task Management System!

### How to Contribute

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

### Coding Standards

- Follow C# coding conventions
- Use meaningful variable and method names
- Add XML documentation for public methods
- Write unit tests for new features
- Ensure all tests pass before submitting PR

## 🐛 Known Issues

- Project Edit view is missing the Id field in the ViewModel (requires hidden field in view)
- Task Create view has a typo in TempData display ("Crreated" instead of "Created")
- TeamMember Index view is missing the Id column display

## 🔮 Future Enhancements

- [ ] User authentication and authorization
- [ ] Task comments and attachments
- [ ] Email notifications for task assignments
- [ ] Dashboard with charts and statistics
- [ ] Task filtering and search functionality
- [ ] Export reports to PDF/Excel
- [ ] Mobile responsive design improvements
- [ ] Real-time updates using SignalR
- [ ] Task dependencies and subtasks
- [ ] Time tracking for tasks

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 👥 Authors

- **Ahmed Alaa** - *Initial work* - [@Eng-ahmed-dev1](https://github.com/Eng-ahmed-dev1)

## 📱 Connect With Me

- **GitHub**: [@Eng-ahmed-dev1](https://github.com/Eng-ahmed-dev1)
- **LinkedIn**: [Ahmed Alaa](https://www.linkedin.com/in/ahmed-alaa-b256a2389/)
- **Telegram**: [@devAhmedl](https://t.me/devAhmedl)
- **Email**: ahmed.devmail1@gmail.com

## 🙏 Acknowledgments

- ASP.NET Core Team for the excellent framework
- Bootstrap Team for the UI components
- Entity Framework Team for the ORM
- Stack Overflow community for endless support

## 📞 Support

For support, you can reach out through:
- **Email**: ahmed.devmail1@gmail.com
- **Telegram**: [@devAhmedl](https://t.me/devAhmedl)
- **LinkedIn**: [Ahmed Alaa](https://www.linkedin.com/in/ahmed-alaa-b256a2389/)
- **GitHub Issues**: Create an issue in the repository

---

**Made with ❤️ by Ahmed Alaa using ASP.NET Core MVC**
