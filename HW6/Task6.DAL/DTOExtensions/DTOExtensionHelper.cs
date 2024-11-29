using Task6.DAL.DTO;
using Task6.DAL.Entities;

namespace Task6.DAL.DTOExtensions
{
    internal static class DTOExtensionHelper
    {
        public static DTOBook MapToDTOBook(this Book book)
        {
            return new DTOBook
            {
                Title = book.Title,
                Isbn = book.Isbn.IsbnNumber,
                PublicationDate = book.PublicationDate,
                // To avoid System.StackOverflowException
                Authors = book.Authors!.Select(a => new DTOAuthor
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName,
                    DateOfBirthday = a.DateOfBirthday
                }).ToList(),
            };
        }

        public static DTOAuthor MapToDTOAuthor(this Author author)
        {
            return new DTOAuthor
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirthday = author.DateOfBirthday,
            };
        }

        public static DTOCatalog MapToDTOCatalog(this Catalog catalog)
        {
            DTOCatalog dtoCatalog = new DTOCatalog();
            var list = catalog.GetAllBooks();
            foreach (var book in list)
            {
                dtoCatalog.Books.Add(book.MapToDTOBook());
            }
            return dtoCatalog;
        }
    }
}
