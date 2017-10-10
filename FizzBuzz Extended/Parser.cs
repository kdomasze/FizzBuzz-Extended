using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FizzBuzz_Extended
{
    sealed class Parser
    {
        public static Configuration Parse(string file)
        {
            Range range = new Range(1, 100);

            // default configuration handling
            if (!File.Exists(file))
            {
                Console.WriteLine("File " + file + " does not exist. Initializing with default values.");

                Configuration configuration = new Configuration(range);

                configuration.AddReplacement(GetReplacement("3:Fizz"));
                configuration.AddReplacement(GetReplacement("5:Buzz"));

                return configuration;
            }

            // generate configuration
            Dictionary<Int32, String> replacementDictionary = new Dictionary<int, string>();
            int currentLine = 0;

            foreach (string line in File.ReadLines(file))
            {
                
                if (currentLine == 0) // line 0 is range
                {
                    range = GetRange(line);
                }
                else if (!String.IsNullOrEmpty(line)) // all other non-empty lines are replacements
                {
                    var replacement = GetReplacement(line);
                    replacementDictionary.Add(replacement.Key, replacement.Value);
                }

                currentLine++;
            }
            return new Configuration(range, replacementDictionary);
        }

        static Range GetRange(string line)
        {
            int start;
            int end;

            string[] range = line.Split('-');

            if (!Int32.TryParse(range[0], out start))
            {
                Console.WriteLine("Failed to parse start range: " + range[0] + ". Initializing with default value of " + start + ".\n");
            }

            if (!Int32.TryParse(range[1], out end))
            {
                Console.WriteLine("Failed to parse end range: " + range[1] + ". Initializing with default value of " + end + ".\n");
            }

            return new Range(start, end);
        }

        static KeyValuePair<Int32, String> GetReplacement(string line)
        {
            string[] replacement = line.Split(':');
            
            int replaceValue;
            if (!Int32.TryParse(replacement[0], out replaceValue))
            {
                Console.WriteLine("Failed to parse replace value: " + replacement[0] + ". Skipping entry.\n");
                return new KeyValuePair<int, string>(-1, null); // config will handle null values by discarding them
            }

            string replaceWord = replacement[1];

            return new KeyValuePair<int, string>(replaceValue, replaceWord);
        }
    }
}
