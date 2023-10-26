using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BookLibraryMain
    {
        static public void Main(String[] args)
        {
            Console.WriteLine("Main Method");

            Library library = new Library();

            library.NewBookList("testList", "admin");

            library.AddBook("testList", "book", "tolkien", 11, 1999, "Reading");
        }
    }
}
