# Programming Assignments Repository

## Overview
This repository contains a collection of programming assignments developed using C#. Each task demonstrates specific programming concepts, emphasizing Object-Oriented Programming (OOP), system design, and reusable architectures.

## Assignments

### Ex01. .NET and Assembly Basics
- **Description**: Explore fundamental .NET concepts by analyzing assemblies with `ildasm` and solving beginner and advanced C# programming challenges.
- **Key Features**:
  - Assembly inspection, metadata analysis, and MSIL exploration.
  - Binary sequence conversion and analysis.
  - Recursive diamond printing and string analysis.
- **Technologies**: `ildasm`, recursion, `StringBuilder`, and `Math` utilities.

### Ex02. Memory Game
- **Description**: A console-based memory game supporting one or two players. It reinforces OOP principles and utilizes external libraries for console management.
- **Key Features**:
  - Dynamic board size and real-time gameplay.
  - Single and two-player modes.
  - Score tracking and game conclusion.
- **Technologies**: Arrays, external DLLs (`Ex02.ConsoleUtils.dll`), and error handling.

### Ex03. Garage Management System
- **Description**: A system for managing vehicles in a garage. The application separates logic and UI, demonstrating OOP principles like inheritance and polymorphism.
- **Key Features**:
  - Add and update vehicle data.
  - Manage fuel and tire states.
  - Retrieve and display vehicle details.
- **Technologies**: Enums, collections, custom exceptions, and DLLs (`Ex03.GarageLogic.dll`).

### Ex04. Hierarchical Menu Management System
- **Description**: A reusable menu management system for console applications. It supports hierarchical menus with flexible navigation and action execution.
- **Key Features**:
  - Navigation through nested menus.
  - Separate implementations using interfaces and delegates.
- **Technologies**: Delegates, Action<T>, interfaces, and DLLs (`Ex04.Menus.Interfaces.dll`, `Ex04.Menus.Events.dll`).

## How to Use
Each assignment has its own subdirectory containing a specific `README.md` file with detailed instructions. Follow these steps:
1. Navigate to the respective assignment folder.
2. Read the specific `README.md` for setup and usage instructions.
3. Build and run the solution in Visual Studio.

## Tools and Environment
- **Programming Language**: C#
- **IDE**: Microsoft Visual Studio
- **Framework**: .NET Framework
