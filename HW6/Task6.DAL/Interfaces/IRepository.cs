using Task6.DAL.Entities;

namespace Task6.DAL.Interfaces;

public interface IRepository
{
    public void Save(Catalog catalog);

    public Catalog? Get();
}