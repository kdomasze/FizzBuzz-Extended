using System;

namespace FizzBuzz_Extended
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i < 100; i++)
            {
                string output = "";

                if (i % 3 == 0) output += "Fizz";
                if (i % 5 == 0) output += "Buzz";

                if (output.Length == 0) output += i;
                
                Console.WriteLine(output);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }
    }
}
