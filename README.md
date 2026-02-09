# 🧪 LINQLab: Advanced Querying & Architectural Patterns

<div align="center">

![C#](https://img.shields.io/badge/Language-C%23_10.0-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/Platform-.NET_6.0%2B-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Architecture](https://img.shields.io/badge/Design_Pattern-Composite-FF5722?style=for-the-badge)
![Status](https://img.shields.io/badge/Status-Active_Development-success?style=for-the-badge)
![License](https://img.shields.io/badge/License-MIT-blue?style=for-the-badge)

<p align="center">
  <strong>A professional-grade console application demonstrating complex data manipulation via LINQ and scalable UI architecture using the Composite Design Pattern.</strong>
</p>

</div>

---

## 📖 Table of Contents

- [Overview](#overview)
- [Key Features](#features)
- [Architecture & Design](#architecture)
- [Project Structure](#structure)
- [Getting Started](#started)
- [Usage Examples](#usage)
- [Future Roadmap](#roadmap)
- [Author](#author)

---

## <a id="overview"></a>📖 Overview

**LINQLab** is engineered to bridge the gap between theoretical C# knowledge and real-world application architecture. 

While the core functionality simulates a **Debtor Management System** (tracking debts, payment dates, and geolocation), the project's primary focus is technical excellence in two areas:
1.  **Data Logic:** Utilizing **Advanced LINQ** (Language Integrated Query) for high-performance filtering, aggregation, and projection.
2.  **UI Architecture:** Implementing the **Composite Design Pattern** to create a recursive, infinitely nesting menu system that decouples the navigation logic from the console rendering.

This project serves as a reference implementation for **Clean Code principles** and **SOLID design**.

---

## <a id="features"></a>🌟 Key Features

### 🧠 Advanced LINQ Implementation
Beyond basic CRUD operations, this project leverages the full power of functional programming in C#:
* **Complex Filtering:** Dynamic queries handling `DateTime`, numerical ranges, and string manipulation simultaneously.
* **Aggregation & Statistics:** Real-time calculation of total debts, average interest rates, and regional grouping.
* **Projection:** Transforming complex `Debtor` objects into simplified DTOs (Data Transfer Objects) for reporting.

### 🏗️ Scalable Menu System (Composite Pattern)
Instead of a fragile `switch-case` loop, the UI is built as a tree structure:
* **Uniformity:** Both "Menus" (containers) and "Items" (actions) share the same `IMenuItem` interface.
* **Extensibility:** Adding a new feature is as simple as injecting a new class; no modification to the core loop is required.
* **Recursion:** Supports unlimited sub-menu depth.

### 🛡️ Robust Validation & Error Handling
* **Defensive Programming:** Inputs are sanitized via `InputService` and `Validation` classes.
* **Custom Exceptions:** Domain-specific error handling to ensure application stability.

---

## <a id="architecture"></a>📐 Architecture & Design

The application follows a **Layered Architecture**, ensuring strictly defined responsibilities:

| Layer | Responsibility | Components |
| :--- | :--- | :--- |
| **Presentation** | Handles User Interface and Input/Output. | `MenuHandler`, `MenuPrinter`, `Program.cs` |
| **Application** | Orchestrates workflows and connects UI to Logic. | `Application.cs`, `InputService` |
| **Domain/Service** | Contains Business Logic and Calculation Rules. | `DebtorService`, `Validation` |
| **Data Access** | Manages data retrieval and storage simulation. | `DebtorRegistry` |

---

## <a id="structure"></a>📂 Project Structure

A high-level overview of the codebase organization:

```text
LINQLab/
├── 📂 Core
│   ├── Debtor.cs             # The primary domain entity
│   └── GlobalUsing.cs        # Global directives for cleaner code
│
├── 📂 Data
│   └── DebtorRegistry.cs     # Repository pattern simulation (Data Seeding)
│
├── 📂 Services
│   ├── DebtorService.cs      # The "Brain" - Contains all LINQ logic
│   ├── InputService.cs       # Abstraction for Console I/O
│   ├── PromptService.cs      # User guidance and text resources
│   └── Validation.cs         # Input verification rules
│
├── 📂 UI (Composite Pattern)
│   ├── MenuItem.cs           # Component (Leaf & Composite nodes)
│   ├── MenuHandler.cs        # Navigator logic
│   └── MenuPrinter.cs        # Rendering logic
│
├── Application.cs            # App lifecycle manager
└── Program.cs                # Entry point
```

---

## <a id="started"></a>🚀 Getting Started

Follow these instructions to set up the project locally.

### Prerequisites
* [.NET 6.0 SDK](https://dotnet.microsoft.com/download) or higher.
* An IDE (Visual Studio 2022, VS Code, or JetBrains Rider).

### Installation

1.  **Clone the repository**
    ```bash
    git clone [https://github.com/huseynovanzrin142-beep/linqlab.git](https://github.com/huseynovanzrin142-beep/linqlab.git)
    ```

2.  **Navigate to the project directory**
    ```bash
    cd linqlab
    ```

3.  **Build the solution**
    ```bash
    dotnet build
    ```

4.  **Run the application**
    ```bash
    dotnet run
    ```

---

## <a id="usage"></a>💡 Usage Examples

### 1. The Menu System
The application greets you with a hierarchical menu. Navigate using the console interface:

```text
========================================
            M A I N   M E N U
========================================
1. List all debtors
2. Filter by Debt Amount (> 5000 AZN)
3. Search by Name
4. Advanced Statistics
0. Exit
========================================
Select an option: _
```

### 2. Sample Query Logic (Code Snippet)
*An example of how `DebtorService` utilizes LINQ to find specific records:*

```csharp
// Example: Finding debtors born in Winter with high debt
public List<Debtor> GetWinterHighDebtors()
{
    return _registry.GetAll()
        .Where(d => (d.BirthDay.Month == 12 || d.BirthDay.Month <= 2) 
                    && d.Debt > 4000)
        .OrderByDescending(d => d.Debt)
        .ToList();
}
```

---

## <a id="roadmap"></a>🔮 Future Roadmap

This project is designed to be a living codebase. Planned future improvements include:

- [ ] **Database Integration:** Migration from in-memory `DebtorRegistry` to **Entity Framework Core (SQL Server)**.
- [ ] **Dependency Injection:** Implementing `Microsoft.Extensions.DependencyInjection` for better testability.
- [ ] **Unit Testing:** Adding **xUnit** tests for `DebtorService` logic.
- [ ] **Async Operations:** Converting data fetching methods to `async/await`.

---

## <a id="author"></a>👨‍💻 Author

**Nazrin Huseynova** *Backend Developer | Baku State University*

Focused on building scalable, maintainable, and high-performance backend systems. Passionate about Software Architecture, Design Patterns, and .NET Technologies.

[🔗 LinkedIn](https://www.linkedin.com/) | [💻 GitHub Profile](https://github.com/huseynovanzrin142-beep)

---

<p align="center">
  <sub>Built with ❤️ and C# in Baku, Azerbaijan.</sub>
</p>
