using Task7.DAL.Entities;

namespace Task7.DAL.Interfaces;

public interface IRepository
{
    public Task Save(Library library);

    public Task<List<Book>> Get();
}