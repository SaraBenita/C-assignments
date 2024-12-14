# Garage Management System

## Overview
A comprehensive system for managing vehicles in a garage, designed to demonstrate advanced Object-Oriented Programming concepts in C#. The project separates logic and user interface into distinct layers for reusability and scalability.

## Features
- Add vehicles of different types (Cars, Motorcycles, Trucks).
- Update vehicle properties such as fuel levels or tire pressure.
- Display vehicle details with filters for state or registration number.
- Handle errors with custom exceptions for validation.

## System Structure

### Core Classes
- **`Vehicle` (Base Class)**:
  - Represents general attributes and behaviors shared by all vehicles.
  - **Properties**:
    - `ModelName` (string): The vehicle's model name.
    - `LicenseNumber` (string): The unique registration number.
    - `EnergyLeftPercentage` (float): Percentage of remaining energy (fuel or battery).
    - `Wheels` (Collection of `Wheel` objects): Represents the set of wheels for the vehicle.

- **Derived Classes**:
  - **`Motorcycle`**:
    - Includes additional attributes like `LicenseType` (enum) and `EngineCapacity` (int).
  - **`Car`**:
    - Adds attributes like `Color` (enum) and `NumberOfDoors` (enum).
  - **`Truck`**:
    - Adds `IsCarryingHazardousMaterials` (bool) and `CargoVolume` (float).

- **Wheel Class**:
  - Represents the properties of each wheel, including methods to inflate wheels.

- **Energy Source Classes**:
  - **Fuel**: Handles fuel type and levels.
  - **Electric**: Manages battery capacity and charge levels.

## Technologies and Concepts
- **Inheritance and Polymorphism**.
- **Enums** for fixed options.
- **Custom Exceptions** for robust error handling.
- **Collections** for managing vehicles.
- **Class Libraries** for separation of logic (`Ex03.GarageLogic.dll`).

## How to Run
1. Build the solution in Visual Studio.
2. Run the ConsoleUI project to interact with the system.
3. Follow the on-screen prompts to manage garage operations.

## Diagram
A diagram explaining the relationship between the classes:
<img src="./Screenshots/D1.png" alt="D1" width="600">
<img src="./Screenshots/D2.png" alt="D2" width="600">


