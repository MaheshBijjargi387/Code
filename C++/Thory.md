# What is C++?
C++ is a general-purpose programming language used to develop software, games, operating systems, and high-performance applications.

# Why do we use C++?
C++ is used for:
1. Game Development: Creating games and game engines.
2. Operating Systems: Developing system-level software.
3. Desktop Applications: Building software that runs on computers.
4. Embedded Systems: Programming devices and electronic systems.
5. High-Performance Applications: Developing applications that need speed and efficient memory usage.
6. Competitive Programming: Solving coding problems and practicing data structures and algorithms.

# What are the features of C++?
- Object-Oriented Programming (OOP): Supports classes and objects.
- Fast Execution: Can execute programs efficiently.
- Memory Management: Provides control over memory allocation and deallocation.
- Platform Support: C++ programs can run on different operating systems when compiled for those platforms.
- Multi-Paradigm: Supports procedural, object-oriented, and generic programming.

# How does C++ work?
The basic process is:
1. Write C++ code in a code editor.
2. Compile the code using a compiler.
3. The compiler converts the code into machine code.
4. Execute the compiled program to get the output.

# C++ Program Structure
A C++ program structure is the arrangement of different parts of a C++ program. Each part has a specific purpose, such as including libraries, defining the main() function, writing statements, and returning a value.

# include <iostream>
->#include is a preprocessor directive.
iostream is a standard library header.
It provides input and output features, such as cin and cout.

# What Are Tokens in C++?
Tokens are the smallest individual units of a C++ program that have meaning to the compiler.

# Initialization
->Initialization is the process of giving an initial value to a variable when it is created.

# Direct Initialization
In direct initialization, we provide the initial value inside parentheses.
#include <iostream>
using namespace std;

int main()
{
    int age(22);
    float price(99.5f);

    cout << age << endl;
    cout << price << endl;

    return 0;
}

# What Are Static Members?
Static members are variables or functions that belong to a class itself rather than to individual objects.

# What Are Constant Members?
Constant members are class members whose values cannot be modified after initialization, subject to the rules of the particular type of member.

# What Is an Expression?
An expression in C++ is a combination of values, variables, operators, and function calls that produces a result or designates an object or function.

# C++ Arrays
An array in C++ is used to store multiple values of the same data type in a single variable.

# ++: Different Forms of Functions
In C++, functions can be classified based on whether they accept parameters and whether they return a value.

There are four common forms of functions:
1. No arguments and no return value.
2. Arguments and no return value.
3. No arguments but a return value.
4. Arguments and a return value.

# What Is Function Prototyping?
Function prototyping means declaring a function before using it, so the compiler knows the function's name, return type, and parameters.

#include <iostream>
using namespace std;

int add(int, int);  // Function prototype

int main() {
    int result = add(10, 20);
    cout << result;

    return 0;
}

int add(int a, int b) {
    return a + b;
}

# What Is Call by Reference?
Call by reference is a method of passing arguments to a function where the function parameter refers to the original variable.This means changes made to the parameter inside the function affect the original variable.

#include <iostream>
using namespace std;

void change(int &x) {
    x = 100;
}

int main() {
    int a = 10;

    change(a);

    cout << a;

    return 0;
}

# C++: Math Library Functions
In C++, math library functions are built-in functions used to perform mathematical calculations such as finding square roots, powers, absolute values, and rounding numbers.

# What Is Memory Management?
Memory management in C++ is the process of allocating, using, and releasing computer memory while a program runs.

# . Types of Memory in C++
For beginners, it's useful to understand these three main memory areas:
1. Stack:Local variables and function-call information are commonly stored on the stack.
2. Heap (free store): The heap, also called the free store in C++ terminology, is used for dynamic memory allocation.Dynamic allocation allows you to request memory while the program is running.  C++ provides the new and delete operators for this purpose.
3. Static storage : Variables with static storage duration exist for the entire execution of the program.


# What Is a Memory Leak?
A memory leak occurs when dynamically allocated memory is no longer needed but remains allocated because the program has failed to release it or manage its ownership properly.

# hat is memory management in C++?

Memory management is the process of allocating, using, and releasing memory efficiently during program execution.

# What is the difference between stack and heap memory?

