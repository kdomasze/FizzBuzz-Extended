using System;
using System.Collections.Generic;
using FizzBuzz_Extended;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Parser_Unit_Tests
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void ValidReplacementsTest()
        {
            var actual = Parser.Parse("TestFiles/ValidReplacements.txt");
            Configuration expected = new Configuration(new Range(11, 52));
            expected.AddReplacement(new KeyValuePair<int, string>(3, "Fizz"));
            expected.AddReplacement(new KeyValuePair<int, string>(5, "Buzz"));
            
            Assert.AreEqual(expected.Range.StartRange, actual.Range.StartRange);
            Assert.AreEqual(expected.Range.EndRange, actual.Range.EndRange);

            Assert.AreEqual(expected.Replacements.Count, actual.Replacements.Count);
            Assert.AreEqual(expected.Replacements[3], actual.Replacements[3]);
            Assert.AreEqual(expected.Replacements[5], actual.Replacements[5]);
        }

        [TestMethod]
        public void InvalidRangeTest()
        {
            var actual = Parser.Parse("TestFiles/InvalidRange.txt");
            Configuration expected = new Configuration(new Range(11, 52));
            expected.AddReplacement(new KeyValuePair<int, string>(3, "Fizz"));
            expected.AddReplacement(new KeyValuePair<int, string>(5, "Buzz"));

            var expectedRange = new Range(1, 100);

            Assert.AreNotEqual(expected.Range.StartRange, actual.Range.StartRange);
            Assert.AreNotEqual(expected.Range.EndRange, actual.Range.EndRange);

            Assert.AreEqual(expectedRange.StartRange, actual.Range.StartRange);
            Assert.AreEqual(expectedRange.EndRange, actual.Range.EndRange);

            Assert.AreEqual(expected.Replacements.Count, actual.Replacements.Count);
            Assert.AreEqual(expected.Replacements[3], actual.Replacements[3]);
            Assert.AreEqual(expected.Replacements[5], actual.Replacements[5]);
        }

        [TestMethod]
        public void InvalidReplacementsTest()
        {
            var actual = Parser.Parse("TestFiles/InvalidReplacement.txt");
            Configuration expected = new Configuration(new Range(11, 52));
            expected.AddReplacement(new KeyValuePair<int, string>(10, "Correct"));

            Assert.AreEqual(expected.Range.StartRange, actual.Range.StartRange);
            Assert.AreEqual(expected.Range.EndRange, actual.Range.EndRange);

            Assert.AreEqual(expected.Replacements.Count, actual.Replacements.Count);
            Assert.AreEqual(expected.Replacements[10], actual.Replacements[10]);
        }

        [TestMethod]
        public void InvalidFormatTest()
        {
            var actual = Parser.Parse("TestFiles/InvalidFormat.txt");
            Configuration expected = new Configuration(new Range(1, 100));
            expected.AddReplacement(new KeyValuePair<int, string>(3, "Fizz"));
            expected.AddReplacement(new KeyValuePair<int, string>(5, "Buzz"));

            Assert.AreEqual(expected.Range.StartRange, actual.Range.StartRange);
            Assert.AreEqual(expected.Range.EndRange, actual.Range.EndRange);

            Assert.AreEqual(expected.Replacements.Count, actual.Replacements.Count);
            Assert.AreEqual(expected.Replacements[3], actual.Replacements[3]);
            Assert.AreEqual(expected.Replacements[5], actual.Replacements[5]);
        }
    }

    [TestClass]
    public class ConfigurationTest
    {
        [TestMethod]
        public void AddReplacementTest()
        {
            KeyValuePair<Int32, String> validInsert = new KeyValuePair<int, string>(1, "Good");
            KeyValuePair<Int32, String> invalidInsert = new KeyValuePair<int, string>(-1, null);

            var configuration = new Configuration(new Range(1, 100));
            configuration.AddReplacement(validInsert);
            configuration.AddReplacement(invalidInsert);

            Assert.AreEqual(configuration.Replacements.Count, 1);
            Assert.AreEqual(configuration.Replacements[1], "Good");
        }
    }
}
