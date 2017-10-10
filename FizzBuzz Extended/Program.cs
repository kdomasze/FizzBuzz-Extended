using System;
using System.Collections.Generic;
using System.IO;

namespace FizzBuzz_Extended
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration configuration = Parser.Parse("Replacements.txt");

            for (int i = configuration.Range.StartRange; i <= configuration.Range.EndRange; i++)
            {
                string output = ReplaceValueFromDictionary(i, configuration);

                Console.WriteLine(output);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        static string ReplaceValueFromDictionary(int input, Configuration configuration)
        {
            string output = String.Empty;

            // find and add replacements
            foreach (var replacement in configuration.Replacements)
            {
                if (input % replacement.Key == 0)
                {
                    output += replacement.Value;
                }
            }

            // pass back the input number if it doesn't get replaced
            if (output == String.Empty) output = input.ToString();

            return output;
        }
    }
}
