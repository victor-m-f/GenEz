using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Distrib.Helper.Extensions
{
    /// <summary>
    /// Contains help methods that take <see cref="string"/> as a parameter and manipulate it to obtain a result.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an appropriate version for soft comparisons.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to be transformed.</param>
        /// <returns>A uppercase <see cref = "string" /> that does not contain traces of culture.</returns>
        public static string ToNeutral(this string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return text;
            }

            var formD = text.Normalize(NormalizationForm.FormD);
            var sb = new StringBuilder();

            foreach (var ch in from ch in formD let uc = CharUnicodeInfo.GetUnicodeCategory(ch) where uc != UnicodeCategory.NonSpacingMark select ch)
            {
                _ = sb.Append(ch);
            }

            return sb.ToString().ToUpper().Normalize(NormalizationForm.FormC);
        }

        public static string FirstToLower(this string text) =>
            string.IsNullOrEmpty(text) ?
                text :
                char.ToLowerInvariant(text[0]) + text.Substring(1);

        /// <summary>
        /// Converts the first character to its uppercase equivalent, even if there are more than one word in the input.
        /// </summary>
        /// <param name="input">The <see cref="string"/> to be transformed.</param>
        /// <returns>The input with the first character converted to its uppercase equivalent.</returns>
        public static string OnlyFirstToUpper(this string input) =>
            string.IsNullOrEmpty(input) ?
                input :
                char.ToUpperInvariant(input[0]) + input.Substring(1).ToLower();

        public static bool ToBool(this string text)
        {
            if (text == null)
            {
                throw new InvalidOperationException("Null is not convertible to bool");
            }

            return text.ToLower() switch
            {
                "true" => true,
                "false" => false,
                "0" => false,
                "1" => true,
                _ => throw new InvalidOperationException($"\"{text}\" is not convertible to bool")
            };
        }

        public static string Truncate(this string text, int maxLength, string ending = "") =>
            string.IsNullOrEmpty(text) ?
                text :
                text.Length <= maxLength ?
                    text :
                    text.Substring(0, maxLength - ending.Length) + ending;

        public static string SeparateCamelCase(this string input) =>
            new string(input.Take(1).Concat(// No space before initial cap
                InsertSpacesBeforeCaps(input.Skip(1)))
            .ToArray());

        public static string RemoveText(this string input, string stringToRemove)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            var startIndex = input.IndexOf(stringToRemove, StringComparison.InvariantCulture);

            return startIndex == -1 ? input : input.Remove(startIndex, stringToRemove.Length);
        }

        public static string ToTitleCase(this string input)
        {
            var strings = input.Split(" ");
            return string.Join(" ", strings.Select(x => x.OnlyFirstToUpper()));
        }

        private static IEnumerable<char> InsertSpacesBeforeCaps(IEnumerable<char> input)
        {
            foreach (var c in input)
            {
                if (char.IsUpper(c))
                {
                    yield return ' ';
                }

                yield return c;
            }
        }
    }
}
