using Task6.BL.Interfaces;
using Task6.DAL.Entities;
using Task6.DAL.Validators;

namespace Task6.BL.Services
{
    public class AuthorService : IAuthorService
    {
        public void AddBook(Author author, Book book)
        {
            if (EntityValidator.AcceptBook(book))
            {
                author.Books!.Add(book);
            }
        }
    }
}
