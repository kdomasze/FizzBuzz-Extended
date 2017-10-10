using System;
using System.Collections.Generic;

namespace FizzBuzz_Extended
{
    public struct Configuration
    {
        private readonly Range _range;
        private readonly Dictionary<Int32, String> _replacements;

        public Range Range => _range;
        public Dictionary<Int32, String> Replacements => _replacements;

        public Configuration(Range range)
        {
            _range = range;
            _replacements = new Dictionary<Int32, String>();
        }

        public Configuration(Range range, Dictionary<Int32, String> replacements)
        {
            _range = range;
            _replacements = replacements;
        }

        public void AddReplacement(KeyValuePair<Int32, String> replacementKeyValuePair)
        {
            if (replacementKeyValuePair.Value != null)
            {
                _replacements.Add(replacementKeyValuePair.Key, replacementKeyValuePair.Value);
            }
        }
    }

    public struct Range
    {
        private readonly int _startRange;
        private readonly int _endRange;

        public int StartRange => _startRange;
        public int EndRange => _endRange;

        public Range(int start, int end)
        {
            _startRange = start;
            _endRange = end;
        }
    }
}
