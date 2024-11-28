using Task6.DAL.Entities;
using Task6.DAL.JSONEntities;

namespace Task6.DAL.Extensions.JSON
{
    public static class JSONBookExtension
    {
        public static JSONBook MapToJsonBook(this Book book)
        {
            var json = new JSONBook
            {
                Title = book.Title,
                Isbn = book.Isbn.IsbnNumber,
                PublicationDate = book.PublicationDate,
                // To avoid System.StackOverflowException
                Authors = book.Authors!.Select(a => new JSONAuthor
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    DateOfBirthday = a.DateOfBirthday
                }).ToList(),
            };
            return json;
        }
    }
}
