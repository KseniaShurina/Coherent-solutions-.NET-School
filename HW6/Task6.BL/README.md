Task 6: Extension of Task 5.2

To do:

1. Create a simple class to represent a Book. In the book class, store the title of the book (a string, not empty, not null), 
the publication date of the book (possibly null), and a collection of Authors (first name, last name, date of birth, 
limitation for names - not more than 200 symbols of the book (collection can be empty)).

2. The 13-digit ISBN of a book is a string in the format XXX-X-XX-XXXXXX-X or XXXXXXXXXXXXX, where X is the number 0..9. 
Create your class Catalog - is a collection, like a dictionary, that stores books. Provide access to the book by key string - by ISBN of the book. 
Please note an important nuance - if a book was placed in a catalog using the key 123-4-56-789012-3, 
then it can be retrieved using both the key 123-4-56-789012-3 and the key 1234567890123. 
The correctness of the ISBN itself in this task You don’t have to check 
(there is no need to check the check digits; it is advisable to check the correctness of the format itself - for example, using regular expressions).

3. Create a Catalog class to store a collection of books, catalog can’t contain books with the same ISBN.

4. Create and fill the Catalog book by real books with authors and ISBN (not less than 4 books, some books have to have several authors, 
author has to have several books).

5. Save catalog object to an XML file (use XMLSerializer class). See sample of XML file.

6. Restore Catalog object from XML file. Check identity to initial object.

7. Save catalog object into JSON files (one file-one author with all his books).

8. Restore catalog object from JSON files. Check identity.

Note:
It is recommended for saving and restoring purposes to create and implement IRepository interface 
(for example, implemented in XMLRepository and JSONRepository classes). Use DAL (Data Access Layer), 
keep in mind that the task can be extended -> more data sources can be added (for example, SQLRepository), 
and the task will be - read from XML, save to SQL.