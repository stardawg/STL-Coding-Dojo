using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzKata
{
    class Program
    {
        static void Main(string[] args)
        {
            FizzBuzz fb = new FizzBuzz();
            for (int i = 1; i <= 100; i++)
                Console.WriteLine(i.ToString() + " = " + fb.PrintNumber(i));
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
