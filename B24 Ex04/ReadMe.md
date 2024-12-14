# Hierarchical Menu Management System

## Overview
This project provides a reusable hierarchical menu component for console applications. It demonstrates advanced concepts like interfaces and delegates to achieve flexible and maintainable designs.

## Features
- Create and manage hierarchical menus.
- Navigate through menus and execute actions.
- Separate implementations using interfaces and delegates.

## System Structure

### Core Classes
- **`MenuItem`**:
  - Represents a single item in the menu.
  - **Properties**:
    - `Title` (string): The name of the menu item.
    - `SubMenuItems` (Collection): Nested menu items.
    - `Action` (delegate): A function executed when the menu item is selected.
  - **Methods**:
    - `Execute()` and `Display()` for navigation and action execution.

- **`MainMenu`**:
  - Represents the root menu and serves as the entry point.

## Technologies and Concepts
- **Interfaces** to abstract menu behavior.
- **Delegates** and **Action<T>** for attaching executable actions to menu items.
- **Collections** to organize hierarchical menu structures.
- Two separate implementations for flexibility:
  1. `Ex04.Menus.Interfaces.dll`: Interface-based menu.
  2. `Ex04.Menus.Events.dll`: Delegate-based menu.

## How to Run
1. Build the solution in Visual Studio.
2. Run the `Ex04.Menus.Test` project.
3. Explore the menu navigation and execute predefined actions (e.g., show version or count uppercase letters).
