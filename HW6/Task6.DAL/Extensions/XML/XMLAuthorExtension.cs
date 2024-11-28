using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.DAL.Extensions.XML
{
    public static class XMLAuthorExtension
    {
        public static XMLAuthor MapToXMLAuthor(this Author author)
        {
            return new XMLAuthor
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirthday = author.DateOfBirthday
            };
        }
    }
}