Stack memory is commonly used for local variables and function calls, with lifetimes managed automatically. Heap memory supports dynamic allocation, where the allocated object's lifetime is managed explicitly or through ownership tools.

# What are new and delete?

new dynamically allocates memory and creates an object. delete destroys the object and releases memory allocated for it by the corresponding single-object new.

# What is a memory leak?

A memory leak occurs when allocated memory remains unreleased even though the program no longer needs it.

#  What is a smart pointer?

A smart pointer is a C++ object that manages a resource's ownership and helps release dynamically allocated memory automatically.

# C++: Pointers
1. What Is a Pointer?
A pointer is a variable that stores the memory address of another variable.
#include <iostream>
using namespace std;

int main() {
    int a = 10;
    int* ptr = &a;

    cout << "Value of a: " << a << endl;
    cout << "Address of a: " << &a << endl;
    cout << "Value of ptr: " << ptr << endl;

    return 0;
}

# Arrays Using Pointers
In C++, pointers can be used to access and manipulate array elements through their memory addresses.
#include <iostream>
using namespace std;

int main() {
    int arr[5] = {10, 20, 30, 40, 50};

    int* ptr = arr;

    cout << *ptr << endl;
    cout << *(ptr + 1) << endl;
    cout << *(ptr + 2) << endl;

    return 0;
}

# What Is an Enumeration?
An enumeration (enum) in C++ is a user-defined type that represents a set of named constants.

It makes code easier to read because you can use meaningful names instead of unexplained numeric values.

#include <iostream>
using namespace std;

enum Day {
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday
};

int main() {
    Day today = Wednesday;

    cout << today;

    return 0;
}

# What is typedef in C++?

typedef is a keyword used to create an alternative name for an existing data type. It improves code readability and can simplify complex declarations. For example, typedef unsigned int uint; allows us to use uint instead of unsigned int.

# What is the new operator?

The new operator dynamically allocates memory and creates an object in that memory. It returns a pointer to the created object.

# What is the difference between new and new[]?

new allocates a single object, while new[] allocates an array of objects.

# Why do we use delete?

We use delete to destroy an object created with single-object new and release its allocated memory.

# Pointer to Class Objects
A class pointer is a pointer that stores the memory address of an object of a class.
#include <iostream>
using namespace std;

class Student {
public:
    int age = 20;
};

int main() {
    Student s;

    Student* ptr = &s;

    cout << s.age << endl;
    cout << ptr->age << endl;

    return 0;
}

# malloc() Function
malloc() stands for memory allocation.

It allocates a specified number of bytes but does not initialize the allocated memory.
#include <iostream>
#include <cstdlib>
using namespace std;

int main() {
    int* ptr = (int*)malloc(sizeof(int));

    if (ptr != nullptr) {
        *ptr = 50;
        cout << *ptr;

        free(ptr);
    }

    return 0;
}

# calloc() Function
calloc() stands for contiguous allocation.

It allocates memory for multiple elements and initializes all allocated bytes to zero.

#include <iostream>
using namespace std;

class Student {
public:
    Student() {
        cout << "Constructor called";
    }
};

int main() {
    Student* s = new Student();

    delete s;

    return 0;
}

# What Is a Class?
A class is a blueprint for creating objects. It defines the data and functions that objects can contain.

# What Is an Object?
An object is an instance of a class. We create objects to use the data and functions defined in the class.

# What is function overloading in C++?

Function overloading is a feature in C++ that allows us to define multiple functions with the same name but different parameter lists. The functions can differ in the number, types, or order of their parameters. It supports compile-time polymorphism. However, we cannot overload functions by changing only their return types.

# What Is a Namespace?
A namespace in C++ is used to organize code and prevent naming conflicts.

Suppose two developers create functions with the same name, display(). If both functions are in the same namespace, the compiler may report a redefinition error.

# What is a constructor in C++?

A constructor is a special member function that is automatically called when an object is initialized. It has the same name as the class and does not have a return type. Constructors are used to initialize object data members. The commonly used types are default constructors, parameterized constructors, and copy constructors. C++ also supports constructor overloading.

# What is a parameterized constructor in C++?

A parameterized constructor is a constructor that accepts arguments to initialize an object's data members with specific values. It allows us to create multiple objects with different initial values using the same constructor.

