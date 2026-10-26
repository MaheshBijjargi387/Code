using System;

class Program{
    static void Main(){
        Console.WriteLine("Enter num1: ");
        int num1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter num2 :");
        int num2 =Convert.ToInt32(Console.ReadLine());

        if(num1>num2){
            Console.WriteLine(num1+" is greater");
        }
        else{
            Console.WriteLine(num2+" is greter");
        }
        
    }
}