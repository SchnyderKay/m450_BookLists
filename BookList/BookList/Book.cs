namespace BookLibrary;

public class Book
{
    private readonly string name;
    private readonly string author;
    private readonly int publishedYear;
    private readonly int pages;
    private Status readStatus;
    private enum Status
    {
        Reading,
        Dropped,
        Pending,
        Finished,
        Unknown
    }

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

    public string GetName()
    {
        return name;
    }

    public string GetAuthor()
    {
        return author;
    }

    public int GetPublishedYear()
    {
        return publishedYear;
    }

    public int GetPages()
    {
        return pages;
    }

    public string GetReadingStatus()
    {
        return readStatus.ToString();
    }
}