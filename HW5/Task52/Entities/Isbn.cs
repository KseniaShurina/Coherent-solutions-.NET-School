using System.Text.RegularExpressions;
using Task52.Validators;

namespace Task52.Entities
{
    public class Isbn
    {
        private string _isbn;

        public string IsbnNumber
        {
            get => _isbn;
            set
            {
                if (EntityValidator.AcceptIsbn(this)) throw new ArgumentException("ISBN is not valid");
                _isbn = value;
            }
        }

        public Isbn(string isbn)
        {
            if (!Regex.IsMatch(isbn, @"\d{3}-?\d{1}-?\d{2}-?\d{6}") && !Regex.IsMatch(isbn, @"^\d{12}$"))
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

            int rest = 10 - sum % 10;

            if (rest == 10)
            {
                return 0;
            }
            return rest;
        }

        public override string ToString()
        {
            return IsbnConverter.ConvertIsbnToCommonPattern(IsbnNumber);
        }
    }
}
