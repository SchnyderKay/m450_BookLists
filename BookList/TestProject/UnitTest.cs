using BookLibrary;
using NUnit.Framework;

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
        public void TestFailAddBookBookExists()
        {
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
            var result = library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");

            Assert.False(result);
        }

        [Test]
        public void TestFailAddBookListNotFound()
        {
            var result = library.AddBook("test1", "testBook", "testAuthor", 353, 1999, "Reading");

            Assert.False(result);
        }


        [Test]
        public void TestRemoveBook()
        {
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
            var result = library.RemoveBook("testList", "testBook");

            Assert.True(result);
        }

        [Test]
        public void TestFailRemoveBookListNotFound()
        {
            var result = library.RemoveBook("test", "testBook");

            Assert.False(result);
        }

        [Test]
        public void TestFailRemoveBookBookNotFound()
        {
            var result = library.RemoveBook("testList", "test");

            Assert.False(result);
        }

        [Test]
        public void TestGetBookFromList()
        {
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");

            Book result = library.GetBookFromList("testList", "testBook");

            Assert.AreEqual("testBook", result.GetName());
            Assert.AreEqual("testAuthor", result.GetAuthor());
            Assert.AreEqual(353, result.GetPages());
            Assert.AreEqual(1999, result.GetPublishedYear());
            Assert.AreEqual( "Reading", result.GetReadingStatus());
        }

        [Test]
        public void TestGetBookByName()
        {
            library.NewBookList("testList2", "admin");
            library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
            library.AddBook("testList2", "testBook", "testAuthor", 353, 1999, "Reading");

            List<Book> books = library.GetBook("testBook");

            Assert.AreEqual(books.Count(), 2);

            foreach (Book book in books)
            {
                Assert.AreEqual("testBook", book.GetName());
                Assert.AreEqual("testAuthor", book.GetAuthor());
                Assert.AreEqual(353, book.GetPages());
                Assert.AreEqual(1999, book.GetPublishedYear());
                Assert.AreEqual("Reading", book.GetReadingStatus());
            }
        }

        [Test]
        public void TestGetBooklist()
        {
            List<Book> expected = new();
            expected.Add(new Book("book1", "author1", 1999, 1, "Reading"));
            expected.Add(new Book("book2", "author2", 1999, 1, "Unknown"));
            expected.Add(new Book("book3", "author3", 1999, 1, "Finished"));
            expected.Add(new Book("book4", "author4", 1999, 1, "Dropped"));

            library.NewBookList("test", "author");

            library.AddBook("test", "book1", "author1", 1999, 1, "Reading");
            library.AddBook("test", "book2", "author2", 1999, 1, "Unknown");
            library.AddBook("test", "book3", "author3", 1999, 1, "Finished");
            library.AddBook("test", "book4", "author4", 1999, 1, "Dropped");

            List<Book> results = library.GetBookList("test").GetBooks();

            foreach (Book result in results)
            {
                Assert.True(expected.Where(x => x.GetName() == result.GetName()).Count() == 1);
            }
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
        public void TestFailAddList()
        {
            bool result = library.NewBookList("testList", "admin");

            Assert.False(result);
        }

        [Test]
        public void TestRemoveList()
        {
            var result = library.RemoveBookList("testList");

            Assert.True(result);
            Assert.True(!library.GetBookLists().Exists(x => x.GetName() == "testList"));
        }

        [Test]
        public void TestFailRemoveList()
        {
            var result = library.RemoveBookList("");

            Assert.False(result);
        }

        [Test]
        public void TestGetLists()
        {
            library = new Library();

            List<BookList> expected = new List<BookList>();
            expected.Add(new BookList("test1", "user1"));
            expected.Add(new BookList("test2", "user2"));
            expected.Add(new BookList("test3", "user3"));

            library.NewBookList("test1", "user1");
            library.NewBookList("test2", "user2");
            library.NewBookList("test3", "user3");

            List<BookList> results = library.GetBookLists();

            foreach (BookList result in results)
            {
                Assert.True(expected.Where(x => x.GetName() == result.GetName()).Count() == 1);
            }
        }

        [Test]
        public void TestGetList()
        {
            library = new Library();

            library.NewBookList("test1", "user1");

            BookList result = library.GetBookList("test1");

            Assert.AreEqual("test1", result.GetName());
            Assert.AreEqual("user1", result.GetCreator());
        }

        [Test]
        public void TestChangeListName()
        {
            var result = library.ChangeListName("testList", "test1");

            Assert.True(result);
            Assert.True(library.GetBookList("test1").GetName() == "test1");
        }

        [Test]
        public void TestFailChangeListName()
        {
            var result = library.ChangeListName("testList", "testList");

            Assert.False(result);
        }

        [Test]
        public void TestChangeReadStatus()
        {
            string testStatus = "Dropped";

            library.AddBook("testList", "test1", "admin", 157, 1999, "Finished");
            library.ChangeReadStatus(testStatus, "testList", "test1");

            Assert.AreEqual(testStatus, library.GetBookFromList("testList","test1").GetReadingStatus());
        }

        [Test]
        public void TestFailChangeReadStatusBookNotFound()
        {
            string testStatus = "Dropped";

            library.AddBook("testList", "test1", "admin", 157, 1999, "Finished");
            library.ChangeReadStatus(testStatus, "testList", "test");

            Assert.AreNotEqual(testStatus, library.GetBookFromList("testList", "test1").GetReadingStatus());
        }

        [Test]
        public void TestFailChangeReadStatusListNotFound()
        {
            string testStatus = "Dropped";

            library.AddBook("testList", "test1", "admin", 157, 1999, "Finished");
            library.ChangeReadStatus(testStatus, "test", "test1");

            Assert.AreNotEqual(testStatus, library.GetBookFromList("testList", "test1").GetReadingStatus());
        }
    }
}