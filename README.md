# Course Management API

A backend Web API project for managing courses, categories, and lessons, built with **ASP.NET Core**, **Entity Framework Core**, and **SQL Server**.

The project was developed as a practical exercise to work with:

* ASP.NET Core Web API
* RESTful APIs
* Entity Framework Core
* SQL Server
* Dependency Injection
* Reflection
* DTOs
* Repository Pattern
* Service Layer
* Layered Architecture
* Automatic Dependency Registration

---

## Features

The API provides functionality for managing:

### Courses

* Create a course
* Get all courses
* Get a course by ID
* Update a course
* Delete a course

### Categories

* Create a category
* Get all categories
* Get a category by ID
* Update a category
* Delete a category

### Lessons

* Create a lesson
* Get all lessons
* Get a lesson by ID
* Get lessons by course ID
* Update a lesson
* Delete a lesson

---

## Technologies

* **C#**
* **ASP.NET Core Web API**
* **.NET 10**
* **Entity Framework Core**
* **SQL Server**
* **Swagger / OpenAPI**
* **Reflection**
* **Dependency Injection**

---

# Project Architecture

The project is divided into separate layers:

```text
CourseManagementAPI
│
├── CourseManagement.API
│
├── CourseManagement.Core
│
└── CourseManagement.Service
```

## CourseManagement.API

This is the presentation/API layer.

Responsibilities:

* Controllers
* DTOs
* API endpoints
* Swagger configuration
* Dependency Injection configuration
* HTTP request/response handling

Structure:

```text
CourseManagement.API
│
├── Controllers
│   ├── CoursesController.cs
│   ├── CategoriesController.cs
│   └── LessonsController.cs
│
├── DTOs
│   ├── CourseResponseDto.cs
│   ├── CategoryResponseDto.cs
│   ├── CreateCourseDto.cs
│   ├── UpdateCourseDto.cs
│   └── LessonDTO
│
├── Extensions
│   └── ServiceCollectionExtensions.cs
│
└── Program.cs
```

---

# CourseManagement.Core

The Core layer contains abstractions used by the dependency injection system.

It contains marker interfaces for different Dependency Injection lifetimes:

```text
CourseManagement.Core
│
└── Interfaces
    ├── IScopedDependency.cs
    ├── ITransientDependency.cs
    └── ISingletonDependency.cs
```

These interfaces do not contain methods.

They are used to tell the Reflection-based registration system which lifetime should be used for a class.

For example:

```csharp
public class CourseService : ICourseService, IScopedDependency
{
}
```

The `IScopedDependency` interface tells the application that `CourseService` should be registered as a Scoped service.

---

# CourseManagement.Service

This layer contains the application's business logic, entities, repositories, services, and database context.

Structure:

```text
CourseManagement.Service
│
├── Entities
│   ├── Course.cs
│   ├── Category.cs
│   ├── Lesson.cs
│   └── BaseEntity.cs
│
├── Interfaces
│   ├── ICourseService.cs
│   ├── ICategoryService.cs
│   ├── ILessonService.cs
│   ├── ICourseRepository.cs
│   ├── ICategoryRepository.cs
│   └── ILessonRepository.cs
│
├── Services
│   ├── CourseService.cs
│   ├── CategoryService.cs
│   └── LessonService.cs
│
├── Repositories
│   ├── SqlCourseRepository.cs
│   ├── SqlCategoryRepository.cs
│   ├── SqlLessonRepository.cs
│   └── InMemoryCourseRepository.cs
│
└── Data
    └── CourseDbContext.cs
```

---

# Entity Relationships

The main entities are:

```text
Category
   │
   │ 1
   │
   │ *
   ▼
Course
   │
   │ 1
   │
   │ *
   ▼
Lesson
```

### Category → Course

A category can contain multiple courses.

```text
Category
    └── Courses
```

### Course → Lesson

A course can contain multiple lessons.

```text
Course
    └── Lessons
```

---

# Repository Pattern

The project uses the Repository Pattern to separate data access from business logic.

For example:

```text
ICourseRepository
        │
        ▼
SqlCourseRepository
```

The service layer depends on the repository abstraction rather than directly handling database operations.

Example:

```text
CoursesController
        ↓
ICourseService
        ↓
CourseService
        ↓
ICourseRepository
        ↓
SqlCourseRepository
        ↓
CourseDbContext
        ↓
SQL Server
```

---

# Service Layer

The Service layer contains the application's business logic.

For example:

```text
ICourseService
      ↓
CourseService
```

The controller communicates with the service instead of directly communicating with the database.

This keeps controllers smaller and separates responsibilities between layers.

---

# DTOs

The API uses Data Transfer Objects instead of returning Entity objects directly.

For example:

```text
Course Entity
      ↓
MapToDto()
      ↓
CourseResponseDto
```

This prevents navigation properties from being serialized unnecessarily.

It also prevents circular references such as:

```text
Course
  ↓
Category
  ↓
Courses
  ↓
Category
  ↓
...
```

and:

```text
Course
  ↓
Lessons
  ↓
Course
  ↓
Lessons
  ↓
...
```

The controllers therefore return simplified response DTOs.

Example:

```json
{
  "courseId": 1,
  "courseName": "ASP.NET Core Web API",
  "courseInstructor": "Jina",
  "categoryId": 1,
  "category": {
    "categoryId": 1,
    "categoryName": "Backend Development",
    "categoryDescription": "Courses about backend programming"
  },
  "coursePrice": 700000,
  "courseDuration": 40,
  "lessons": [
    {
      "lessonId": 1,
      "lessonTitle": "Dependency Injection",
      "lessonDescription": "Learn DI in ASP.NET Core",
      "courseId": 1
    }
  ]
}
```

---

