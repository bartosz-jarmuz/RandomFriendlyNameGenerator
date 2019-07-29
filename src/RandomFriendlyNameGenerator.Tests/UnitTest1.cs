using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using RandomFriendlyNameGenerator;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        

        [Test]
        public void TestNameUniqueness([Values(1_000, 10_000, 100_000, 1_000_000, 10_000_000, 100_000_000)] int reps)
        {
            for (int j = 0;j < 3; j++)
            {

                List<string> names = new List<string>();
                Stopwatch sw = Stopwatch.StartNew();
                Generator generator = new RandomFriendlyNameGenerator.Generator();

                for (int i = 0; i < reps; i++)
                {
                    names.Add(generator.GetName());
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
        
        [Test]
            public void TestRandomnessProviders()
            {
                for (int j = 0; j < 10; j++)
                {
                    Random random = new Random();
                    List<int> listFromRandomClass = new List<int>();
                    int maxVal = 999999999;

                    Stopwatch sw = Stopwatch.StartNew();
                    for (int i = 0; i < 1_000_000; i++)
                    {
                        listFromRandomClass.Add(random.Next(maxVal));
                    }

                    sw.Stop();
                    List<int> duplicates = listFromRandomClass.GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(y => y.Key).ToList();

                    Console.WriteLine("Random - Duplicates: " + duplicates.Count);
                    Console.WriteLine("Random - Elapsed: " + sw.ElapsedMilliseconds);

                    StrongRandomNumberGenerator otherRandom = new StrongRandomNumberGenerator();
                    List<int> listFromOtherClass = new List<int>();
                    sw = Stopwatch.StartNew();
                    for (int i = 0; i < 1_000_000; i++)
                    {
                        listFromOtherClass.Add(otherRandom.GetRandomIntStartAtZero(maxVal));
                    }

                    sw.Stop();
                    duplicates = listFromOtherClass.GroupBy(x => x)
                        .Where(g => g.Count() > 1)
                        .Select(y => y.Key).ToList();
                    Console.WriteLine("Other - Duplicates: " + duplicates.Count);
                    Console.WriteLine("Other - Elapsed: " + sw.ElapsedMilliseconds);
                }
            }
    }
}