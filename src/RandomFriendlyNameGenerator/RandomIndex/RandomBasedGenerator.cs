using System;
using System.Security.Cryptography;

namespace RandomFriendlyNameGenerator
{
    public class RandomBasedGenerator : IGenerateRandomIndex
    {
        readonly Random rnd = new Random();
        public int Get(int lowerThan)
        {
            return this.rnd.Next(lowerThan);
        }
    }


    internal class RandomNumber : IGenerateRandomIndex
    {
        private static Random r = new Random();
        private static object l = new object();
        private static Random globalRandom = new Random();
        [ThreadStatic]
        private static Random localRandom;
      
     public int Get(int max)
        {
            Random random = RandomNumber.localRandom;
            if (random == null)
            {
                int seed;
                lock (RandomNumber.globalRandom)
                {
                    seed = RandomNumber.globalRandom.Next();
                }
                random = (RandomNumber.localRandom = new Random(seed));
            }
            return random.Next(0, max);
        }
    }

    public class CryptographyBasedGenerator : IGenerateRandomIndex
    {
        
        public int Get(int lowerThan)
        {
            using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
            {
                byte[] rno = new byte[5];
                rg.GetBytes(rno);
                uint randomvalue = BitConverter.ToUInt32(rno, 0);
                var returnValue= (int)(Math.Round((randomvalue * (double)(lowerThan - 1)) / uint.MaxValue));

                return returnValue;
            }
        }
    }
}