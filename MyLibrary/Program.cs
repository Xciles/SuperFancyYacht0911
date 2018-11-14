using System;
using System.Collections;
using System.Threading.Tasks;
using MyLibrary.Business;
using MyLibrary.Exception;

namespace MyLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = new Library();
            library.AddLibrarian(new Librarian());
            library.AddLibrarian(new Librarian());

            Task.Factory.StartNew(async (s) => { await SimulatePerson(s); }, library, TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(async (s) => { await SimulatePerson(s); }, library, TaskCreationOptions.LongRunning);
            Task.Factory.StartNew(async (s) => { await SimulatePerson(s); }, library, TaskCreationOptions.LongRunning);

            Console.ReadKey();
        }

        private static async Task SimulatePerson(object o)
        {
            var name = Guid.NewGuid().ToString().Split('-')[0];
            var person = new Person() { Name = name};
            person.EnterLibrary((Library)o);

            var random = new Random();
            var iterations = 0;

            while (true)
            {
                if (!person.HasRentedBooks() || (person.HasRentedBooks() && random.Next(3) < 2))// 
                {
                    try
                    {
                        var result = person.RentNewBook();
                        Console.WriteLine($"Person {person.Name} rented a book: {result}!");
                    }
                    catch (BookNotAvailableException)
                    {
                        Console.WriteLine($"Person {person.Name} could not find a book!");
                    }
                }
                else
                {
                    var result = person.ReturnBook();
                    Console.WriteLine($"Person {person.Name} returned a book: {result}!");
                }

                if (iterations > 10) break;
                iterations++;

                await Task.Delay(random.Next(500, 1000));
            }

            person.LeaveLibrary();
        }
    }
}
