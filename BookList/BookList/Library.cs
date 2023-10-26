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

        public bool NewBookList(string name, string creator)
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
            BookList bookList = bookLists.Where(x => x.GetName() == name).First();
            bookLists.Remove(bookList);

            return !bookLists.Contains(bookList);
        }

        public bool ChangeListName(string oldName, string newName)
        {
            BookList bookList = bookLists.Where(x => x.GetName() == oldName).First();

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
            List<Book> book = new();
            foreach (BookList list in bookLists)
            {
                book.Add(list.GetBookByName(bookName));
            }

            return book.First();
        }

        public BookList GetBookList(string listName)
        {
            return bookLists.First(x => x.GetName().Equals(listName));
        }
    }
}