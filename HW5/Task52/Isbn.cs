using System.Text.RegularExpressions;

namespace Task52
{
    public class Isbn
    {
        private string _isbn;

        public string IsbnNumber
        {
            get => _isbn;
            set
            {
                if (!IsValidIsbn(value)) throw new ArgumentException("ISBN is not valid");
                _isbn = value;
            }
        }

        private const string Pattern = @"\d{3}-?\d{1}-?\d{4}-?\d{4}";

        public bool IsValidIsbn(string isbn)
        {
            if (!Regex.IsMatch(isbn, @"\d{3}-?\d{1}-?\d{4}-?\d{4}") || isbn.Length < 13 || isbn.Length > 13)
            {
                return false;
            }

            return true;
        }

        public Isbn(string isbn)
        {
            if (!Regex.IsMatch(isbn, Pattern) || isbn.Length < 12 || isbn.Length > 12)
            {
                throw new ArgumentException(nameof(isbn));
            }

            int[] arr = new int[12];
            for (int i = 0; i < isbn.Length; i++)
            {
                arr[i] = int.Parse(isbn[i].ToString());
            }

            var controlNumber = ControlNumber(arr);

            IsbnNumber = isbn + controlNumber;
        }

        int ControlNumber(int[] array)
        {
            int sum = 0;

            for (int i = 0; i < array.Length; i++)
            {
                // Even position
                if (i % 2 != 0)
                {
                    sum += array[i] * 3;
                }
                // Odd position
                else
                {
                    sum += array[i];
                }
            }

            int rest = 10 - (sum % 10);

            if (rest == 10)
            {
                return 0;
            }
            return rest;
        }

        public override string ToString()
        {
            return IsbnNumber;
        }
    }
}
