using Task6.BL.Interfaces;
using Task6.BL.Services;
using Task6.DAL.Entities;

// To manage catalog
ICatalogService _catalogService = new CatalogService();

// Create authors
var author1 = new Author("Eric", "Ries", new DateTime(1978, 4, 1));
var author2 = new Author("Napoleon", "Hill", new DateTime(1883, 10, 26));
var author3 = new Author("W. Chan", "Kim", new DateTime(1951, 6, 8));
var author4 = new Author("Renée", "Mauborgne", new DateTime(1959, 11, 22));
var author5 = new Author("Robert", "T. Kiyosaki", new DateTime(1947, 4, 8));
var author6 = new Author("Sharon", "Lechter", new DateTime(1954, 1, 12));

// Create books
var book1 = new Book("The Lean Startup",
    new Isbn("9780307887894"), //13
    new DateTime(2011, 9, 13),
    new[] { author1 });
var book2 = new Book("Think and Grow Rich",
    new Isbn("978158542433"), //12
    new DateTime(1937, 1, 1),
    new[] { author2 });
var book3 = new Book("Blue Ocean Strategy",
    new Isbn("9781591396192"), //13
    new DateTime(2005, 2, 3),
    new[] { author3, author4 });
var book4 = new Book("Rich Dad Poor Dad",
    new Isbn("978161268019"), //12
    new DateTime(1997, 4, 1),
    new[] { author5, author6 });
var book5 = new Book("Cashflow Quadrant",
    new Isbn("9781612680057"), //13
    new DateTime(1998, 1, 15),
    new[] { author5 });
var book6 = new Book("Blue Ocean Shift",
    new Isbn("978150983216"), //12
    new DateTime(2017, 9, 26),
    new[] { author3, author4 });
var book7 = new Book("Outwitting the Devil",
    new Isbn("9781454900676"), //13
    new DateTime(2011, 6, 7),
    new[] { author2 });
var book8 = new Book("Rich Dad's Guide to Investing",
    new Isbn("978161268010"), //12
    new DateTime(2000, 5, 1),
    new[] { author5, author6 });

// Create catalog and add all books
Catalog catalog = new Catalog();
catalog.AddBook(book1);
catalog.AddBook(book2);
catalog.AddBook(book3);
catalog.AddBook(book4);
catalog.AddBook(book5);
catalog.AddBook(book6);
catalog.AddBook(book7);
catalog.AddBook(book8);

// Filling authors with their books
FillAuthorWithBooks(author1);
FillAuthorWithBooks(author2);
FillAuthorWithBooks(author3);
FillAuthorWithBooks(author4);
FillAuthorWithBooks(author5);
FillAuthorWithBooks(author6);

void FillAuthorWithBooks(Author author)
{
    var list = catalog.GetBooksByAuthor(author);
    if (list.Count != 0)
    {
        list.ForEach((book => author.AddBook(book)));
    }
}

// GetBookTitles
Console.WriteLine();

Console.WriteLine("Get Book Titles:");
var bookTitles = catalog.GetBookTitles();
foreach (var title in bookTitles)
{
    Console.WriteLine(title);
}

// GetBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Books By Author:");
var booksbyAuthor = catalog.GetBooksByAuthor(author2);
foreach (var book in booksbyAuthor)
{
    Console.WriteLine(book);
}

// GetBookByIsbn
Console.WriteLine();

Console.WriteLine("Get Book By Isbn:");
var bookByIsbn1 = catalog.GetBookByIsbn("9780307887894"); // book 1
Console.WriteLine(bookByIsbn1);
var bookByIsbn2 = catalog.GetBookByIsbn("978-1-59-139619-2"); // book 3
Console.WriteLine(bookByIsbn2);

//GetNumberOfBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Number Of Books By Author:");
var getNumberOfBooksByAuthor = catalog.GetNumberOfBooksByAuthor();
foreach (var author in getNumberOfBooksByAuthor)
{
    Console.WriteLine(author);
}

_catalogService.SaveCatalogToXML(catalog);

Console.WriteLine();
Console.WriteLine("Received catalog:");
var receivedCatalog = _catalogService.GetCatalogFromXML();
foreach (var book in receivedCatalog.GetNumberOfBooksByAuthor())
{
    Console.WriteLine(book);
}

Console.WriteLine();
_catalogService.SaveCatalogToJSON(catalog);

//_catalogService.GetCatalogFromJSON();