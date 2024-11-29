using Task6.DAL.DTO;
using Task6.DAL.Entities;

namespace Task6.BL.EntityExtensions
{
    internal static class EntityExtensionHelper
    {
        public static Book MapEntityToBook(this DTOBook book)
        {
            return new Book
            (
                book.Title, new Isbn(book.Isbn),
                book.PublicationDate,
                
                book.Authors!.Select(a => new Author
                (
                    a.FirstName,
                    a.LastName,
                    a.DateOfBirthday
                )
            ));
        }

        public static Author MapToEntityAuthor(this DTOAuthor author)
        {
            return new Author(author.FirstName, author.LastName, author.DateOfBirthday);
        }

        public static Catalog MapToEntityCatalog(this DTOCatalog dtoCatalog)
        {
            Catalog catalog = new Catalog();
           
            foreach (var book in dtoCatalog.Books)
            {
                catalog.AddBook(book.MapEntityToBook());
            }
            return catalog;
        }
    }
}
