    using System;
    
    class Program{
        static void Main(){
            Console.WriteLine("Enter number :");
            int num = Convert.ToInt32(Console.ReadLine());
            if(num>0){
                Console.WriteLine("This is positive number");
                
            }
            else if(num==0){
                Console.WriteLine("This is zero");
            }
            else{
                Console.Write("This is negative number");
            }
        }
    }