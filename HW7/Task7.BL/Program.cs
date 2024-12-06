using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.Repositories;

// Create authors
var author1 = new Author("George", "Orwell", new DateTime(1903, 6, 25));
var author2 = new Author("Yuval Noah", "Harari", new DateTime(1976, 2, 24));

// Create books
var paperBook1 = new PaperBook("1984", new List<string> { "9780451524935" }, new DateTime(1949, 6, 8),
    "Secker & Warburg", new HashSet<Author> { author1 });

var paperBook2 = new PaperBook(
    "1984222222222222",
    new List<string> { "9780451524932" },
    new DateTime(1949, 6, 8),
    "Secker & Warburg",
    new HashSet<Author> { author1 }
);

var eBook1 = new EBook(
    "Sapiens: A Brief History of Humankind",
    "heidispryi00spyr",
    new List<string> { "PDF", "EPUB", "MOBI" },
    new HashSet<Author> { author2 }
);


// Create catalog With Paper Books and add all books
Catalog catalogWithPaperBooks = new Catalog();
catalogWithPaperBooks.AddBook(paperBook1.Isbns[0], paperBook1);
catalogWithPaperBooks.AddBook(paperBook2.Isbns[0], paperBook2);
//catalog.AddBook(eBook1.Identifier, eBook1);

// GetBookTitles
Console.WriteLine();

Console.WriteLine("Get Book Titles:");
var bookTitles = catalogWithPaperBooks.GetBookTitles();
foreach (var title in bookTitles)
{
    Console.WriteLine(title);
}

// GetBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Books By Author:");
var booksbyAuthor = catalogWithPaperBooks.GetBooksByAuthor(author2);
foreach (var book in booksbyAuthor)
{
    Console.WriteLine(book);
}

// GetBookByIsbn
Console.WriteLine();

Console.WriteLine("Get Book By Isbn:");
var bookByIsbn1 = catalogWithPaperBooks.GetBookByIsbn("9780451524932"); // paperBook2
Console.WriteLine(bookByIsbn1);
var bookByIsbn2 = catalogWithPaperBooks.GetBookByIsbn("9780451524935"); // paperBook1
Console.WriteLine(bookByIsbn2);

//GetNumberOfBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Number Of Books By Author:");
foreach (var author in catalogWithPaperBooks.GetNumberOfBooksByAuthor())
{
    Console.WriteLine(author);
}

//// Repositories
//IRepository xmlRepository = new XMLRepository();
//IRepository jsonRepository = new JSONRepository();

//xmlRepository.Save(catalog);

//Console.WriteLine("Catalog from XML:");

//var catalogFromXml = xmlRepository.Get();
//Console.WriteLine($"Are catalogs equal?: {catalog.Equals(catalogFromXml)}"); // True

//foreach (var book in catalogFromXml.GetNumberOfBooksByAuthor())
//{
//    Console.WriteLine(book);
//}

//// Catalog from JSON
//Console.WriteLine();
//jsonRepository.Save(catalog);

//Console.WriteLine("Catalog from JSON:");

//var catalogFromJson = jsonRepository.Get();
//Console.WriteLine($"Are catalogs equal?: {catalog.Equals(catalogFromJson)}"); //True

//foreach (var book in catalogFromJson.GetNumberOfBooksByAuthor())
//{
//    Console.WriteLine(book);
//}