namespace BookLibrary;
public class BookList
{
    /// <summary>
    /// Name of the List
    /// </summary>
    private string name;

    /// <summary>
    /// Name of the creator
    /// </summary>
    private readonly string creator;

    /// <summary>
    /// List of Books
    /// </summary>
    private readonly List<Book> books = new();

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="name">Name of List</param>
    /// <param name="creator">Name of Creator</param>
    public BookList(string name, string creator)
    {
        this.name = name;
        this.creator = creator;
    }

    /// <summary>
    /// Add book if book with same name doesn't exist
    /// </summary>
    /// <param name="bookName">Name of the book</param>
    /// <param name="author">Name of the author</param>
    /// <param name="publishedYear">year in which book was published</param>
    /// <param name="pages">amount of pages in the book</param>
    /// <param name="readingStatus">read status of book (Reading, Pending, Finished, Dropped, Unknown)</param>
    /// <returns>Bool if book was added</returns>
    public bool AddBook(string bookName, string author, int publishedYear, int pages, string readingStatus)
    {
        Book book = new(bookName, author, publishedYear, pages, readingStatus);

        if (books.Any(existingBook => existingBook.GetName() == name))
        {
            return false;
        }

        books.Add(book);

        return books.Contains(book);
    }

    /// <summary>
    /// Remove book with given name
    /// </summary>
    /// <param name="bookName">Name of the Book</param>
    /// <returns>bool if Book was removed</returns>
    public bool RemoveBook(string bookName)
    {
        Book book = books.FirstOrDefault(x => x.GetName().Equals(bookName))!;

        books.Remove(book);

        return !books.Contains(book);
    }

    /// <summary>
    /// Get book by name
    /// </summary>
    /// <param name="bookName">Name of the book</param>
    /// <returns>Book with given name</returns>
    public Book GetBookByName(string bookName)
    {
        return books.FirstOrDefault(x => x.GetName().Equals(bookName))!;
    }

    /// <summary>
    /// Change read status of book
    /// </summary>
    /// <param name="bookName">name of Book</param>
    /// <param name="readingStatus">read status of book (Reading, Pending, Finished, Dropped, Unknown)</param>
    public void ChangeReadStatus(string bookName, string readingStatus)
    {
        Book book = books.FirstOrDefault(x => x.GetName().Equals(bookName))!;

        book.ChangeReadStatus(readingStatus);
    }

    /// <summary>
    /// Change name of List
    /// </summary>
    /// <param name="newName">new List name</param>
    public void ChangeName(string newName)
    {
        name = newName;
    }

    /// <summary>
    /// Get Name of List
    /// </summary>
    /// <returns>string name of List</returns>
    public string GetName()
    {
        return name;
    }

    /// <summary>
    /// Get name of creator
    /// </summary>
    /// <returns>string name of creator</returns>
    public string GetCreator()
    {
        return creator;
    }

    /// <summary>
    /// Get all books in List
    /// </summary>
    /// <returns>List of Books</returns>
    public List<Book> GetBooks()
    {
        return books;
    }
}