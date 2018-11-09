using System;
using System.IO;

namespace SuperFancyYacht0911
{
    public class Animal
    {
        public virtual int NumberOfLegs { get; set; } = 4;

        public virtual void PrintSomething()
        {
            Console.WriteLine("Printing something from Animal");
        }
    }

    public class Mammal : Animal
    {
        public override int NumberOfLegs { get; set; } = 8;

        public override void PrintSomething()
        {
            Console.WriteLine("Printing something from Mammal");
        }

        public override string ToString()
        {
            return "Hallo";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Animal animal = new Mammal();
            animal.PrintSomething();


            var text = animal.ToString();
            var ms = new MemoryStream();
            var a = ms.ToString();

            using (var stream = File.OpenText(""))
            {
                var t = stream.ToString();
            }

        }
    }


    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");

    //        var i = 1;
    //        Console.Write(i);
    //        Console.Write(i++);
    //        Console.Write(++i);

    //        Console.Write(i = i + 1);
    //        Console.Write(i);

    //        var var = 0;
    //        string name = "";

    //        string dezeString = "";
    //        String dezeString2 = "";




    //        Console.ReadKey();
    //    }


    //}
}
