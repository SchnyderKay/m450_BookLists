namespace BookLibrary;
public class Library
{
    private readonly List<BookList> bookLists = new();

    public bool NewBookList(string name, string creator)
    {
        BookList bookList = new(name, creator);

        if (bookLists.Any(existingList => existingList.GetName() == name))
        {
            return false;
        }

        bookLists.Add(bookList);
        return bookLists.Contains(bookList);
    }

    public bool RemoveBookList(string name)
    {
        BookList bookList = bookLists.First(x => x.GetName() == name);
        bookLists.Remove(bookList);

        return !bookLists.Contains(bookList);
    }

    public bool ChangeListName(string oldName, string newName)
    {
        BookList bookList = bookLists.First(x => x.GetName() == oldName);

        bookList.ChangeName(newName);

        return bookLists.Contains(bookList);
    }

    public bool AddBook(string listName, string name, string author, int pages, int publishingYear, string readingStatus)
    {
        BookList list = bookLists.First(x => x.GetName() == listName);

        list.AddBook(name, author, pages, publishingYear, readingStatus);

        return true;
    }

    public bool RemoveBook(string listName, string bookName)
    {
        BookList list = bookLists.First(x => x.GetName().Equals(listName));

        return list.RemoveBook(bookName);
    }

    public void ChangeReadStatus(string readStatus, string listName, string bookName)
    {
        BookList list = bookLists.First(x => x.GetName().Equals(listName));

        list.ChangeReadStatus(bookName, readStatus);
    }

    public Book GetBook(string bookName)
    {
        List<Book> book = bookLists.Select(list => list.GetBookByName(bookName)).ToList();

        return book.First();
    }

    public BookList GetBookList(string listName)
    {
        return bookLists.Count > 0 ? bookLists.First(x => x.GetName().Equals(listName)) : null!;
    }

    public List<BookList> GetBookLists()
    {
        return bookLists;
    }
}