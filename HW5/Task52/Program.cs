using Task52.Entities;

Catalog catalog = new Catalog();

Book  book1 = new Book
{
    Title = "How to become rich and successful",
    Isbn = new Isbn("978186197271"),
    PublicationDate = new DateTime(2024, 11, 13)
};
Book book2 = new Book
{
    Title = "The Lean Startup",
    Isbn = new Isbn("978030788789"),
    PublicationDate = new DateTime(2011, 9, 13)
};
Book book3 = new Book
{
    Title = "Blue Ocean Strategy",
    Isbn = new Isbn("978159139619"), // 2
    PublicationDate = new DateTime(2005, 2, 3)
};

Author author = new Author
{
    FirstName = "Ksenia",
    LastName = "Shurina"
};
book1.AddAuthor(author);

catalog.AddBook(book1);
catalog.AddBook(book2);
catalog.AddBook(book3);

// GetBookTittles
var bookTitles = catalog.GetBookTittles();
foreach (var title in bookTitles)
{
    Console.WriteLine(title);
}

// GetBooksByAuthor
var booksbyAuthor = catalog.GetBooksByAuthor(author);
foreach (var book in booksbyAuthor)
{
    Console.WriteLine(book);
}
// GetBookByIsbn
var bookByIsbn = catalog.GetBookByIsbn("9781591396192");
Console.WriteLine("Get book by ISBN:");
Console.WriteLine(bookByIsbn);