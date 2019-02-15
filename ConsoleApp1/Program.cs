using System;
using System.Linq;
using System.Reflection;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var types = Assembly.GetExecutingAssembly().GetTypes();

            var typeOf = typeof(Bla);
            //typeOf.con
            var blaAct = Activator.CreateInstance(typeOf, new Bli());
            var blaAct2 = Activator.CreateInstance<Bla>();

            var a = (Bla)Activator.CreateInstance(typeOf, new Bli());

            var b = 2;

            var bla = new Bla(new Bli());

            var dates = DateTime.UtcNow;
            var date = DateTime.Now;

            Console.ReadKey();
        }
    }


    public class Bla
    {
        private readonly Bli _bli;

        public Bla(Bli bli)
        {
            _bli = bli;
        }
    }

    public class Bli
    {

    }
}
