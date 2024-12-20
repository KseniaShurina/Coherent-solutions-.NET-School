using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using Task7.DAL.Interfaces;

namespace Task7.DAL.Repositories;

internal class ScvRepository<T> : IRepository<T>
{
    private const string PathToFile =
        @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\books_info.csv";
    public ScvRepository() { }

    public Task SaveAsync(IEnumerable<T> items)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<T>?> GetAsync()
    {
        var stream = await File.ReadAllLinesAsync(PathToFile);
        return stream as IEnumerable<T>;
    }
}

