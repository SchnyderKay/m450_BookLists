namespace BookLibrary;

public class Book
{
    /// <summary>
    /// Name of book
    /// </summary>
    private readonly string name;

    /// <summary>
    /// Name of book author
    /// </summary>
    private readonly string author;

    /// <summary>
    /// Year in which book was published
    /// </summary>
    private readonly int publishedYear;

    /// <summary>
    /// Amount of pages in book
    /// </summary>
    private readonly int pages;

    /// <summary>
    /// Read status of book (Reading, Pending, Finished, Dropped, Unknown)
    /// </summary>
    private Status readStatus;

    /// <summary>
    /// Read Status enum (Reading, Pending, Finished, Dropped, Unknown)
    /// </summary>
    private enum Status
    {
        Reading,
        Dropped,
        Pending,
        Finished,
        Unknown
    }

    /// <summary>
    /// Create new book
    /// </summary>
    /// <param name="name">Name of book</param>
    /// <param name="author">Name of author</param>
    /// <param name="publishedYear">Year in which book was published</param>
    /// <param name="pages">Amount of pages in bok</param>
    /// <param name="readingStatus">Read status of book (Reading, Pending, Dropped, Finished, Unknown)</param>
    public Book(string name, string author, int publishedYear, int pages, string readingStatus)
    {
        this.name = name;
        this.author = author;
        this.publishedYear = publishedYear;
        this.pages = pages;

        readStatus = readingStatus switch
        {
            "Reading" => Status.Reading,
            "Dropped" => Status.Dropped,
            "Pending" => Status.Pending,
            "Finished" => Status.Finished,
            _ => Status.Unknown
        };
    }

    /// <summary>
    /// Change read status of book
    /// </summary>
    /// <param name="readingStatus">new read status of book (Reading, Pending, Dropped, Finished, Unknown)</param>
    public void ChangeReadStatus(string readingStatus)
    {
        readStatus = readingStatus switch
        {
            "Reading" => Status.Reading,
            "Dropped" => Status.Dropped,
            "Pending" => Status.Pending,
            "Finished" => Status.Finished,
            _ => Status.Unknown
        };
    }

    /// <summary>
    /// Get Name of book
    /// </summary>
    /// <returns>string name of book</returns>
    public string GetName()
    {
        return name;
    }

    /// <summary>
    /// Get name of author
    /// </summary>
    /// <returns>string name of author</returns>
    public string GetAuthor()
    {
        return author;
    }

    /// <summary>
    /// Get year in which book was published
    /// </summary>
    /// <returns>int publishing year</returns>
    public int GetPublishedYear()
    {
        return publishedYear;
    }

    /// <summary>
    /// Get amount of pages in book
    /// </summary>
    /// <returns>int amount of pages</returns>
    public int GetPages()
    {
        return pages;
    }

    /// <summary>
    /// Get reading status of book (Pending, Reading, Dropped, Finished, Unknown)
    /// </summary>
    /// <returns>string reading status</returns>
    public string GetReadingStatus()
    {
        return readStatus.ToString();
    }
}