using BookLibrary;
using NUnit.Framework;

namespace TestProject;

public class Tests
{
    private Library library = new();

    [SetUp]
    public void Setup()
    {
        library = new Library();
        library.NewBookList("testList", "admin");
    }

    [Test]
    public void TestAddBook()
    {
        bool result = library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");

        Assert.True(result);
    }

    [Test]
    public void TestRemoveBook()
    {
        library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
        bool result = library.RemoveBook("testList", "testBook");

        Assert.True(result);
    }

    [Test]
    public void TestGetBook()
    {
        library.AddBook("testList", "testBook", "testAuthor", 353, 1999, "Reading");
        Book expected = new("testBook", "testAuthor", 353, 1999, "Reading");

        Book result = library.GetBook("testBook");

        Assert.AreEqual(expected.GetName(), result.GetName());
        Assert.AreEqual(expected.GetAuthor(), result.GetAuthor());
        Assert.AreEqual(expected.GetPages(), result.GetPages());
        Assert.AreEqual(expected.GetPublishedYear(), result.GetPublishedYear());
        Assert.AreEqual(expected.GetReadingStatus(), result.GetReadingStatus());
    }

    [Test]
    public void TestGetBookList()
    {
        List<Book> expected = new()
        {
            new Book("book1", "author1", 1999, 1, "Reading"),
            new Book("book2", "author2", 1999, 1, "Unknown"),
            new Book("book3", "author3", 1999, 1, "Finished"),
            new Book("book4", "author4", 1999, 1, "Dropped")
        };

        library.NewBookList("test", "author");

        library.AddBook("test", "book1", "author1", 1999, 1, "Reading");
        library.AddBook("test", "book2", "author2", 1999, 1, "Unknown");
        library.AddBook("test", "book3", "author3", 1999, 1, "Finished");
        library.AddBook("test", "book4", "author4", 1999, 1, "Dropped");

        List<Book> results = library.GetBookList("test").GetBooks();

        foreach (Book result in results)
        {
            Assert.True(expected.Count(x => x.GetName() == result.GetName()) == 1);
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
    public void TestRemoveList()
    {
        bool result = library.RemoveBookList("testList");

        Assert.True(result);
    }

    [Test]
    public void TestGetLists()
    {
        library = new Library();

        List<BookList> expected = new()
        {
            new BookList("test1", "user1"),
            new BookList("test2", "user2"),
            new BookList("test3", "user3")
        };

        library.NewBookList("test1", "user1");
        library.NewBookList("test2", "user2");
        library.NewBookList("test3", "user3");

        List<BookList> results = library.GetBookLists();

        foreach (BookList result in results)
        {
            Assert.True(expected.Count(x => x.GetName() == result.GetName()) == 1);
        }
    }

    [Test]
    public void TestChangeListName()
    {
        bool result = library.ChangeListName("testList", "test1");

        Assert.True(result);
    }

    [Test]
    public void TestChangeReadStatus()
    {
        const string testStatus = "Dropped";

        library.AddBook("testList", "test1", "admin", 157, 1999, "Finished");
        library.ChangeReadStatus(testStatus, "testList", "test1");

        Assert.AreEqual(testStatus, library.GetBook("test1").GetReadingStatus());
    }
}