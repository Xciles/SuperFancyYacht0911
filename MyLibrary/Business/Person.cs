using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLibrary.Business
{
    public class Person
    {
        private Library _currentLibrary;
        private IList<IBook> _books = new List<IBook>();
        public string Name { get; set; }

        public void EnterLibrary(Library library)
        {
            Console.WriteLine($"{Name}, entered the library");
            _currentLibrary = library;
        }

        public void LeaveLibrary()
        {
            Console.WriteLine($"{Name}, left the library");
            _currentLibrary = null;
        }

        public bool RentNewBook()
        {
            var book = _currentLibrary.GetRandomBook();
            _currentLibrary.RentBook(this, book);
            _books.Add(book);
            return true;
        }

        public bool ReturnBook()
        {
            var bookToReturn = _books.First();
            _books.Remove(bookToReturn);
            _currentLibrary.ReturnBook(this, bookToReturn);
            return true;
        }

        public bool HasRentedBooks()
        {
            return _books.Any();
        }
    }
}