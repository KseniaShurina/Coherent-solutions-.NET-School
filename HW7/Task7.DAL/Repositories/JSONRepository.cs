using System.Text.Json;
using Task7.DAL.DTO;
using Task7.DAL.DTOExtensions;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.Validators;

namespace Task7.DAL.Repositories
{
    public class JSONRepository : IRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW7\Files\JSON files";
        public JSONRepository() { }

        /// <summary>
        /// Saves the catalog to a directory as JSON files. 
        /// Each author's books are serialized into a separate JSON file named after the author's first and last name.
        /// </summary>
        /// <param name="catalog">The catalog to save. Contains books with associated authors.</param>
        /// <exception cref="NullReferenceException">Thrown if catalog is null</exception>
        public void Save(Catalog catalog)
        {
            if (catalog == null)
            {
                throw new NullReferenceException(nameof(catalog));
            }

            // Define the directory path where JSON files will be saved
            string pathToDirectory = $@"{path}\Catalog";
            DirectoryInfo directory = new DirectoryInfo(pathToDirectory);
            // Create the directory if it doesn't exist
            directory.Create();
            if (Directory.Exists(pathToDirectory))
            {
                // Iterate over all books in the catalog
                foreach (var book in catalog.GetAllBooks())
                {
                    // Iterate over all authors of the current book
                    foreach (var author in book.Authors)
                    {
                        // Generate file name based on the author's name
                        string fileName = $"{author.FirstName} {author.LastName}.json";

                        var booksByAuthor = catalog.GetBooksByAuthor(author).Select(b => b.MapToDTOBook());

                        // Serialize the books associated with the author into JSON format
                        string json = JsonSerializer.Serialize(booksByAuthor, new JsonSerializerOptions { WriteIndented = true });

                        // Write the JSON content to a file in the specified directory
                        File.WriteAllText($@"{pathToDirectory}\{fileName}", json);
                    }
                }
            }
        }

        public Catalog Get()
        {
            List<DTOBook> books = new List<DTOBook>();

            var directory = new DirectoryInfo($@"{path}\Catalog");
            if (directory.Exists)
            {
                foreach (var file in directory.GetFiles("*.json"))
                {
                    // Read file
                    var json = File.ReadAllText(file.FullName);
                    // Get books by author
                    var booksByAuthor = JsonSerializer.Deserialize<List<DTOBook>>(json);

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
                    var paperBook = new PaperBook(book.Title, book.Identifiers, null, null, new HashSet<Author>(
                        book.Authors!.Select(a =>
                            new Author(a.FirstName, a.LastName, a.DateOfBirthday))));
                    catalog.AddBook(paperBook.Isbns[0], paperBook);
                }
            }
            return catalog;
        }
    }
}
