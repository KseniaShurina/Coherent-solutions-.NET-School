using System.Text.RegularExpressions;
using Task6.DAL.Entities;

namespace Task6.DAL.Validators
{
    public class EntityValidator
    {
        public static bool AcceptBook(Book? book)
        {
            if (book == null) return false;

            if (!AcceptIsbn(book.Isbn)) return false;

            if (book.Authors != null)
            {
                // Check that each author has FirstName and LastName filled in
                if (book.Authors.Any(a => IsPropNullOrEmpty(a.FirstName) || IsPropNullOrEmpty(a.LastName)))
                {
                    return false;
                }
            }

            return true;
        }

        public static bool AcceptIsbn(Isbn? isbn)
        {
            if (isbn == null) return false;
            if (IsPropNullOrEmpty(isbn.IsbnNumber)) return false;

            if (!Regex.IsMatch(isbn.IsbnNumber, @"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}"))
            {
                return false;
            }

            return true;
        }

        public static bool AcceptAuthor(string? author)
        {
            if (author == null) return false;

            if (IsPropNullOrEmpty(author))
            {
                return false;
            }

            return true;
        }

        private static bool IsPropNullOrEmpty(string prop)
        {
            return string.IsNullOrEmpty(prop);
        }
    }
}
