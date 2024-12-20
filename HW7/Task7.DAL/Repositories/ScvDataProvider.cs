using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task7.DAL.DTO;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;

namespace Task7.DAL.Repositories;

public class ScvDataProvider
{
    public ScvDataProvider() { }

    private readonly IRepository<string> _scvRepository = new ScvRepository<string>();

    public async Task<IEnumerable<Book>> GetBooks()
    {
        var stringsWithBooks = await _scvRepository.GetAsync();
        var headers = stringsWithBooks.First().Split(',').Take(7);

        List<string> parsedRow = null;

        foreach (var line in stringsWithBooks.Skip(1))
        {
            parsedRow = CsvConverter.ConvertCsvRow(line);
        }

        var authorName = parsedRow[0].Split(',');

        var listOfFormats = CsvConverter.ConvertToListOfFormats(parsedRow[1]);

        var identifier = CsvConverter.ConvertIdentifier(parsedRow[2]);

        throw new NotImplementedException();
    }
}

