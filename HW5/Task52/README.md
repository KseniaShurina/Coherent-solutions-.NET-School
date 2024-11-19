Task 5.2.

To do:
1.Create a simple class to represent a book. In the book class, store the title of the book (a string, not empty, not null), 
the publication date of the book (possibly null), and the set of authors of the book (a collection of non-repeating strings, possibly empty).

2.The 13-digit ISBN of a book is a string in the format XXX-X-XX-XXXXXX-X or XXXXXXXXXXXXX, where X is the number 0..9. 
Create your class Catalog - is a collection, like a dictionary, that stores books. Provide access to the book by key string - by ISBN of the book. 
Please note an important nuance - if a book was placed in a catalog using the key 123-4-56-789012-3, 
then it can be retrieved using both the key 123-4-56-789012-3 and the key 1234567890123. 
The correctness of the ISBN itself in this task You don’t have to check 
(there is no need to check the check digits; it is advisable to check the correctness of the format itself - for example, using regular expressions).

3.Implement the following methods for working with the Directory using LINQ to Objects:
a) Get a set of book titles from the catalog, sorted alphabetically.
b) Retrieve from the catalog a set of books (objects of the corresponding class) by the specified author name. Books should be sorted by publication date.
c) Get from the catalog a set of tuples of the form “author’s name – the number of his books in the catalog” for all authors.
