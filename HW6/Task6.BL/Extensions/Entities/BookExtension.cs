using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.BL.Extensions.Entities
{
    internal static class BookExtension
    {
        internal static Book MapToBook(this XMLBook xmlBook)
        {
            Book book = new Book(
                xmlBook.Title,
                new Isbn(xmlBook.Isbn),
                xmlBook.PublicationDate,
                xmlBook.Authors?.Select(a => a.MapToAuthor()));
            
            return book;
        }
    }
}
