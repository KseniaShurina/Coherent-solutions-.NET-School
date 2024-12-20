﻿using System.Text.RegularExpressions;
using Task7.DAL.Entities;

namespace Task7.DAL.Validators;

public class EntityValidator
{
    private const string RegexPattern = @"\d{3}-?\d{1}-?\d{2}-?\d{6}-?\d{1}";
    private const byte SizeOfName = 200;

    public static bool AcceptBook(Book? book)
    {
        if (book == null) return false;

        if (book is PaperBook paperBook)
        {
            foreach (var isbn in paperBook.Isbns)
            {
                if (!AcceptIsbn(isbn)) return false;
            }
        }

        if (book.Authors != null)
        {
            // Check that each author has FirstName and LastName filled in
            if (book.Authors.Any(a => IsPropNullOrEmpty(a.FirstName) || IsPropNullOrEmpty(a.LastName)))
            {
                return false;
            }
        }

        return true;
    }

    public static bool AreBooksTheSameType(IEnumerable<Book> books, Type type)
    {
        if (books.Any(b => b.GetType() != type))
        {
            return false;
        }
        return true;
    }

    public static bool IsIsbn(string identifier)
    {
        return Regex.IsMatch(identifier, RegexPattern);
    }

    public static bool AcceptIsbn(string? isbn)
    {
        if (isbn == null) return false;
        if (IsPropNullOrEmpty(isbn)) return false;

        if (!Regex.IsMatch(isbn, RegexPattern))
        {
            return false;
        }

        return true;
    }

    public static bool AcceptAuthor(Author? author)
    {
        if (author == null) return false;

        if (AcceptNameOfAuthor(author.FirstName, author.LastName))
        {
            return false;
        }

        return true;
    }

    public static bool AcceptNameOfAuthor(string firstName, string lastName)
    {
        if (IsPropNullOrEmpty(firstName) || firstName.Length > SizeOfName)
        {
            return false;
        }

        if (IsPropNullOrEmpty(lastName) || lastName.Length > SizeOfName)
        {
            return false;
        }

        return true;
    }

    private static bool IsPropNullOrEmpty(string prop)
    {
        return string.IsNullOrEmpty(prop);
    }
}