# Dynamic Initialization of Objects in C++
Dynamic initialization of objects means initializing an object with values that are determined at runtime, such as values entered by the user or calculated by a program.

#include <iostream>
using namespace std;

class Student {
public:
    int age;

    Student(int a) {
        age = a;
    }
};

int main() {
    int userAge;

    cout << "Enter your age: ";
    cin >> userAge;

    Student s(userAge);

    cout << "Student age: " << s.age;

    return 0;
}


# Copy Constructor in C++
A copy constructor is a special constructor used to create a new object by copying the values of an existing object.
#include <iostream>
using namespace std;

class Student {
public:
    int age;

    Student(int a) {
        age = a;
    }

    // Copy constructor
    Student(const Student &s) {
        age = s.age;
    }
};

int main() {
    Student s1(20);

    Student s2(s1);  // Copy constructor called

    cout << s1.age << endl;
    cout << s2.age;

    return 0;
}


# Destructor in C++
A destructor is a special member function that is automatically called when an object is destroyed. It is commonly used to release resources, such as dynamically allocated memory or open files.

# What is a virtual base class in C++?

A virtual base class is a base class inherited using the virtual keyword. It prevents multiple inheritance paths from creating separate copies of the same base-class subobject. It is commonly used to solve the diamond problem in multiple inheritance.

# When do we use a virtual base class?
Use virtual inheritance when:
1. Multiple inheritance paths lead to the same base class.
2. You want the final derived object to share one base-class subobject.
3. Duplicate base-class state or ambiguity would otherwise cause problems.

# Constructors in derived class
In C++, when a derived-class object is created, the base-class constructor executes first, followed by the derived-class constructor. If the base class requires arguments, we pass them through the derived class's constructor initializer list, such as Child(int x) : Parent(x) {}.

# Types of Polymorphism in C++
Polymorphism is an object-oriented programming concept that means one name or interface can have multiple forms of behavior.

In simple words, the same function name can perform different actions depending on the situation.

C++ has two main types of polymorphism:
1. Compile-time polymorphism
2. Runtime polymorphism

# Compile-Time Polymorphism
Compile-time polymorphism means the compiler determines which function or operation to use during compilation.

It is commonly achieved through:
- Function overloading
- Operator overloading

# Runtime Polymorphism
Runtime polymorphism means the appropriate overridden function is selected at runtime based on the actual object.

# What are the types of polymorphism in C++?

C++ has two main types of polymorphism: compile-time and runtime polymorphism. Compile-time polymorphism is achieved through function overloading and operator overloading, where the compiler selects the appropriate operation. Runtime polymorphism is achieved through virtual functions and overriding, allowing the appropriate derived-class function to execute at runtime.

# What is a Friend Function?
A friend function is a normal function that is allowed to access the private and protected members of a class.

# What is a Constant Function?
A constant member function is a member function that cannot modify the normal data members of an object.

We declare it by adding the const keyword after the function's parameter list.

#include <iostream>
using namespace std;

class Student {
private:
    int marks = 90;

public:
    void display() const {
        cout << "Marks: " << marks;
    }
};

int main() {
    Student s;
    s.display();

    return 0;
}

# What Is an Abstract Class?
A class that has at least one pure virtual function is called an abstract class.

# What is a pure virtual function in C++?

A pure virtual function is a virtual function declared using = 0 in a base class. It makes the class abstract, so we cannot create its objects. Derived classes must override the pure virtual function to become concrete classes. Pure virtual functions are commonly used to define a common interface for different derived classes.

# What is dynamic_cast in C++?

dynamic_cast is a type-casting operator used with polymorphic class hierarchies to perform runtime-checked conversions, especially from a base class to a derived class. If a pointer conversion fails, it returns nullptr. If a reference conversion fails, it throws std::bad_cast.
#include <iostream>
using namespace std;

class Animal {
public:
    virtual void sound() {
        cout << "Animal sound" << endl;
    }
};

class Dog : public Animal {
public:
    void bark() {
        cout << "Dog barks" << endl;
    }
};

int main() {
    Animal* a = new Dog();

    Dog* d = dynamic_cast<Dog*>(a);

    if (d != nullptr) {
        d->bark();
    } else {
        cout << "Conversion failed";
    }

    delete a;

    return 0;
}

