using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        

        [Test]
        public void Test1()
        {
            var names = new List<string>();
            var generator = new RandomFriendlyNameGenerator.Generator();

            for (int i = 0; i < 1000; i++)
            {
                names.Add(generator.GetName());
            }
            Assert.AreEqual(names.Count, names.Distinct().Count());

        }
    }
}