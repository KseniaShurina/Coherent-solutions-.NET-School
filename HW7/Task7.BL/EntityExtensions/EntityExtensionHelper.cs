﻿using Task7.DAL.DTO;
using Task7.DAL.Entities;
using Task7.DAL.Validators;

namespace Task7.BL.EntityExtensions
{
    internal static class EntityExtensionHelper
    {
        public static Book MapEntityToBook(this DTOBook book)
        {
            if (EntityValidator.IsIsbn(book.Identifiers[0]))
            {
                return new PaperBook
                    (book.Title,
                        book.Identifiers,
                        null,
                        null,
                        new HashSet<Author>(book.Authors.Select(a =>
                            new Author(a.FirstName, a.LastName, a.DateOfBirthday)))
                    );

            }

            return new EBook
                (book.Title,
                    book.Identifiers[0],
                    null,
                    new HashSet<Author>(book.Authors.Select(a =>
                        new Author(a.FirstName, a.LastName, a.DateOfBirthday)))
                );

        }

        public static Author MapToEntityAuthor(this DTOAuthor author)
        {
            return new Author(author.FirstName, author.LastName, author.DateOfBirthday);
        }

        public static Catalog MapToEntityCatalog(this DTOCatalog dtoCatalog)
        {
            Catalog catalog = new Catalog();

            foreach (var book in dtoCatalog.Books)
            {
                catalog.AddBook(book.Identifiers[0], book.MapEntityToBook());
            }
            return catalog;
        }
    }
}