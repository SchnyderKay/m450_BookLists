namespace BookLibrary;
public class Library
{
    /// <summary>
    /// List of Lists containing Books
    /// </summary>
    private readonly List<BookList> bookLists = new();

    /// <summary>
    /// Create a new List if List with same name doesn't exist
    /// </summary>
    /// <param name="name">the name of the new List</param>
    /// <param name="creator">The name of the Creator</param>
    /// <returns>Bool if List was added</returns>
    public bool AddBookList(string name, string creator)
    {
        BookList bookList = new(name, creator);

        if (bookLists.Any(x => x.GetName() == name))
        {
            return false;
        }

        bookLists.Add(bookList);
        return bookLists.Contains(bookList);
    }

    /// <summary>
    /// Removes the List with given name
    /// </summary>
    /// <param name="name">Name of the List</param>
    /// <returns>Bool if List was removed</returns>
    public bool RemoveBookList(string name)
    {
        BookList bookList = bookLists.First(x => x.GetName() == name);
        bookLists.Remove(bookList);

        return !bookLists.Contains(bookList);
    }

    /// <summary>
    /// Changes name of the List if List with same name doesn't exist
    /// </summary>
    /// <param name="oldName">current list name</param>
    /// <param name="newName">new list name</param>
    /// <returns>Bool if name was changed</returns>
    public bool ChangeListName(string oldName, string newName)
    {
        BookList bookList = bookLists.First(x => x.GetName() == oldName);

        if (bookLists.Any(existingList => existingList.GetName() == newName))
        {
            return false;
        }

        bookList.ChangeName(newName);

        return bookLists.Contains(bookList);
    }

    /// <summary>
    /// Adds Book To List if Book with name doesn't exist in list
    /// </summary>
    /// <param name="listName">name of the list</param>
    /// <param name="name">name of the Book</param>
    /// <param name="author"></param>
    /// <param name="pages">name of the book author</param>
    /// <param name="publishingYear">year in which book was published</param>
    /// <param name="readingStatus">read status of book (Reading, Pending, Finished, Dropped, Unknown)</param>
    /// <returns>Bool if book was added</returns>
    public bool AddBook(string listName, string name, string author, int pages, int publishingYear, string readingStatus)
    {
        BookList list = bookLists.First(x => x.GetName() == listName);

        list.AddBook(name, author, pages, publishingYear, readingStatus);

        return true;
    }

    /// <summary>
    /// Removes Book in given list
    /// </summary>
    /// <param name="listName">Name of the list containing the book</param>
    /// <param name="bookName">Name of the Book to remove</param>
    /// <returns>bool if book was removed</returns>
    public bool RemoveBook(string listName, string bookName)
    {
        BookList list = bookLists.First(x => x.GetName().Equals(listName));

        return list.RemoveBook(bookName);
    }

    /// <summary>
    /// Change read status of book in list
    /// </summary>
    /// <param name="readStatus">read status of book (Reading, Finished, Dropped, Pending, Unknown)</param>
    /// <param name="listName">Name of the List containing the book</param>
    /// <param name="bookName">name of the book</param>
    public void ChangeReadStatus(string readStatus, string listName, string bookName)
    {
        BookList list = bookLists.First(x => x.GetName().Equals(listName));

        list.ChangeReadStatus(bookName, readStatus);
    }

    /// <summary>
    /// Get the book by name
    /// </summary>
    /// <param name="bookName">Name of the book</param>
    /// <returns>Book with given name</returns>
    public Book GetBook(string bookName)
    {
        List<Book> book = bookLists.Select(list => list.GetBookByName(bookName)).ToList();

        return book.First();
    }

    /// <summary>
    /// Get the List by name
    /// </summary>
    /// <param name="listName">Name of the List</param>
    /// <returns>Returns List with given name</returns>
    public BookList GetBookList(string listName)
    {
        return bookLists.Count > 0 ? bookLists.First(x => x.GetName().Equals(listName)) : null!;
    }

    /// <summary>
    /// Get all Lists
    /// </summary>
    /// <returns>bookLists</returns>
    public List<BookList> GetBookLists()
    {
        return bookLists;
    }
}