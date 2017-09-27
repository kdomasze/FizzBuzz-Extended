using System;
using System.Collections.Generic;
using System.IO;

namespace FizzBuzz_Extended
{
    class Program
    {
        static void Main(string[] args)
        {
            int start;
            int end;
            Dictionary<Int32, String> replacementsDictionary = new Dictionary<int, string>();

            ParseConfiguration("Replacements.txt", out start, out end, replacementsDictionary);

            for (int i = start; i <= end; i++)
            {
                string output;
                ReplaceValueFromDictionary(i, out output, replacementsDictionary);

                Console.WriteLine(output);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
        }

        static void ReplaceValueFromDictionary(int input, out string output, Dictionary<Int32, String> replacementsDictionary)
        {
            output = "";

            foreach (var replacement in replacementsDictionary)
            {
                if (input % replacement.Key == 0)
                {
                    output += replacement.Value;
                }
            }

            if(output.Equals("")) output = input.ToString();
        }

        static void ParseConfiguration(string file, out int rangeStart, out int rangeEnd, Dictionary<Int32, String> replacemenDictionary)
        {
            rangeStart = 1;
            rangeEnd = 100;

            int currentLine = 0;
            foreach (string line in File.ReadLines(file))
            {
                if (currentLine == 0)
                {
                    GetRange(line, out rangeStart, out rangeEnd);
                }
                else if(!String.IsNullOrEmpty(line))
                {
                    GetReplacement(line, replacemenDictionary);
                }

                currentLine++;
            }
        }

        static void GetRange(string line, out int start, out int end)
        {
            string[] range = line.Split('-');

            if (!Int32.TryParse(range[0], out start))
            {
                Console.WriteLine("Failed to parse start range: " + range[0] + ". Initializing with default value of " + start + ".\n");
            }

            if (!Int32.TryParse(range[1], out end))
            {
                Console.WriteLine("Failed to parse end range: " + range[1] + ". Initializing with default value of " + end + ".\n");
            }
        }

        static void GetReplacement(string line, Dictionary<Int32, String> replacemenDictionary)
        {
            int replaceValue;
            string replaceWord;

            string[] replacement = line.Split(':');

            if (!Int32.TryParse(replacement[0], out replaceValue))
            {
                Console.WriteLine("Failed to parse replace value: " + replacement[0] + ". Skipping entry.\n");
                return;
            }

            replaceWord = replacement[1];

            replacemenDictionary.Add(replaceValue, replaceWord);
        }
    }
}
