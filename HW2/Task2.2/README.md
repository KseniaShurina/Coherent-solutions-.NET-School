Task 2.2

A diagonal matrix is a square matrix in which all elements outside the main diagonal are equal to zero (https://en.wikipedia.org/wiki/Diagonal_matrix).

You need to create and test a class to represent a diagonal matrix containing integers (int).

1.The class object stores only matrix elements located on the diagonal. Use one-dimensional array for this.
2.The class object has a read-only Size property - the size of the matrix (for example, for a 5x5 matrix, 
the Size property returns the value 5).

3.The class has a constructor for creating a matrix. A list of parameters (params) is passed to the constructor - these are matrix elements located on the diagonal. 
If the value of the constructor argument is not correct (for example, equal to null), a zero-size matrix is created (Size=0).

4.For convenience, the class offers an indexer with two indices i and j. If i is not equal to j, then the indexer returns the value 0 (nothing happens when writing). 
If the index values are incorrect (out of bounds: less than zero or greater than or equal to Size), nothing happens when writing, and when reading, the value 0 is returned.

5.The matrix class has an instance method Track(), which returns the sum of the matrix elements located on the main diagonal.

6.Override the Equals() and ToString() methods in the matrix class. Two matrices are considered equal 
if their sizes and corresponding elements on the diagonal are the same.

7.Create a diagonal matrix extension method that performs the addition of two diagonal matrices. The result of the method is a new diagonal matrix. 
If the matrix sizes do not match, the smaller matrix is padded with zeros.