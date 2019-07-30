using System;

namespace RandomFriendlyNameGenerator.RandomIndex
{
    public class RandomBasedGenerator : IGenerateRandomIndex
    {
        readonly Random rnd = new Random();
        public int Get(int lowerThan)
        {
            return this.rnd.Next(0,lowerThan);
        }
    }

}