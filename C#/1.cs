using System;

class Program{
    static void Main(){
    Console.WriteLine("Enter Name :");
    string name=Console.ReadLine();
    Console.WriteLine("Enter City");
    string city = Console.ReadLine();
    Console.WriteLine("Enter Age :");
    int age = Convert.ToInt32(Console.ReadLine());

    Console.WriteLine("Name :"+name);
    Console.WriteLine("City :"+city);
    Console.WriteLine("Age :"+age);
    }
    
}