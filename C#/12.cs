using System;

class Program{
    static void Main(){
        for(int i=0;i<5;i++){
            for(int j=0;j<5;j++){
                if(j>=4-i){
                    Console.Write(" *");
                }
                else{
                    Console.Write("  ");
                }
            }
            Console.WriteLine();
        }
    }
}