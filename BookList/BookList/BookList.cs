namespace BookLibrary;
public class BookList
{
    private string name;
    private readonly string creator;
    private readonly List<Book> books = new();

    public BookList(string name, string creator)
    {
        this.name = name;
        this.creator = creator;
    }

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

    public bool RemoveBook(string bookName)
    {
        Book book = books.FirstOrDefault(x => x.GetName().Equals(bookName))!;

        books.Remove(book);

        return !books.Contains(book);
    }

    public Book GetBookByName(string bookName)
    {
        return books.FirstOrDefault(x => x.GetName().Equals(bookName))!;
    }

    public void ChangeReadStatus(string bookName, string readingStatus)
    {
        Book book = books.FirstOrDefault(x => x.GetName().Equals(bookName))!;

        book.ChangeReadStatus(readingStatus);
    }

    public void ChangeName(string newName)
    {
        name = newName;
    }

    public string GetName()
    {
        return name;
    }

    public string GetCreator()
    {
        return creator;
    }

    public List<Book> GetBooks()
    {
        return books;
    }
}