using Task7.DAL.Entities;

namespace Task7.BL.Interfaces;

public interface ILibraryAbstractFactory
{
    public Library CreateLibrary(Catalog catalog);
}