# Reflection-Based Dependency Injection

One of the main exercises in this project is automatic Dependency Injection registration using Reflection.

Instead of manually registering every service:

```csharp
builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ILessonService, LessonService>();
```

the project uses marker interfaces and Reflection.

The three marker interfaces are:

```csharp
IScopedDependency
ITransientDependency
ISingletonDependency
```

A class implements one of these interfaces to specify its DI lifetime.

For example:

```csharp
public class CourseService : ICourseService, IScopedDependency
{
}
```

The Reflection-based registration system scans the Service assembly and automatically registers the classes.

Conceptually:

```text
Assembly
   ↓
Find classes
   ↓
Find implemented interfaces
   ↓
Check DI marker interface
   ↓
Register automatically
```

The three lifetimes are mapped as follows:

```text
IScopedDependency
        ↓
AddScoped()

ITransientDependency
        ↓
AddTransient()

ISingletonDependency
        ↓
AddSingleton()
```

This removes the need to manually register every service.

---

# Automatic Service Registration

The API uses an extension method:

```csharp
builder.Services.AddCourseServices();
```

The extension method uses Reflection to load the Service assembly and discover classes automatically.

This allows new services to be registered by implementing the appropriate marker interface instead of modifying `Program.cs`.

For example:

```csharp
public class ExampleService : IExampleService, IScopedDependency
{
}
```

The Reflection system can automatically detect it and register it as Scoped.

---

# Entity Framework Core

The project uses Entity Framework Core with SQL Server.

The database context is:

```text
CourseDbContext
```

The database contains the following main tables:

```text
Categories
Courses
Lessons
```

Relationships:

```text
Categories
    │
    └── Courses

Courses
    │
    └── Lessons
```

Foreign keys:

```text
Courses.CategoryId → Categories.Id

Lessons.CourseId → Courses.Id
```

---

# Database Migrations

Entity Framework Core migrations are used to create and update the database schema.

Because the solution contains separate API and Service projects, EF commands are executed by specifying both projects.

Create a migration:

```bash
dotnet ef migrations add InitialCreate --project CourseManagement.Service --startup-project CourseManagement.API
```

Update the database:

```bash
dotnet ef database update --project CourseManagement.Service --startup-project CourseManagement.API
```

Drop the database when needed:

```bash
dotnet ef database drop --project CourseManagement.Service --startup-project CourseManagement.API
```

---

# Running the Project

Clone the repository and navigate to the solution directory:

```bash
cd CourseManagementAPI
```

Restore dependencies:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the API:

```bash
dotnet run --project CourseManagement.API
```

After the application starts, open Swagger using the URL shown in the terminal.

---

# Swagger

Swagger is used to test and explore the API.

Available controllers:

```text
Courses
Categories
Lessons
```

---

# API Endpoints

## Courses

```text
GET     /api/Courses
GET     /api/Courses/{id}
POST    /api/Courses
PUT     /api/Courses/{id}
DELETE  /api/Courses/{id}
```

## Categories

```text
GET     /api/Categories
GET     /api/Categories/{id}
POST    /api/Categories
PUT     /api/Categories/{id}
DELETE  /api/Categories/{id}
```

## Lessons

```text
GET     /api/Lessons
GET     /api/Lessons/{id}
GET     /api/Lessons/course/{courseId}
POST    /api/Lessons
PUT     /api/Lessons/{id}
DELETE  /api/Lessons/{id}
```

---

# Example Requests

## Create Category

```json
{
  "categoryName": "Backend Development",
  "categoryDescription": "Courses about backend programming"
}
```

## Create Course

```json
{
  "courseName": "ASP.NET Core Web API",
  "courseInstructor": "Jina",
  "categoryId": 1,
  "coursePrice": 700000,
  "courseDuration": 40
}
```

## Create Lesson

```json
{
  "lessonTitle": "Dependency Injection",
  "lessonDescription": "Learn DI in ASP.NET Core",
  "courseId": 1
}
```

---

# Dependency Injection Lifetimes

The project supports the three standard ASP.NET Core DI lifetimes:

### Scoped

One instance is created for each HTTP request.

```text
HTTP Request
     ↓
  Scoped Instance
```

This is the main lifetime used by the current application services and repositories.

### Transient

A new instance is created every time the service is requested.

```text
Request → New Instance
Request → New Instance
Request → New Instance
```

### Singleton

A single instance is created and reused throughout the application's lifetime.

```text
Application
     ↓
One Instance
     ↓
Reused
```

The project provides marker interfaces for all three lifetimes so that the Reflection-based registration system can support them.

---

# Error Handling and JSON Serialization

The API configures JSON serialization to ignore circular references:

```csharp
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler =
            System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });
```

However, the preferred API response approach is still to use DTOs rather than returning Entity objects directly.

---

# Learning Goals

This project was created as a practical exercise to understand:

* ASP.NET Core Web API
* Controllers
* REST APIs
* Entity Framework Core
* SQL Server
* Database migrations
* Repository Pattern
* Service Layer
* DTOs
* Entity relationships
* Dependency Injection
* Scoped, Transient, and Singleton lifetimes
* Reflection
* Automatic service registration
* Layered architecture
* Navigation properties
* Circular reference problems
* API testing with Swagger

---

# Project Status

The project currently includes:

* Course management
* Category management
* Lesson management
* SQL Server database
* Entity Framework Core
* Repository and Service layers
* DTO-based API responses
* Automatic Dependency Injection registration using Reflection
* Support for Scoped, Transient, and Singleton marker interfaces
* Swagger API documentation and testing

---

## Author

**Jina Faizi**

Computer Engineering Student

This project was developed as a learning and practice project for ASP.NET Core, software architecture, Dependency Injection, and Reflection.

```
```
