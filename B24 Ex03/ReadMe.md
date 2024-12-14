# Garage Management System

## Overview
A comprehensive system for managing vehicles in a garage, designed to demonstrate advanced Object-Oriented Programming concepts in C#. The project separates logic and user interface into distinct layers for reusability and scalability.

## Features
- Add vehicles of different types (Cars, Motorcycles, Trucks).
- Update vehicle properties such as fuel levels or tire pressure.
- Display vehicle details with filters for state or registration number.
- Handle errors with custom exceptions for validation.

## Technologies and Concepts
- **Inheritance and Polymorphism**: Shared and specific functionalities across vehicle types.
- **Collections**: Use of `List` or `Dictionary` to store vehicles.
- **Enums**: For predefined states and types (e.g., fuel types).
- **Custom Exceptions**: Robust error handling with exceptions like `ValueOutOfRangeException`.
- **External Library**: Logic implemented in `Ex03.GarageLogic.dll` for reusability.

## How to Run
1. Build the solution in Visual Studio.
2. Run the ConsoleUI project to interact with the system.
3. Follow the on-screen prompts to manage garage operations.

## Diagram
A diagram explaining the relationship between the classes:
<img src="./Screenshots/D1.png" alt="D1" width="600">
<img src="./Screenshots/D2.png" alt="D2" width="600">


