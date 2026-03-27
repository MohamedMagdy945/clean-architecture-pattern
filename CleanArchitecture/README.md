# 🧠 Clean Architecture Pattern

This repository demonstrates the implementation of the **Clean Architecture** pattern in a .NET application.

---

## 📌 What is Clean Architecture?

Clean Architecture is a software design pattern introduced by **Robert C. Martin (Uncle Bob)**.

It focuses on:

* Separation of concerns
* Independence of frameworks
* Testability
* Maintainability

👉 The main rule:

> Dependencies always point inward.

---

## 🏗️ Architecture Layers

### 1. Domain Layer

* Core business entities
* No dependencies on any other layer
* Pure C# classes only

### 2. Application Layer

* Business logic (use cases)
* Uses interfaces, not implementations
* Depends only on Domain layer

### 3. Infrastructure Layer

* Database & external services
* Implements interfaces defined in Application layer

### 4. Presentation Layer (API)

* Entry point of the system
* Controllers / Endpoints
* Talks to Application layer

---

## 🔁 Dependency Rule

```
Presentation → Application → Domain
                 ↑
          Infrastructure
```

* Inner layers do NOT depend on outer layers
* Outer layers depend on inner layers

---

## 📦 Project Structure Example

```
Solution/
│
├── Project.API
├── Project.Application
├── Project.Domain
├── Project.Infrastructure
```

---

## 🎯 Benefits

* ✅ Loose coupling
* ✅ High testability
* ✅ Easy maintenance
* ✅ Scalable architecture
* ✅ Independent of frameworks

---

## ❌ Drawbacks

* ❌ More complexity for small projects
* ❌ Extra setup overhead
* ❌ Requires good understanding of architecture

---

## 🚀 When to Use?

* Large or medium-scale systems
* Complex business logic
* Systems that need scalability and long-term maintenance

---

## 🛠️ Technologies

* ASP.NET Core
* Entity Framework Core
* C#

---

## 📚 Summary

Clean Architecture helps you build systems that are:

* Independent
* Testable
* Maintainable

By isolating business logic from frameworks and infrastructure.
