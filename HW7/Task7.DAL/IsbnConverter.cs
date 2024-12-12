using System.Text.RegularExpressions;

namespace Task7.DAL
{
    internal static class IsbnConverter
    {
        private const string RegexPattern = @"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}";

        internal static string ConvertIsbnToCommonPattern(string isbn)
        {
            return $"{isbn.Substring(0, 3)}-{isbn.Substring(3, 1)}-{isbn.Substring(4, 2)}-{isbn.Substring(6, 6)}-{isbn.Substring(12, 1)}";
        }

        internal static string ConvertIsbnToSimplifiedPattern(string isbn)
        {
            if (string.IsNullOrEmpty(isbn))
            {
                throw new ArgumentException();
            }
            return Regex.Replace(isbn, @"-", "");
        }
    }
}
