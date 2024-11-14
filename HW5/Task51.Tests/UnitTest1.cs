namespace Task51.Tests
{
    [TestFixture]
    public class SparseMatrixTests
    {
        private SparseMatrix _matrix;

        [SetUp]
        public void Setup()
        {
            _matrix = new SparseMatrix(10, 10);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(0, 1)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void CreateNewSparseMatrix_ShouldThrowArgumentOutOfRangeException(int rows, int columns)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new SparseMatrix(rows, columns));
        }

        [Test]
        [TestCase(1, 1)]
        [TestCase(2, 2)]
        [TestCase(100, 100)]
        [TestCase(1000, 100)]
        [TestCase(10, 100)]
        [TestCase(50, 55)]
        public void CreateNewSparseMatrix_ShouldInitializeCorrectly(int rows, int columns)
        {
            // Act
            var result = new SparseMatrix(rows, columns);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.NumberOfRows, Is.EqualTo(rows));
            Assert.That(result.NumberOfColumns, Is.EqualTo(columns));
        }

        [TestCase(50, 55)]
        [TestCase(10, 100)]
        [TestCase(1, 10)]
        [TestCase(10, 10)]
        [TestCase(-1, 0)]
        [TestCase(0, -1)]
        [TestCase(-1, -1)]
        public void ChangeValueByIndexes_ShouldThrowIndexOutOfRangeException(int row, int column)
        {
            Assert.Throws<IndexOutOfRangeException>(() => _matrix[row, column] = 5);
        }

        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(1, 3)]
        public void ChangeValueByIndexes_ShouldReturnValue(int row, int column)
        {
            _matrix[row, column] = 5;
            _matrix[row, column] = 10;
            _matrix[row, column] = 51;

            var result = _matrix[row, column];

            Assert.That(result, Is.EqualTo(_matrix[row, column]));
            Assert.That(result, Is.Not.Null);
        }

        [TestCase(0, 0)]
        [TestCase(1, 0)]
        [TestCase(2, 0)]
        [TestCase(3, 0)]
        [TestCase(4, 4)]
        [TestCase(5, 5)]
        [TestCase(1, 3)]
        public void ChangeValueByIndexes_ShouldReturnDefaultValue(int row, int column)
        {
            Assert.That(_matrix[row, column], Is.EqualTo(default(long)));
            Assert.That(_matrix[row, column], Is.Not.Null);
        }

        [TestCase(0, 0)]
        [TestCase(0, 9)]
        [TestCase(9, 0)]
        [TestCase(9, 9)]
        public void GetNonZeroElements_ShouldReturnCorrectElementsInColumnOrder(int row, int column)
        {
            // Arrange
            _matrix[0, 0] = 1;
            _matrix[9, 0] = 3;
            _matrix[0, 9] = 2;
            _matrix[9, 9] = 4;
                    
            // Assert
            var expected = new List<(int, int, long)>
            {
                (0, 0, 1),
                (9, 0, 3),
                (0, 9, 2),
                (9, 9, 4)
            };
            //Act
            var result = _matrix.GetNonZeroElements();

            Assert.That(result, Is.Not.Null);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetNonZeroElements_WhenMatrixIsEmpty_ShouldReturnEmpty()
        {
            // Act
            var result = _matrix.GetNonZeroElements().ToList();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetNonZeroElements_WhenNoNonZeroElements_ShouldReturnEmpty()
        {
            // Arrange
            _matrix[0, 0] = 0;
            _matrix[1, 1] = 0;
            _matrix[2, 2] = 0;

            // Act
            var result = _matrix.GetNonZeroElements().ToList();

            // Assert
            Assert.IsEmpty(result);
        }

        [Test]
        public void GetCount_WhenCountingZeros_ShouldReturnCorrectCount()
        {
            _matrix[0, 0] = 1;
            _matrix[1, 1] = 2;
            _matrix[2, 2] = 3;
            _matrix[5, 1] = 4;
            _matrix[7, 3] = 5;

            // Arrange
            int expectedCount = 95;

            // Act
            var result = _matrix.GetCount(0);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetCount_WhenCountingExistingValue_ShouldReturnCorrectCount()
        {
            _matrix[0, 0] = 5;
            _matrix[1, 1] = 5;
            _matrix[2, 2] = 5;

            // Arrange
            int expectedCount = 3;

            // Act
            var result = _matrix.GetCount(5);

            // Assert
            Assert.That(result, Is.EqualTo(expectedCount));
        }

        [Test]
        public void GetCount_WhenCountingNonExistingValue_ShouldReturnZero()
        {
            // Act
            var result = _matrix.GetCount(99);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}