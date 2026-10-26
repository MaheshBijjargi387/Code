using System;

class Program{
    static void Main(){
        Console.WriteLine("Enter number :");
        int num = Convert.ToInt32(Console.ReadLine());
        if(num%2==0){
            Console.WriteLine("This is even number");
        }
        else{
            Console.WriteLine("This is not even number");
        }
        
    }
}