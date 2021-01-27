using System;

namespace Distrib.Helper.Helpers
{
    /// <summary>
    /// Contains help methods, which do not take strings as a parameter, but generate them as result.
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Generates a random string containing letters and/or numbers.
        /// </summary>
        /// <param name="length">The exact length for the generated string.</param>
        /// <returns>A random string.</returns>
        public static string GenerateRandomString(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            const string numbers = "0123456789";

            var stringChars = new char[length];
            var random = new Random();

            for (var i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = i % 2 == 0 ?
                    chars[random.Next(chars.Length)] :
                    numbers[random.Next(numbers.Length)];
            }

            return new string(stringChars);
        }
    }
}
