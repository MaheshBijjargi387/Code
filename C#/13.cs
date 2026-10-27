using System;

class Program{
    static void Main(){
        for(int i=1;i<=9;i++){
            int start=0;

            if(i<=5){
                start=i;
            }
            else{
                start=10-i;
            }
            for(int j=1;j<=start;j++){
                Console.Write("*");
            }
            Console.WriteLine();
            
            
        }
    }
}