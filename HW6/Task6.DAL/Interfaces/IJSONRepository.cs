using Task6.DAL.Entities;

namespace Task6.DAL.Interfaces;

public interface IJSONRepository
{
    public void Save(Catalog catalog);

    public Catalog Get();
}