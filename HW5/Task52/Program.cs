using Task52.Entities;

Catalog catalog = new Catalog();

Book book1 = new Book("How to become rich and successful",
    new Isbn("978186197271"), // ISBN without control number in the end
    new DateTime(2024, 11, 13),
    ["Ksenia Shurina"]
    );

Book book2 = new Book("Blue Ocean Strategy",
    new Isbn("978-1-59-139619-2"), // ISBN in format XXX-X-XX-XXXXXX-X
    new DateTime(2005, 2, 3),
    new List<string> { "W. Chan Kim", "Renée Mauborgne" }
);

Book book3 = new Book("Rich Dad Poor Dad",
    new Isbn("9781612680194"), // ISBN already with control number in the end
    new DateTime(1997, 4, 1),
    new List<string> { "Robert T. Kiyosaki", "Sharon Lechter" }
);

Book book4 = new Book("Cashflow Quadrant: Rich Dad's Guide to Financial Freedom",
    new Isbn("9781612680057"),
    new DateTime(1998, 1, 15),
    new List<string> { "Robert T. Kiyosaki" }
);

//TODO: Change ISBN, but what if I add book to catalog firstly and then change ISBN?
//book1.Isbn = new Isbn("978006662099");

catalog.AddBook(book1);
catalog.AddBook(book2);
catalog.AddBook(book3);
catalog.AddBook(book4);

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
var booksbyAuthor = catalog.GetBooksByAuthor("Ksenia Shurina");
foreach (var book in booksbyAuthor)
{
    Console.WriteLine(book);
}

// GetBookByIsbn
Console.WriteLine();

Console.WriteLine("Get Book By Isbn:");
var bookByIsbn1 = catalog.GetBookByIsbn("978-1-86-197271-2");
Console.WriteLine(bookByIsbn1);
var bookByIsbn2 = catalog.GetBookByIsbn("9781612680194");
Console.WriteLine(bookByIsbn2);

//GetNumberOfBooksByAuthor
Console.WriteLine();

Console.WriteLine("Get Number Of Books By Author:");
var getNumberOfBooksByAuthor = catalog.GetNumberOfBooksByAuthor();
foreach (var author in getNumberOfBooksByAuthor)
{
    Console.WriteLine(author);
}