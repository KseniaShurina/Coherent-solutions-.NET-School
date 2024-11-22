using Task6.DAL.Entities;
using Task6.DAL.JSONEntities;

namespace Task6.DAL.Interfaces;

public interface IJSONRepository
{
    public void Save(Catalog catalog);

    public List<JSONAuthor> Get();
}