using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SuperAwesome.ConsoleEvening
{
    class Program
    {
        public class MyClass
        {
            public int MyInt { get; set; }
        }

        static void Main(string[] args)
        {
            int i = 0;
            MyClass myClass = new MyClass();

            Console.WriteLine(i);
            Console.WriteLine(myClass.MyInt);
            i++;
            myClass.MyInt++;
            MyMethod(ref i);
            MyMethod(myClass);

            Console.WriteLine(i);
            Console.WriteLine(myClass.MyInt);

            string s = "Hallo";
            s += " iedereen";
            s = s + " iedereen";

            StringBuilder sb = new StringBuilder();
            sb.Append("Hallo");
            sb.Append(" iedereen");
            sb.Append(" iedereen");

            Bla(23253.22f);
            Console.ReadKey();
        }

        private static int Bla(float flo)
        {
            object myRef = flo;
            int myInt = (int)(float) myRef;
            Console.WriteLine(myInt);
            return myInt;
        }

        private static void MyMethod(ref int i)
        {
            i++;
        }

        private static void MyMethod(MyClass i)
        {
            i.MyInt++;
        }
    }

    //class Program
    //{
    //    private static ConcurrentBag<string> _strings = new ConcurrentBag<string>();
    //    private static object _lockObject = new object();

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");

    //        Thread t1 = new Thread(Start);
    //        Thread t2 = new Thread(Start);
    //        Thread t3 = new Thread(Start);
    //        Thread t4 = new Thread(Start);
    //        Thread t5 = new Thread(Start);
    //        Thread t6 = new Thread(Start);


    //        Console.ReadKey();
    //    }

    //    private static void Start(object obj)
    //    {
    //        Task.Delay(1000);

    //        var rand = new Random();
    //        lock (_lockObject)
    //        {
    //            _strings.Add(rand.Next(100, 10).ToString());
    //        }


    //        Task.Delay(1000);
    //    }
    //}
}
