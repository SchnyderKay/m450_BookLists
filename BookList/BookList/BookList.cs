using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BookList
    {
        private string Name;
        private string? Creator;
        private List<Book> Books = new();


        public BookList(string name, string? creator)
        {
            Name = name;
            Creator = creator;
        }

        public bool AddBook(string bookName, string author, int publishedYear, int pages, string readingStatus)
        {
            Book book = new(bookName, author, publishedYear, pages, readingStatus);
            Books.Add(book);

            return Books.Contains(book);
        }

        public bool RemoveBook(string bookName)
        {
            Book book = Books.Find(x => x.GetName().Equals(bookName))!;

            Books.Remove(book);

            return !Books.Contains(book);
        }

        public Book GetBookByName(string name)
        {
            return Books.Find(x => x.GetName().Equals(name))!;
        }

        public void ChangeReadStatus(string name, string readingStatus)
        {
            Book book = Books.Find(x => x.GetName().Equals(name))!;

            book.ChangeReadStatus(readingStatus);
        }

        public void ChangeName(string name)
        {
            Name = name;
        }


        public string GetName()
        {
            return Name;
        }

        public string? GetCreator()
        {
            return Creator;
        }

        public List<Book> GetBooks()
        {
            return Books;
        }
    }
}
