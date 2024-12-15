# Assignment 1: .NET and Assembly Basics

## Overview
This assignment introduces fundamental .NET concepts and practical programming in C#. The task emphasizes analyzing assemblies, working with metadata, and exploring Intermediate Language (MSIL) using the `ildasm` tool. Additionally, it involves solving various programming problems to reinforce core C# skills.

## Objectives
- Understand the structure and components of .NET assemblies.
- Analyze assemblies using `ildasm`.
- Develop foundational C# programs with recursion, input validation, and basic data processing.

## Tasks

### Part 1: Assembly Analysis
1. Analyze `Ex01.exe` using `ildasm`:
   - Extract metadata and dependencies.
   - Inspect MSIL and understand its purpose.
   - Answer questions about the assembly's validity and structure.

2. Identify embedded credentials through code analysis.

---

### Part 2: Programming Tasks
1. **Binary Sequence Analysis**:
   - Convert binary numbers to decimal.
   - Calculate averages, count powers of 2, and detect increasing sequences.

2. **Diamond Printing**:
   - Print a diamond pattern using recursion.
   - Allow user-defined diamond heights with input validation.

3. **String Analysis**:
   - Check if a string is a palindrome.
   - Analyze content type (letters or numbers) and count lowercase letters.

4. **Number Statistics**:
   - Compute various statistics for an 8-digit number:
     - Count of smaller and divisible digits.
     - Largest digit.
     - Average of all digits.

---

## Technologies and Concepts
- **.NET Framework**:
  - Explore assemblies, metadata, and MSIL using `ildasm`.
- **C# Programming**:
  - Utilize recursion, `StringBuilder`, and `Math` for efficient solutions.
  - Input validation with `int.TryParse`.
- **Design Principles**:
  - Modular and reusable method design.
  - Structured implementation with clear separation of concerns.

## How to Run
1. Open the solution in Visual Studio.
2. Navigate to each project (e.g., `Ex01_01` for binary sequence analysis).
3. Build and run the program, following the prompts in the console.

## Tools and Environment
- **IDE**: Microsoft Visual Studio
- **Framework**: .NET Framework
- **Analysis Tool**: `ildasm` (Intermediate Language Disassembler)
  
