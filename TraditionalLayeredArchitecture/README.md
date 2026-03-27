# Traditional Layered Architecture (Classic 3-Tier Architecture)

## Overview

Traditional Layered Architecture is one of the oldest and most commonly used software design patterns. It organizes an application into separate layers, each with a specific responsibility.

The main idea is **separation of concerns**, where each layer handles a specific part of the system.

---

## Architecture Layers

### 1. Presentation Layer (UI / API Layer)

* Responsible for handling user requests
* In Web APIs: Controllers
* Does NOT contain business logic

**Example:**

* ASP.NET Controllers
* MVC Views

---

### 2. Business Logic Layer (Service Layer)

* Contains core business rules
* Processes data and applies logic
* Communicates between Presentation and Data layers

**Example:**

* StudentService
* OrderService

---

### 3. Data Access Layer (Repository Layer)

* Handles database operations
* CRUD operations (Create, Read, Update, Delete)
* Abstracts database from business logic

**Example:**

* StudentRepository
* Generic Repository

---

### 4. Database Layer

* Actual storage system
* SQL Server / MySQL / PostgreSQL

---

## Request Flow

```
Client → Controller → Service → Repository → Database
```

And back:

```
Database → Repository → Service → Controller → Client
```

---

## Example in .NET

### Controller

```csharp
[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(_studentService.GetAllStudents());
    }
}
```

---

### Service Layer

```csharp
public class StudentService : IStudentService
{
    private readonly IStudentRepository _repo;

    public StudentService(IStudentRepository repo)
    {
        _repo = repo;
    }

    public IEnumerable<Student> GetAllStudents()
    {
        return _repo.GetAll();
    }
}
```

---

### Repository Layer

```csharp
public class StudentRepository : IStudentRepository
{
    private readonly AppDbContext _context;

    public StudentRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Student> GetAll()
    {
        return _context.Students.ToList();
    }
}
```

---

## Advantages

* Simple and easy to understand
* Good for small and medium projects
* Clear separation of responsibilities
* Easy to implement

---

## Disadvantages

* Business logic may become scattered in Services
* Tight coupling between layers over time
* Hard to scale for large complex systems
* Repeated boilerplate code

---

## When to Use

* Small projects
* Learning purposes
* Simple CRUD applications
* Fast prototyping

---

## Summary

Traditional Layered Architecture is a good starting point for beginners, but in large-scale systems it is often replaced or combined with modern patterns like:

* Clean Architecture
* CQRS
* Vertical Slice Architecture
