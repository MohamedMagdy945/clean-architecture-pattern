## 3. CQRS (Command Query Responsibility Segregation)

### 📌 Overview

CQRS is a design pattern that separates **read operations (queries)** from **write operations (commands)** in an application.

Instead of having a single service handling everything, responsibilities are split into:

* **Command** → Handles data modification (Create / Update / Delete)
* **Query** → Handles data retrieval only (Read)

---

### 🧠 Core Idea

In traditional design:

* The same class handles both read and write
* Harder to scale
* Code becomes complex over time

In CQRS:

* Each operation has its own class and handler
* Clear separation of concerns
* Easier to maintain and extend

---

### ✍️ Commands (Write Side)

Commands represent operations that **change the state** of the system.

#### Example:

```csharp
public record CreateStudentCommand(string Name, int Age);
```

#### Handler:

```csharp
public class CreateStudentHandler
{
    public async Task Handle(CreateStudentCommand command)
    {
        // Save to database
    }
}
```

---

### 🔍 Queries (Read Side)

Queries represent operations that **retrieve data without modifying it**.

#### Example:

```csharp
public record GetStudentByIdQuery(int Id);
```

#### Handler:

```csharp
public class GetStudentByIdHandler
{
    public async Task<StudentDto> Handle(GetStudentByIdQuery query)
    {
        // Read from database
        return new StudentDto();
    }
}
```

---

### ⚖️ Key Differences

| Feature       | Command     | Query     |
| ------------- | ----------- | --------- |
| Purpose       | Modify data | Read data |
| Returns value | Usually no  | Yes       |
| Changes state | Yes         | No        |

---

### 🚀 Benefits

* Clear separation of responsibilities
* Better scalability
* Easier optimization (e.g., caching for queries)
* Cleaner and more maintainable code

---

### ⚠️ Drawbacks

* Adds extra complexity
* Can be overkill for small projects
* Requires good structure and organization

---

### 🔗 CQRS with MediatR

CQRS is commonly used with MediatR in .NET applications to dispatch commands and queries.

```csharp
await _mediator.Send(new CreateStudentCommand("Ali", 22));
```

---

### 🧩 Folder Structure Example

```
/Application
    /Commands
        CreateStudentCommand.cs
    /CommandHandlers
        CreateStudentHandler.cs
    /Queries
        GetStudentByIdQuery.cs
    /QueryHandlers
        GetStudentByIdHandler.cs
```

---

### 🏁 Summary

CQRS = Separate Read from Write

* Commands handle changes
* Queries handle reads
* Each operation has its own handler

This leads to a more scalable and maintainable architecture, especially in large applications.
