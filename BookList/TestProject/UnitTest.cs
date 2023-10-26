using BookLibrary;

namespace TestProject
{
    public class Tests
    {
        private Library library;

        [SetUp]
        public void Setup()
        {
            library = new Library();
            library.NewBookList("testList", "admin");
        }

        [Test]
        public void TestAddBook()
        {
            var result = library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");

            Assert.True(result);
           
        }

        [Test]
        public void TestRemoveBook()
        {
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
            var result = library.RemoveBook("testList", "testBook");

            Assert.True(result);
        }

        
        [Test]
        public void TestGetBook()
        {
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
            Book expected = new("testBook", "testAuthor", 353, 1999, "Reading");

            Book result = library.GetBook("testBook");

            Assert.AreEqual(expected.GetName(), result.GetName());
        }

        [Test]
        public void TestGetBooklist()
        {
            List<Book> expected = new();
            expected.Add(new Book("book1", "author1", 1999, 1, "Reading"));
            expected.Add(new Book("book2", "author2", 1999, 1, "Unknown"));
            expected.Add(new Book("book3", "author3", 1999, 1, "Finsihed"));
            expected.Add(new Book("book4", "author4", 1999, 1, "Dropped"));

            library.NewBookList("test", "author");

            library.AddBook("test", "book1", "author1", 1999, 1, "Reading");
            library.AddBook("test", "book2", "author2", 1999, 1, "Unknown");
            library.AddBook("test", "book3", "author3", 1999, 1, "Finsihed");
            library.AddBook("test", "book4", "author4", 1999, 1, "Dropped");

            List<Book> result = library.GetBookList("test").GetBooks();           
        }

        [Test]
        public void TestAddList()
        {
            library.NewBookList("test", "admin");

            BookList expected = new("test", "admin");

            BookList result = library.GetBookList("test");

            Assert.That(result.GetName(), Is.EqualTo(expected.GetName()));
        }


        [Test]
        public void TestRemoveList() 
        {
            var result = library.RemoveBookList("testList");

            Assert.True(result);
        }
    }
}