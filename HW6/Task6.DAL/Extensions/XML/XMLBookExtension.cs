using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.DAL.Extensions.XML
{
    public static class XMLBookExtension
    {
        public static XMLBook MapToXMLBook(this Book book)
        {
            return new XMLBook
            {
                Title = book.Title,
                Isbn = book.Isbn.IsbnNumber,
                PublicationDate = book.PublicationDate,
                Authors = book.Authors?.Select(a => a.MapToXMLAuthor()).ToList(),
            };
        }
    }
}
