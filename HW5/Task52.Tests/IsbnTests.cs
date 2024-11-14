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
        [TestCase("978186197271", "9781861972712")] // 2
        [TestCase("978030640615", "9780306406157")] // 7
        [TestCase("978013609181", "9780136091813")] // 3
        [TestCase("978316148410", "9783161484100")] // 0
        public void CreateNewIsbn_ExpectedSuccess(string isbn, string expectedIsbn)
        {
            var result = new Isbn(isbn);

            Assert.That(result.ToString(), Is.EqualTo(expectedIsbn));
            Assert.That(result.ToString(), Is.Not.EqualTo(isbn));
        }
    }
}