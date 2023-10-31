using BookLibrary;

namespace ConsoleInput;

public class BookLibraryMain
{
    public Library Library = new();

    public static void Main()
    {
        BookLibraryMain main = new();

        while (true)
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("What would you like to do? \n" +
                              "Add List => al \n" +
                              "Remove List => rl \n" +
                              "Change List name=> cl \n" +
                              "Get Lists => l \n" +
                              "Add Book => ab \n" +
                              "Remove Book => rb \n" +
                              "Change read status => cr \n" +
                              "Get Books from List => bl \n" +
                              "Get Book => b \n" +
                              "exit => x");
            string menuInput = Console.ReadLine()!;

            switch (menuInput)
            {
                case "al":
                    main.AddList();
                    break;
                case "rl":
                    main.RemoveList();
                    break;
                case "cl":
                    main.ChangeListName();
                    break;
                case "ab":
                    main.AddBook();
                    break;
                case "rb":
                    main.RemoveBook();
                    break;
                case "cr":
                    main.ChangeReadStatus();
                    break;
                case "bl":
                    main.GetBooksFromList();
                    break;
                case "b":
                    main.GetBook();
                    break;
                case "l":
                    main.GetLists();
                    break;
                case "x":
                    Console.WriteLine("Goodbye, see you later.");
                    return;
            }
        }
    }

    public void AddList()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Add new List:");
        Console.WriteLine("Whats the name of the list?");
        string name = Console.ReadLine()!;

        Console.WriteLine("Whats your name?");
        string creator = Console.ReadLine()!;

        if (Library.NewBookList(name, creator))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("List {0} by {1} successfully created", name, creator);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("List with name {0} already exists", name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void RemoveList()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Remove List:");
        Console.WriteLine("What's the name of the list?");
        string name = Console.ReadLine()!;

        if (Library.RemoveBookList(name))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("List {0} successfully removed", name);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to remove list {0}", name);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void ChangeListName()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Change List name:");
        Console.WriteLine("What's the current list name?");
        string oldName = Console.ReadLine()!;

        Console.WriteLine("What's the new list name?");
        string newName = Console.ReadLine()!;

        if (Library.ChangeListName(oldName, newName))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Successfully changed name from {0} to {1}.", oldName, newName);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to change name from {0} to {1}.", oldName, newName);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void AddBook()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Add book to list:");
        Console.WriteLine("What's the name of the list?");
        string listName = Console.ReadLine()!;

        Console.WriteLine("What's the book name?");
        string bookName = Console.ReadLine()!;

        Console.WriteLine("Who's the author of the book?");
        string author = Console.ReadLine()!;

        Console.WriteLine("What's your read status of the book? (Reading, Dropped, Finished, Pending, Other)");
        string readStatus = Console.ReadLine()!;

        int pages;
        Console.WriteLine("How many pages has the book?");
        while (!Int32.TryParse(Console.ReadLine(), out pages))
        {
            Console.WriteLine("Pleas enter a number of pages! ex. 199");
        }

        int year;
        Console.WriteLine("In which year was the book published?");
        while (!Int32.TryParse(Console.ReadLine(), out year))
        {
            Console.WriteLine("Pleas enter a year! ex. 1857");
        }

        if (Library.AddBook(listName, bookName, author, pages, year, readStatus))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Successfully added book {0}.", bookName);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to add book {0}.", bookName);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void RemoveBook()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Remove book from list:");
        Console.WriteLine("What's the name of the list from which you want to remove the book?");
        string listName = Console.ReadLine()!;

        Console.WriteLine("What's the name of the book?");
        string bookName = Console.ReadLine()!;

        if (Library.RemoveBook(listName, bookName))
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Successfully removed {0} from {1}.", bookName, listName);
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Failed to remove {0} from {1}.", bookName, listName);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    public void ChangeReadStatus()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Change ReadStatus from book:");
        Console.WriteLine("Which list contains the book?");
        string listName = Console.ReadLine()!;

        Console.WriteLine("What's the name of the book?");
        string bookName = Console.ReadLine()!;

        Console.WriteLine("What's the new read status? (Reading, Dropped, Finished, Pending, Other)");
        string readStatus = Console.ReadLine()!;

        Library.ChangeReadStatus(readStatus, listName, bookName);
    }

    public void GetBooksFromList()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Get Books from List:");
        Console.WriteLine("Whats the name of the list?");
        string listName = Console.ReadLine()!;

        List<Book> books = Library.GetBookList(listName).GetBooks();

        foreach (Book book in books)
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("{0} \n" +
                              "Author: {1} \n" +
                              "Pages: {2} \n" +
                              "Published year: {3} \n" +
                              "Read Status: {4} \n",
                book.GetName(),
                book.GetAuthor(),
                book.GetPages(),
                book.GetPublishedYear(),
                book.GetReadingStatus());

        }
    }

    public void GetBook()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Get Book by name:");
        Console.WriteLine("Whats the name of the book?");
        string bookName = Console.ReadLine()!;

        Book book = Library.GetBook(bookName);

        Console.WriteLine("--------------------------");
        Console.WriteLine("{0} \n" +
                          "Author: {1} \n" +
                          "Pages: {2} \n" +
                          "Published year: {3} \n" +
                          "Read Status: {4} \n",
            book.GetName(),
            book.GetAuthor(),
            book.GetPages(),
            book.GetPublishedYear(),
            book.GetReadingStatus());
    }

    public void GetLists()
    {
        Console.WriteLine("----------------------------------------------------------");
        Console.WriteLine("Get Lists:");

        List<BookList> lists = Library.GetBookLists();

        foreach (BookList list in lists)
        {
            Console.WriteLine("--------------------------");

            Console.WriteLine("{0} \n" +
                              "Creator: {1} \n" +
                              "Books: {2}",
                list.GetName(),
                list.GetCreator(),
                list.GetBooks().Count);

        }
    }
}