# What is the .NET Framework
->The .NET Framework is a Microsoft software development platform used to build and run applications. It provides the CLR for program execution and a class library for reusable functionality.

# What is CLR
->CLR stands for Common Language Runtime. It manages program execution, memory, and exception handling in the .NET Framework.

# What is FCL
->FCL stands for Framework Class Library. It provides reusable classes and methods for common programming tasks.

# What is JIT?
->JIT stands for Just-In-Time compiler. It converts Intermediate Language into native machine code at runtime.

# Explain the complete execution process of a C# program in .NET.
->When we write a C# program, the C# compiler converts the source code into Intermediate Language, also called IL.

This IL code is stored in an assembly, such as a DLL file.

The CLR, which stands for Common Language Runtime, manages the execution of the program. The JIT compiler converts the IL into native machine code, which the processor can execute.

Finally, the processor executes the machine code and produces the output.

# explain Intermediate Language 
->IL stands for Intermediate Language. When we write a C# program, the C# compiler converts the source code into IL instead of directly converting it into machine code. The JIT compiler then converts IL into native machine code, which the processor can execute.

# What is an Assembly in .NET?
->An assembly is a compiled unit of a .NET application that contains IL code, metadata, and other information needed by the application.

# What is an EXE?
->An .exe file is commonly used for an executable application.

For example, a Windows desktop application can be distributed as an executable file.

# What is a DLL?
->DLL stands for Dynamic Link Library.

A .dll file commonly contains code that can be reused by other components or applications.

For example, suppose you develop an employee management system. You might create a separate DLL containing employee-related business logic that other parts of the application can use.

# What is JIT Compilation?
->JIT stands for Just-In-Time compiler. It is a component of the .NET runtime that converts Intermediate Language into native machine code at runtime. This allows the processor to execute the program. JIT compilation can also optimize code for the current execution environment.

# Memory Management
->Memory management in .NET is the process of allocating and reclaiming memory while an application runs. The CLR manages memory for managed objects. When we create an object, memory is typically allocated on the managed heap. When the object is no longer reachable, the Garbage Collector can reclaim its memory automatically.

# Garbage Collection
->Garbage Collection is a feature of .NET that automatically reclaims memory occupied by managed objects that are no longer reachable. It is managed by the .NET runtime and helps reduce the need for manual memory management.

.NET uses three generations: Generation 0 for newer objects, Generation 1 for objects that survive an earlier collection, and Generation 2 for longer-lived objects. This approach helps improve garbage collection efficiency.

# What Is AppDomain Management?
->AppDomain stands for Application Domain. In the .NET Framework, it is a logical isolation boundary within a process where managed code can execute. A single process can contain multiple AppDomains.

AppDomain management includes creating, configuring, loading assemblies into, and unloading application domains. It helps isolate managed components and allows an AppDomain to be unloaded without necessarily terminating the entire process.

# What is CTS?
->CTS stands for Common Type System. It defines how data types are declared and used in .NET. It allows different .NET languages to share compatible types and helps maintain type safety.

# What is Security in .NET?
->Security in .NET refers to the mechanisms used to protect applications, data, and resources from unauthorized access. Important security concepts include authentication, authorization, role-based access control, and data protection. The .NET Framework also provides legacy features such as Code Access Security.

# What is .NET Framework?
->.NET Framework is Microsoft's development platform primarily designed for Windows applications.
- Operating system: Windows.
- Used for: Desktop applications, web applications, and enterprise software.
- Technologies: ASP.NET MVC 5, Windows Forms, and WPF.
- Example: A company's existing employee management system built using C# and ASP.NET MVC 5.

# What is .NET Core?
->.NET Core was Microsoft's cross-platform, open-source implementation of .NET. It evolved into modern .NET, starting with .NET 5.
- Operating system: Windows, Linux, and macOS.
- Used for: Web APIs, web applications, cloud services, and console applications.
- Technologies: ASP.NET Core, Entity Framework Core, and modern .NET libraries.
- Example: A REST API built using ASP.NET Core that runs on Linux or Windows.

# What is Mono?
->Mono is an open-source, cross-platform implementation of .NET.

It was developed to run .NET applications on platforms beyond Windows and became particularly important for mobile development and game development.
- Operating systems: Supports multiple platforms, depending on the application.
- Used for: Cross-platform applications and games.
- Associated technologies: Xamarin and Unity.

# What is Xamarin?
->
# Xamarin was a development platform for building native mobile applications using C# and .NET.

Developers could share application logic across mobile platforms while building native user interfaces.
- Used for: Android and iOS applications.
- Language: C#.
- Runtime: Traditionally used Mono.
- Example: A shopping application for Android and iOS that shares much of its business logic.

# Managed and Unmanaged Code
->Managed code is code that executes under the control of the .NET runtime. It benefits from services such as automatic garbage collection, exception handling, and runtime type safety.

Unmanaged code executes outside the .NET runtime, such as native C or C++ code. Its memory and resource management depend on the language and implementation.

# Using ILDASM
->ILDASM stands for Intermediate Language Disassembler. It is a Microsoft tool used to inspect .NET assemblies, such as EXE and DLL files. It allows developers to view Intermediate Language instructions, metadata, classes, methods, and assembly manifest information. It is useful for understanding how compiled .NET code is structured.

# What is a Console Application?
->A Console Application is a program that runs in a terminal or command prompt and interacts with users through text.

# What is a Class Library?
->A Class Library is a project that contains reusable classes, methods, and other code that can be used by other .NET applications.

# What is C#?
->C# is a modern, object-oriented, general-purpose programming language developed by Microsoft. It runs on the .NET platform and is used to build web applications, APIs, desktop applications, games, and enterprise software.

# What is .NET?
->This is an important concept because C# and .NET are not the same thing.
- C# is a programming language.
- .NET is a development platform that provides the runtime, libraries, and tools needed to build and run applications.

# Your First C# Program
-> using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
    }
}

# What Is a Variable?
->A variable is a named storage location used to hold a value that a program can access and, when allowed, change.

# C# Data Types
->| Data type | Stores | Example |
|---|---|---|
| `int` | Whole numbers | `int age = 25;` |
| `long` | Large whole numbers | `long population = 8000000000L;` |
| `short` | Small-range whole numbers | `short number = 100;` |
| `byte` | Integers from 0 to 255 | `byte number = 100;` |
| `float` | Floating-point numbers with about 6–9 significant digits of precision | `float price = 10.5f;` |
| `double` | Floating-point numbers with about 15–17 significant digits of precision | `double price = 10.5;` |
| `decimal` | Decimal-based numbers with high precision | `decimal price = 10.50m;` |
| `char` | One UTF-16 code unit | `char grade = 'A';` |
| `string` | Text | `string name = "Mahesh";` |
| `bool` | `true` or `false` | `bool isActive = true;` |


# what is var
-> only assing value to sigle data type we can not change into another data type
var age = 25;
age = 30;       // Valid
// age = "Hello"; // Invalid: string cannot be assigned to int
var: The compiler infers a fixed type.
# dynamic
->dynamic: The type-related checks for many operations are deferred until runtime.

# Nullable Value Types
->Consider an employee record where the age is not yet known.

An ordinary int cannot hold null, but a nullable integer can
int? age = null;

Console.WriteLine(age);

# What Is User Input?
->Console.WriteLine("Enter your name:");
string? name = Console.ReadLine();
Console.WriteLine("Your name is " + name);

# Why do we use int.Parse()?
->We use int.Parse() to convert a string containing a valid integer into an int.

