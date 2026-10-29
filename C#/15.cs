using System;

class Program
{
    static void PrintNumber(int n)
    {
        if (n > 5)
        {
            return;
        }

        Console.WriteLine(n);
        PrintNumber(n + 1);
    }

    static void Main()
    {
        PrintNumber(1);
    }
}