# What is static_cast in C++?

static_cast is a C++ type-casting operator used to perform explicit conversions between types when the conversion is permitted by the language. It is commonly used for numeric conversions and certain conversions within class hierarchies. Unlike dynamic_cast, it does not perform a runtime type check for downcasting.
#include <iostream>
using namespace std;

class Animal {
public:
    void eat() {
        cout << "Animal eats" << endl;
    }
};

class Dog : public Animal {
public:
    void bark() {
        cout << "Dog barks" << endl;
    }
};

int main() {
    Dog d;

    Animal* a = &d;

    Dog* ptr = static_cast<Dog*>(a);

    ptr->bark();

    return 0;
}

# Rules of Interfaces in C++
1. C++ does not have a dedicated interface keyword.
2. Interfaces are commonly represented by abstract classes with pure virtual functions.
3. A class that does not implement all inherited pure virtual functions remains abstract.
4. A class can implement multiple interfaces using multiple inheritance.
5. Interface classes commonly have a public virtual destructor to support safe deletion through a base-class pointer.
class Printable {
public:
    virtual void print() = 0;
    virtual ~Printable() = default;
};

class Scannable {
public:
    virtual void scan() = 0;
    virtual ~Scannable() = default;
};

class Machine : public Printable, public Scannable {
public:
    void print() override {
        cout << "Printing" << endl;
    }

    void scan() override {
        cout << "Scanning" << endl;
    }
};

# What is an interface in C++?

C++ does not have a dedicated interface keyword. We typically create an interface using an abstract class containing pure virtual functions. Derived classes implement these functions according to their requirements. Interfaces help achieve abstraction, support loose coupling, and enable run-time polymorphism.

# What is an abstract class in C++?

An abstract class is a class that cannot be instantiated directly. In C++, a class becomes abstract when it contains at least one pure virtual function. It can contain constructors, data members, and normal functions. Derived classes must implement the inherited pure virtual functions to become concrete classes.

#include <iostream>
using namespace std;

class Shape {
public:
    virtual void draw() = 0;
};

class Circle : public Shape {
public:
    void draw() override {
        cout << "Circle";
    }
};

int main() {
    Shape* s;
    Circle c;

    s = &c;
    s->draw();

    return 0;
}

# What is exception handling in C++?
Exception handling is a mechanism for handling runtime errors using try, throw, and catch. The try block contains code that may throw an exception, throw signals the exception, and catch handles a matching exception. It helps programs respond to errors in a controlled way.

# Important Points for Interviews
1. Exception: An unexpected condition or error represented by a thrown value.
2. try: Encloses code that may throw an exception.
3. throw: Signals an exception.
4. catch: Handles a matching exception.
5. Multiple catch blocks: Allow different exception types to be handled separately.
6. Exception handling does not prevent every runtime error. For example, C++ does not automatically throw an exception for integer division by zero.
7. In modern C++, standard exception classes such as std::runtime_error are commonly used for reporting errors.
#include <iostream>
using namespace std;

int main() {
    try {
        throw 50;
    }
    catch (int x) {
        cout << "A: " << x;
    }

    return 0;
}

# What is exception specification in C++?

Exception specification describes the exception-throwing behavior of a function. Older C++ versions supported dynamic exception specifications such as throw(int), but these were removed in C++17. Modern C++ uses noexcept to indicate that a function is not supposed to let exceptions escape. Different catch blocks can handle different exception types.

# What is a stream in C++?

A stream is a flow of data between a program and an input or output source. C++ uses input streams to receive data and output streams to display or send data. For example, cin is used for standard input, and cout is used for standard output.

#include <iostream>
#include <fstream>
using namespace std;

int main() {
    ofstream file("data.txt");

    file << "Hello C++";

    file.close();

    return 0;
}

# What Is Unformatted I/O?
Unformatted I/O operations read or write characters or blocks of data without applying the usual formatted conversion of values.

Common unformatted input functions include:
- get(): Reads a single character, including whitespace characters such as spaces.
- getline(): Reads an entire line, including spaces, until the newline character.
- read() : These functions read and write blocks of characters or bytes.
- ignore(): Skips characters in an input stream.
- peek(): Examines the next character without removing it from the input stream.