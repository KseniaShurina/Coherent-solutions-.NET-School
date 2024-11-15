using Task52.Entities;

namespace Task52.Tests
{
    public class Tests
    {
        private Isbn _isbn;

        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("978186197271", "978-1-86-197271-2")] // 2
        [TestCase("978030640615", "978-0-30-640615-7")] // 7
        [TestCase("978013609181", "978-0-13-609181-3")] // 3
        [TestCase("978316148410", "978-3-16-148410-0")] // 0
        public void CreateNewIsbn_ExpectedSuccess(string isbn, string expectedIsbn)
        {
            var result = new Isbn(isbn);

            Assert.That(result.ToString(), Is.EqualTo(expectedIsbn));
            Assert.That(result.ToString(), Is.Not.EqualTo(isbn));
        }
    }
}