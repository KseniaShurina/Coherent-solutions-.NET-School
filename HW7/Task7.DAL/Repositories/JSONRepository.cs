using System.Text.Json;
using Task7.DAL.DTO;
using Task7.DAL.DtoExtensions;
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
    public async Task Save(Library library)
    {
        if (library == null)
        {
            throw new NullReferenceException(nameof(library));
        }

        // Create directory if it doesn't exist
        Directory.CreateDirectory(Path);

        foreach (var author in library.Catalog.GetAllBooks().SelectMany(book => book.Authors))
        {
            string fileName = $"{author.FirstName} {author.LastName}.json";
            string filePath = $@"{Path}\{fileName}";

            var booksByAuthor = library.Catalog.GetBooksByAuthor(author).Select(book => book.MapToDtoBook());
            // A stream is created to write to a file
            await using (var stream = new FileStream(filePath, FileMode.Create))
            {
                // Serialize the books associated with the author into JSON format
                // WriteIndented = true makes the JSON structure more readable
                await JsonSerializer.SerializeAsync(stream, booksByAuthor, new JsonSerializerOptions { WriteIndented = true });
            }
        }
    }

    //TODO: Create a separate method for creating books
    public async Task<List<Book>> Get()
    {
        List<DtoBook> listOfDtoBooks = new List<DtoBook>();
        List<Book> listOfBooks = new List<Book>();

        var directory = new DirectoryInfo($@"{Path}");
        if (directory.Exists)
        {
            foreach (var file in directory.GetFiles("*.json"))
            {
                // Read file
                var json = await File.ReadAllTextAsync(file.FullName);
                // Get books by author
                var dtoBooksByAuthor = JsonSerializer.Deserialize<List<DtoBook>>(json);
                //var booksByAuthor = await JsonSerializer.DeserializeAsync<List<DtoBook>>(json);

                // Foreach books and check if the catalog already contains a book by ISBN
                if (dtoBooksByAuthor != null)
                {
                    foreach (var book in dtoBooksByAuthor)
                    {
                        //TODO: Create method to create books
                        if (listOfDtoBooks.All(b => b.Identifiers != book.Identifiers))
                        {
                            listOfDtoBooks.Add(book);
                            if (EntityValidator.IsIsbn(book.Identifiers[0]))
                            {
                                var restoredPaperBook = new PaperBook(
                                    book.Title,
                                    new HashSet<Author>(book.Authors.Select(a =>
                                        new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                                    new List<string>(book.Identifiers),
                                    //TODO: How to deal with specific properties if I avoid them?
                                    null,
                                    null);

                                //TODO: Which approach is more useful? Throw exception if book doesn't accepted or add book to catalog if it accepted (row 79)?
                                if (!EntityValidator.AcceptBook(restoredPaperBook))
                                {
                                    throw new ArgumentException("An error occurred while converting the book");
                                }

                                listOfBooks.Add(restoredPaperBook);
                            }
                            else
                            {
                                var restoredEBook = new EBook(
                                    book.Title,
                                    new HashSet<Author>(book.Authors.Select(a =>
                                        new Author(a.FirstName, a.LastName, a.DateOfBirthday))),
                                    book.Identifiers[0]);

                                if (EntityValidator.AcceptBook(restoredEBook))
                                {
                                    listOfBooks.Add(restoredEBook);
                                }
                            }
                        }
                    }
                }
            }
        }
        
        return listOfBooks;
    }
}
