namespace BookLibrary
{
    public class Book
    {
        private string Name;
        private string Author;
        private int PublishedYear;
        private int Pages;
        private Status ReadStatus;
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
            Name = name;
            Author = author;
            PublishedYear = publishedYear;
            Pages = pages;

            ReadStatus = readingStatus switch
            {
                "Reading" => Status.Reading,
                "Dropped" => Status.Dropped,
                "Pending" => Status.Pending,
                "Finished" => Status.Finished,
                _ => Status.Unknown,
            };
        }


        public void ChangeReadStatus(string readingStatus)
        {
            ReadStatus = readingStatus switch
            {
                "Reading" => Status.Reading,
                "Dropped" => Status.Dropped,
                "Pending" => Status.Pending,
                "Finished" => Status.Finished,
                _ => Status.Unknown,
            };
        }

        public string GetName()
        {
            return Name;
        }

        public string GetAuthor()
        {
            return Author;
        }

        public int GetPublishedYear()
        {
            return PublishedYear;
        }

        public int GetPages()
        {
            return Pages;
        }

        public string GetReadingStatus()
        {
            return ReadStatus.ToString();
        }

    }
}
