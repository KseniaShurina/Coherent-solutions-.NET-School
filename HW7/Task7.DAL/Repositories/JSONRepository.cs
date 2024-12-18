using System.Text.Json;
using Task7.DAL.Interfaces;

namespace Task7.DAL.Repositories;

public class JsonRepository<T> : IRepository<T>
{
    private const string PathToDirectory = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\JSON files";
    private const string PathToFile = $@"{PathToDirectory}\books.json";

    public JsonRepository() { }

    /// <summary>
    /// Saves the books to a directory as JSON files. 
    /// </summary>
    /// <param name="books">The books to save.</param>
    /// <exception cref="NullReferenceException">Thrown if catalog is null</exception>
    public async Task SaveAsync(IEnumerable<T> books)
    {
        if (books == null)
        {
            throw new NullReferenceException(nameof(books));
        }

        // Create directory if it doesn't exist
        Directory.CreateDirectory(PathToDirectory);

        //var listOfDtoBooks = books.Select.Of

        // A stream is created to write to a file
        await using (var stream = new FileStream(PathToFile, FileMode.Create))
        {
            // Serialize the books into JSON format
            // WriteIndented = true makes the JSON structure more readable
            await JsonSerializer.SerializeAsync(stream, books, new JsonSerializerOptions { WriteIndented = true });
        }
    }

    public async Task<IEnumerable<T>> GetAsync()
    {
        if (!Directory.Exists(PathToDirectory))
        {
            return null;
        }
        // Opens a file as a stream
        await using var stream = File.OpenRead(PathToFile);
        // Asynchronous deserialization
        var dtoBooks = await JsonSerializer.DeserializeAsync<List<T>>(stream);

        return dtoBooks as IEnumerable<T> ?? [];
    }
}
