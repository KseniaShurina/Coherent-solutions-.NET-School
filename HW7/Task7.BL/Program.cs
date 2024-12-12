using Task7.BL;
using Task7.DAL.Entities;
using Task7.DAL.Interfaces;
using Task7.DAL.Repositories;

// Create authors
var author1 = new Author("George", "Orwell", new DateTime(1903, 6, 25));
var author2 = new Author("Yuval Noah", "Harari", new DateTime(1976, 2, 24));
var author3 = new Author("J.K.", "Rowling", new DateTime(1965, 7, 31));
var author4 = new Author("Jane", "Austen", new DateTime(1775, 12, 16));

// Create PaperBook
var paperBook1 = new PaperBook(
    "1984",
    new HashSet<Author> { author1 },
    new List<string> { "9780451524935", "9780451526342", "9780141036144" },
    new DateTime(1949, 6, 8),
    "Secker & Warburg"
);

var paperBook2 = new PaperBook(
    "Sapiens: A Brief History of Humankind",
    new HashSet<Author> { author2 },
    new List<string> { "9780062316097", "9780062316110", "9780099590088" },
    new DateTime(2011, 9, 4),
    "Harper"
);

var paperBook3 = new PaperBook(
    "Pride and Prejudice",
    new HashSet<Author> { author4 },
    new List<string> { "9780141439518", "9780199535569", "9780141199078" },
    new DateTime(1813, 1, 28),
    "T. Egerton"
);

var paperBook4 = new PaperBook(
    "Harry Potter and the Philosopher's Stone",
    new HashSet<Author> { author3 },
    new List<string> { "9780747532743", "9780439554930", "9781408855898" },
    new DateTime(1997, 6, 26),
    "Bloomsbury"
);

var paperBook5 = new PaperBook(
    "Homo Deus: A Brief History of Tomorrow",
    new HashSet<Author> { author2 },
    new List<string> { "9780062464316", "9780099590088" },
    new DateTime(2015, 9, 4),
    "Harper"
);

var paperBook6 = new PaperBook(
    "21 Lessons for the 21st Century",
    new HashSet<Author> { author2 },
    new List<string> { "9780525512172", "9781787330672" },
    new DateTime(2018, 8, 30),
    "Penguin"
);

// Create EBook
var eBook1 = new EBook(
    "Sapiens: A Brief History of Humankind",
    new HashSet<Author> { author2 },
    "heidispryi00spyr",
    new List<string> { "PDF", "EPUB", "MOBI" }
);
var eBook2 = new EBook(
    "Harry Potter and the Chamber of Secrets",
    new HashSet<Author> { author3 },
    "harrychamber00rowling",
    new List<string> { "EPUB", "MOBI" }
);

var eBook3 = new EBook(
    "Emma",
    new HashSet<Author> { author4 },
    "emmaausten00jane",
    new List<string> { "PDF", "EPUB" }
);

var eBook4 = new EBook(
    "Homo Deus: A Brief History of Tomorrow",
    new HashSet<Author> { author2 },
    "jrfghjbryi00spyr",
    new List<string> { "PDF", "EPUB", "MOBI" }
);

// Create catalog with paper books
Catalog catalogWithPaperBooks = new Catalog();
catalogWithPaperBooks.AddBook(paperBook1.Isbns[0], paperBook1);
catalogWithPaperBooks.AddBook(paperBook2.Isbns[0], paperBook2);
catalogWithPaperBooks.AddBook(paperBook3.Isbns[0], paperBook3);
catalogWithPaperBooks.AddBook(paperBook4.Isbns[0], paperBook4);
catalogWithPaperBooks.AddBook(paperBook5.Isbns[0], paperBook5);
catalogWithPaperBooks.AddBook(paperBook6.Isbns[0], paperBook6);

// Create catalog with EBooks
Catalog catalogWithEBooks = new Catalog();
catalogWithEBooks.AddBook(eBook1.Identifier, eBook1);
catalogWithEBooks.AddBook(eBook2.Identifier, eBook2);
catalogWithEBooks.AddBook(eBook3.Identifier, eBook3);
catalogWithEBooks.AddBook(eBook4.Identifier, eBook4);

// GetBookTitles
Console.WriteLine("Get Book Titles:");
var bookTitles = catalogWithPaperBooks.GetBookTitles();
foreach (var title in bookTitles)
{
    Console.WriteLine(title);
}

// GetBooksByAuthor
Console.WriteLine();
Console.WriteLine("Get Books By Author:");
var booksByAuthor = catalogWithPaperBooks.GetBooksByAuthor(author2);
foreach (var book in booksByAuthor)
{
    Console.WriteLine(book);
}

// GetBookByIsbn
Console.WriteLine();
Console.WriteLine("Get Book By Isbn:");
var bookByIsbn1 = catalogWithPaperBooks.GetBookByIsbn("9780062316097"); // paperBook2
Console.WriteLine($"{nameof(bookByIsbn1)}: {bookByIsbn1}");
var bookByIsbn2 = catalogWithPaperBooks.GetBookByIsbn("9780141439518"); // paperBook3
Console.WriteLine($"{nameof(bookByIsbn2)}: {bookByIsbn2}");

//GetNumberOfBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Number Of Books By Author:");
foreach (var author in catalogWithPaperBooks.GetNumberOfBooksByAuthor())
{
    Console.WriteLine(author);
}

// Create paper factory
var paperFactory = new PaperLibraryFactory();
var paperLibrary = paperFactory.CreateLibrary(catalogWithPaperBooks);
Console.WriteLine();
Console.WriteLine("Get all publishers from paper books:");
foreach (var item in paperLibrary.GetPressReleaseItems())
{
    Console.WriteLine(item);
}

// Create e factory
var eFactory = new ELibraryFactory();
var eLibrary = eFactory.CreateLibrary(catalogWithEBooks);
Console.WriteLine();
Console.WriteLine("Get all publishers from electronic books:");
foreach (var item in eLibrary.GetPressReleaseItems())
{
    Console.WriteLine(item);
}

// Repositories
IRepository xmlRepository = new XmlRepository();
IRepository jsonRepository = new JsonRepository();
// Save catalog with paper books to XML
await xmlRepository.Save(catalogWithPaperBooks);
Console.WriteLine();
Console.WriteLine("Catalog from XML:");
var catalogFromXml = await xmlRepository.Get();

Console.WriteLine($"Are catalogs equal?: {catalogWithPaperBooks.Equals(catalogFromXml)}"); //True

foreach (var book in catalogFromXml.GetNumberOfBooksByAuthor())
{
    Console.WriteLine(book);
}

// Save catalog with paper electronic books to JSON
Console.WriteLine();
await jsonRepository.Save(catalogWithEBooks);
// catalogWithEBooks
Console.WriteLine("Catalog from JSON:");

var catalogFromJson = await jsonRepository.Get();
Console.WriteLine($"Are catalogs equal?: {catalogWithEBooks.Equals(catalogFromJson)}"); //True

foreach (var book in catalogFromJson.GetNumberOfBooksByAuthor())
{
    Console.WriteLine(book);
}