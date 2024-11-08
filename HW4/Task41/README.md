Task 4.1.

This task is based on the diagonal matrix task. By classical definition, a numeric diagonal matrix 
is a square matrix in which all elements outside the main diagonal are equal to zero. In the same assignment, 
you need to create a generic class for a diagonal matrix with elements of any type T (elements off the main diagonal are equal to the default value for T).

To do:
1. The class object stores only matrix elements located on the diagonal. A one-dimensional array is used for this.
2. The class has a constructor for creating a matrix. The size of the matrix is passed to the constructor (for example, 5 for a 5x5 matrix). 
If the argument is negative, an ArgumentException is thrown.
3. The class object has a read-only Size property - the size of the matrix (for example, for a 5x5 matrix, the Size property returns 5).
4. The class offers an indexer with two indices i and j. If index values are less than zero or greater than or equal to the matrix size, 
an IndexOutOfRangeException is thrown. If i is not equal to j: when reading, the default value for type T is returned, and when writing, nothing happens.
5. The matrix class contains an ElementChanged event, which occurs after a matrix element is changed, 
and only if the new value of the element is different from the old value. The element's indices, the old value of the element, 
and the new value of the element are transmitted to the event as additional information. Attention: use standard practices for working with events!
6. Create a diagonal matrix extension method that performs the addition of two diagonal matrices. One of the method's parameters must be an instance 
of a delegate that describes how to perform the addition of two elements of type T (this is a function with two parameters). Test the extension method.
7. Implement a MatrixTracker class that takes a diagonal matrix as a constructor parameter, subscribes to its ElementChanged event, and has a public Undo() method. 
When this method is called, the last element change made in the matrix is rolled back (i.e., undone).