using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyLibrary.Business
{
    public class Librarian
    {
        public string Name { get; set; }
        private int _delayInterval { get; set; } = 100;
        public bool IsAvailable { get; set; } = true;
        private Library _currentLibrary;

        private static Dictionary<Person, IList<IBook>> _rentedBooks = new Dictionary<Person, IList<IBook>>();

        public void AddLibrary(Library library)
        {
            _currentLibrary = library;
        }

        public void Rent(Person person, IBook book)
        {
            if (_rentedBooks.ContainsKey(person))
            {
                _rentedBooks[person].Add(book);
            }
            else
            {
                _rentedBooks.Add(person, new List<IBook> { book });
            }

            Task.Run(async () =>
            {
                await Task.Delay(_delayInterval);
                _currentLibrary.Release();
            });
        }

        public void Return(Person person, IBook book)
        {
            if (_rentedBooks.ContainsKey(person))
            {
                _rentedBooks[person].Remove(book);
            }

            _currentLibrary.ReturnBook(book);

            Task.Run(async () =>
            {
                await Task.Delay(_delayInterval);
                _currentLibrary.Release();
            });
        }
    }
}