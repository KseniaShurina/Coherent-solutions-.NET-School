namespace Task52
{
    internal static class IsbnConverter
    {
        internal static string ConvertIsbnToCommonPattern(string isbn)
        {
            return $"{isbn.Substring(0, 3)}-{isbn.Substring(3, 1)}-{isbn.Substring(4, 2)}-{isbn.Substring(6, 6)}-{isbn.Substring(12, 1)}";
        }
    }
}
