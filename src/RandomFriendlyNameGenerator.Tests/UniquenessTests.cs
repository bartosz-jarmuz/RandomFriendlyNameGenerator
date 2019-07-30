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
        private void RunTest(int reps, Func<string> getName, decimal acceptableDuplicatesPercentage)
        {
            for (int j = 0; j < 3; j++)
            {

                List<string> names = new List<string>();
                Stopwatch sw = Stopwatch.StartNew();

                for (int i = 0; i < reps; i++)
                {
                    names.Add(getName());
                }

                sw.Stop();
                var duplicates = names.GroupBy(x => x)
                    .Where(g => g.Count() > 1)
                    .Select(y => y.Key + " " + y.Count())
                    .ToList();

                var duplicatesPercentage = (decimal)duplicates.Count / names.Count * 100;

                Console.WriteLine(
                    $"Duplicates: {duplicates.Count}. Duplicates percentage: {(decimal)duplicates.Count / names.Count * 100}. Elapsed: {sw.ElapsedMilliseconds}");


                if (j == 2)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine(names[i]);
                    }
                }
                Assert.IsTrue(duplicatesPercentage < acceptableDuplicatesPercentage);

            }
        }

        [Test]
        public void TestPersonNameUniqueness([Values(1_000, 10_000, 100_000, 1_000_000)] int reps)
        {
            this.RunTest(reps, ()=>NameGenerator.PersonNames.Get(), 0.2M);
        }

        [Test]
        public void  TestIdentifierUniqueness([Values(1_000, 10_000, 100_000, 1_000_000)] int reps)
        {
            this.RunTest(reps, () => NameGenerator.Identifiers.Get(IdentifierComponents.Noun | IdentifierComponents.Adjective| IdentifierComponents.FirstName),1);
        }

    }
}