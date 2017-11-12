using System;
using System.Linq;

namespace sel_12.Utils
{
    public static class RandomUtils
    {
        private static readonly Random Random = new Random();

        private const string UppercaseChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string LowercaseChars = "abcdefghijklmnopqrstuvwhxyz";

        private const string Numbers = "1234567890";

        public static string RandomEnglishWord(int length)
        {
            return RandomWord(UppercaseChars, length);
        }

        public static string RandomNumericWord(int length)
        {
            return RandomWord(Numbers, length);
        }

        public static string RandomEmail()
        {
            var userName = RandomEnglishWord(10);
            var randomDomain = RandomEnglishWord(5) + ".com";
            return userName + '@' + randomDomain;
        }

        private static string RandomWord(string chars, int length)
        {
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Random.Next(s.Length)])
                .ToArray());
        }
    }
}
