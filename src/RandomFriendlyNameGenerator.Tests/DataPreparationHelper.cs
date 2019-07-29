using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace RandomFriendlyNameGenerator.Tests
{
#if !DEBUG
    [Ignore("It's not really a test. It's a utility for data preparation")]
#endif
    [TestFixture]
    public class DataPreparationHelper
    {
        [Test]
        public void SanitizeInput()
        {

            var input = MaleFirstNames.Values;

            input = this.Sanitize(input);

            File.WriteAllLines("output.txt", input);

            Process.Start("notepad.exe", "output.txt");
        }

        [Test]
        public void SanitizeInputFromText()
        {

            var input = File.ReadAllLines(@"C:\Users\bjarmuz\Desktop\input.txt").ToList();

            input = this.Sanitize(input);

            File.WriteAllLines("output.txt", input);

            Process.Start("notepad.exe", "output.txt");
        }

        private List<string> Sanitize(List<string> input)
        {
            Console.WriteLine($"Initial count: {input.Count}");
            input = input.Select(this.EnsureShortPascalCaseString).ToList();

            input = input.Distinct().ToList();
            Console.WriteLine($"Unique count: {input.Count}");

            //input = input.Where(x => !Adjectives.Values.Contains(x)).ToList();
            //input = input.Where(x => !MaleFirstNames.Values.Contains(x)).ToList();
            //input = input.Where(x => !FemaleFirstNames.Values.Contains(x)).ToList();
            //input = input.Where(x => !Animals.Values.Contains(x)).ToList();

            input = input.OrderByDescending(x => x.Length).ToList();
            input.Sort();

           return  input.Where(x=> !string.IsNullOrEmpty(x)).Select(x => $"\"{x}\", ").ToList();

        }

        private string EnsureShortPascalCaseString(string input)
        {
            var parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length > 2)
            {
                return ""; //we don't want too long names (e.g. 'MountainGoat' is fine, but 'Cavalier King Charles Spaniel' is too much:))
            }
            var result = string.Join("", parts.Select(x => RemoveSpecialCharacters((char.ToUpperInvariant(x[0]) + x.Substring(1)))));
            if (result.Length > 13)
            {
                return "";
            }

            return result;
        }

        public string RemoveSpecialCharacters(string str)
        {
            return str;
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z'))
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


    }
}