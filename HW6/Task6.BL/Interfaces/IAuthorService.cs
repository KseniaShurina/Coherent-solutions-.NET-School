using Task6.DAL.Entities;

namespace Task6.BL.Interfaces
{
    internal interface IAuthorService
    {
        public void AddBook(Author author, Book book);
    }
}
