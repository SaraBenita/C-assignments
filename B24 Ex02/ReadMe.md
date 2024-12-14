# Memory Game

## Overview
The Memory Game is a console-based game implemented in C# using object-oriented programming principles. The objective is to match pairs of cards on a grid. The game supports single-player and two-player modes, tracking points and ensuring an intuitive user experience.

## Features
- User-defined grid size (must be even).
- Interactive gameplay with visual updates after each move.
- Point tracking for one or two players.
- Automatic grid shuffling for fairness.

## Technologies Used
- **C#**: Employed advanced OOP features such as classes, constructors, properties, and indexers.
- **.NET**: Integrated external libraries (e.g., `Ex02.ConsoleUtils.dll`) to enhance console-based interactions.

## C# Concepts Applied
### Object-Oriented Programming
- **Encapsulation**: Game logic, player details, and board management are encapsulated in separate classes.
- **Abstraction**: Details of the grid and card matching are abstracted to simplify the main program logic.
- **Polymorphism**: Not directly required but aligns with modular design.

### Other C# Features
- **Arrays and Collections**: Arrays to represent the game grid and collections for cards.
- **String Manipulation**: Displaying the game grid and processing user input.
- **External Libraries**: The game utilizes `Ex02.ConsoleUtils.dll` for functionalities like clearing the console screen.

## How to Run
1. Clone the repository containing this project.
2. Place the provided `Ex02.ConsoleUtils.dll` file in the specified directory (`C:\Temp`).
3. Open the solution in Visual Studio.
4. Build and run the project.

## Future Enhancements
- Add AI for single-player mode.
- Improve UI with a graphical interface.
- Include difficulty levels with larger grids or time-based challenges.
