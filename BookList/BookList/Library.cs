using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLibrary
{
    public class Library
    {
        private List<BookList> bookLists = new();

        public bool NewBookList(string name, string? creator)
        {
            BookList bookList = new BookList(name, creator);

            foreach (BookList existingList in bookLists)
            {
                if (existingList.GetName() == name)
                {
                    return false;
                }
            }

            bookLists.Add(bookList);
            return bookLists.Contains(bookList);
        }

        public bool RemoveBookList(string name)
        {
            if (!bookLists.Exists(x => x.GetName() == name))
            {
                return false;
            }

            BookList bookList = bookLists.Find(x => x.GetName() == name)!;
            bookLists.Remove(bookList);

            return !bookLists.Contains(bookList);
        }

        public bool ChangeListName(string oldName, string newName)
        {
            if (bookLists.Exists(x => x.GetName() == newName) || !bookLists.Exists(x => x.GetName() == oldName))
            {
                return false;
            }

            BookList bookList = bookLists.Find(x => x.GetName() == oldName)!;

            bookList.ChangeName(newName);

            return bookLists.Contains(bookList);
        }

        public bool AddBook(string listName, string bookName, string author, int pages, int publishingYear, string readingStatus)
        {
            if (!bookLists.Exists(x => x.GetName() == listName))
            {
                return false;
            }

            BookList list = bookLists.Find(x => x.GetName() == listName)!;

            if (list.GetBooks().Exists(x => x.GetName() == bookName))
            {
                return false;
            }

            list.AddBook(bookName, author, pages, publishingYear, readingStatus);

            return true;
        }

        public bool RemoveBook(string listName, string bookName)
        {
            if (!bookLists.Exists(x => x.GetName() == listName))
            {
                return false;
            }

            BookList list = bookLists.Find(x => x.GetName().Equals(listName))!;

            if (!list.GetBooks().Exists(x => x.GetName() == bookName))
            {
                return false;
            }

            return list.RemoveBook(bookName);
        }

        public void ChangeReadStatus(string readStatus, string listName, string bookName)
        {
            if (!bookLists.Exists(x => x.GetName() == listName))
            {
                return;
            }

            BookList list = bookLists.Find(x => x.GetName().Equals(listName))!;

            if (!list.GetBooks().Exists(x => x.GetName() == bookName))
            {
                return;
            }

            list.ChangeReadStatus(bookName, readStatus);
        }

        public List<Book> GetBook(string bookName)
        {
            List<Book> book = new();
            foreach (BookList list in bookLists)
            {
                book.Add(list.GetBookByName(bookName));
            }

            return book;
        }

        public Book GetBookFromList(string listName, string bookName)
        {
            if (bookLists.Exists(x => x.GetName() == listName))
            {
                BookList list = bookLists.Find(x => x.GetName() == listName)!;

                return list.GetBookByName(bookName);
            }

            return null!;
        }

        public BookList GetBookList(string listName)
        {
            return bookLists.Find(x => x.GetName().Equals(listName))!;
        }

        public List<BookList> GetBookLists()
        {
            return bookLists;
        }
    }
}