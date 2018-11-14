using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using MyLibrary.Domain;
using MyLibrary.Exception;

namespace MyLibrary.Business
{
    public class Library
    {
        private ConcurrentBag<IBook> _availableBooks = new ConcurrentBag<IBook>();
        private IList<Librarian> _librarians = new List<Librarian>();
        private static Random _rand = new Random();
        private Semaphore _queue = new Semaphore(0, 10);

        public Library()
        {
            GenerateSomeBooks();
        }

        public IBook GetRandomBook()
        {
            if (_availableBooks.TryTake(out var book))
            {
                return book;
            }
            throw new BookNotAvailableException();
        }

        public void RentBook(Person person, IBook book)
        {
            _queue.WaitOne();

            var librarian = _librarians.First(x => x.IsAvailable);
            librarian.Rent(person, book);
        }

        public void ReturnBook(Person person, IBook book)
        {
            _queue.WaitOne();

            var librarian = _librarians.First(x => x.IsAvailable);
            librarian.Return(person, book);
        }

        public void ReturnBook(IBook book)
        {
            _availableBooks.Add(book);
        }

        public void Release()
        {
            _queue.Release(1);
        }

        public void AddLibrarian(Librarian librarian)
        {
            librarian.AddLibrary(this);
            _librarians.Add(librarian);
            Release();
        }

        public void GenerateSomeBooks()
        {
            _availableBooks.Add(new ChildrenBook { Description = "Super awesome book 1", Genre = EGenre.Thriller, Title = "Awesome book 1!" });
            _availableBooks.Add(new ChildrenBook { Description = "Super awesome book 2", Genre = EGenre.Thriller, Title = "Awesome book 2!" });
            _availableBooks.Add(new ChildrenBook { Description = "Super awesome book 3", Genre = EGenre.Thriller, Title = "Awesome book 3!" });
        }
    }
}