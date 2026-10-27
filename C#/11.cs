using System;

class Program{
    static void Main(){
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                if(j<=i){
                    Console.Write("* ");
                }
            }
            Console.WriteLine();
        }
    }
}