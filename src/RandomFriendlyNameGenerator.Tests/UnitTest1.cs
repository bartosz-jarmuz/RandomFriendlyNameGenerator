using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using NUnit.Framework;

namespace RandomFriendlyNameGenerator.Tests
{

    [TestFixture]
    public class Tests
    {
        

        [Test]
        public void TestNameUniqueness([Values(1_000, 10_000, 100_000, 1_000_000)] int reps)
        {
            for (int j = 0;j < 3; j++)
            {

                List<string> names = new List<string>();
                Stopwatch sw = Stopwatch.StartNew();
                Generator generator = new RandomFriendlyNameGenerator.Generator();

                for (int i = 0; i < reps; i++)
                {
                    names.Add(generator.GetHumanName());
                }

                sw.Stop();
                var duplicates = names.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key + " " + y.Count())
                    .ToList();
                //Assert.AreEqual(0, duplicates.Count);

                Console.WriteLine("Duplicates: " + duplicates.Count);
                Console.WriteLine("Duplicates percentage: " + (decimal)duplicates.Count / names.Count * 100);
                Console.WriteLine("Elapsed: " + sw.ElapsedMilliseconds);
            }

        }
       
    }
}