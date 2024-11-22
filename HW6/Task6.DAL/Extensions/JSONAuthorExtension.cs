using Task6.DAL.Entities;
using Task6.DAL.JSONEntities;

namespace Task6.DAL.Extensions
{
    public static class JsonAuthorExtension
    {
        public static JSONAuthor MapToJsonAuthor(this Author author)
        {
            return new JSONAuthor
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                DateOfBirthday = author.DateOfBirthday,
            };
        }
    }
}
