using Task7.DAL.Entities;

namespace Task7.DAL.Interfaces;

public interface IRepository
{
    public void Save(Catalog catalog);

    public Catalog? Get();
}