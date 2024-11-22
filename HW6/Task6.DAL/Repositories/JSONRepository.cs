using System.Text.Json;
using Task6.DAL.Entities;
using Task6.DAL.Extensions;
using Task6.DAL.Interfaces;
using Task6.DAL.JSONEntities;

namespace Task6.DAL.Repositories
{
    public class JSONRepository : IJSONRepository
    {
        private const string path = @"D:\Xeni\Repositories\Coherent-solutions-.NET-School\HW6\Files\JSON files";
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
                        // Serialize the books associated with the author into JSON format
                        string json = JsonSerializer.Serialize(author.Books.Select(b => b.MapToJsonBook()), new JsonSerializerOptions { WriteIndented = true });
                        // Write the JSON content to a file in the specified directory
                        File.WriteAllText($@"{pathToDirectory}\{fileName}", json);
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<JSONAuthor> Get()
        {
            var list = new List<JSONAuthor>();
            foreach (var file in Directory.GetFiles($@"{path}\Catalog"))
            {
                // Remove .json
                var authorName = file[..5].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                JSONAuthor author = JsonSerializer.Deserialize<JSONAuthor>(file);
                list.Add(author);
            }

            return list;
        }
    }
}
