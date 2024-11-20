using Task6.DAL.Entities;
using Task6.DAL.XMLEntities;

namespace Task6.BL.Extensions.Entities
{
    internal static class AuthorExtension
    {
        internal static Author MapToAuthor(this XMLAuthor xmlAuthor)
        {
            return new Author(xmlAuthor.FirstName, xmlAuthor.LastName, xmlAuthor.DateOfBirthday);
        }
    }
}
