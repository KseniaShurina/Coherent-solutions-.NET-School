using System.Text.Json;
using Task7.DAL.DTO;
using Task7.DAL.DtoExtensionHelper;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.Validators;

namespace Task7.DAL.Repositories;

public class JsonRepository : IRepository
{
    private const string Path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\JSON files";
    public JsonRepository() { }

    /// <summary>
    /// Saves the catalog to a directory as JSON files. 
    /// Each author's books are serialized into a separate JSON file named after the author's first and last name.
    /// </summary>
    /// <param name="catalog">The catalog to save. Contains books with associated authors.</param>
    /// <exception cref="NullReferenceException">Thrown if catalog is null</exception>
    public async Task Save(Catalog catalog)
    {
        if (catalog == null)
        {
            throw new NullReferenceException(nameof(catalog));
        }

        // Create directory if it doesn't exist
        Directory.CreateDirectory(Path);

        foreach (var author in catalog.GetAllBooks().SelectMany(book => book.Authors))
        {
            string fileName = $"{author.FirstName} {author.LastName}.json";
            string filePath = $@"{Path}\{fileName}";

            var booksByAuthor = catalog.GetBooksByAuthor(author).Select(b => b.MapToDtoBook());
            // A stream is created to write to a file
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                // Serialize the books associated with the author into JSON format
                // WriteIndented = true makes the JSON structure more readable
                await JsonSerializer.SerializeAsync(stream, booksByAuthor, new JsonSerializerOptions { WriteIndented = true });
            }
        }
    }

    public async Task<Catalog> Get()
    {
        List<DtoBook> books = new List<DtoBook>();

        var directory = new DirectoryInfo($@"{Path}");
        if (directory.Exists)
        {
            foreach (var file in directory.GetFiles("*.json"))
            {
                // Read file
                var json = await File.ReadAllTextAsync(file.FullName);
                // Get books by author
                var booksByAuthor = JsonSerializer.Deserialize<List<DtoBook>>(json);
                //var booksByAuthor = await JsonSerializer.DeserializeAsync<List<DtoBook>>(json);

                // Foreach books and check if the catalog already contains a book by ISBN
                if (booksByAuthor != null)
                {
                    foreach (var book in booksByAuthor)
                    {
                        if (books.All(b => b.Identifiers != book.Identifiers))
                        {
                            books.Add(book);
                        }
                    }
                }
            }
        }

        Catalog catalog = new Catalog();

        foreach (var book in books)
        {
            if (EntityValidator.IsIsbn(book.Identifiers[0]))
            {
                var restoredPaperBook = new PaperBook(
                    book.Title,
                    new HashSet<Author>(book.Authors.Select(a =>
                        new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                    new List<string>(book.Identifiers),
                    //TODO: How to deal with specific properties if I avoid them?
                    null);

                if (!EntityValidator.AcceptBook(restoredPaperBook))
                {
                    throw new ArgumentException("An error occurred while converting the book");
                }

                catalog.AddBook(restoredPaperBook.Isbns[0], restoredPaperBook);
            }
            else
            {
                var restoredEBook = new EBook(
                    book.Title,
                    new HashSet<Author>(book.Authors.Select(a =>
                        new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                    book.Identifiers[0]);

                if (!EntityValidator.AcceptBook(restoredEBook))
                {
                    throw new ArgumentException("An error occurred while converting the book");
                }

                catalog.AddBook(restoredEBook.Identifier, restoredEBook);
            }
        }
        return catalog;
    }

    //TODO: Create method to create books
}
