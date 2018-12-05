using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperAwesome.Day4
{
    public interface ICarnivore
    {
        void Eat();
    }

    public class Lion : Animal, ICarnivore
    {
        public void Eat()
        {
            
        }
    }

    public class Animal
    {
    }

    public class Carnivore : ICarnivore
    {
        public void Eat()
        {
            this.FightHerbivore();
        }
    }


    public static class Extensions
    {
        public static bool FightHerbivore(this ICarnivore carnivore)
        {
            //var herbivore = Zoo.Instance().FindHerbivore();

            //if (herbivore != null)
            //{
            //    Console.WriteLine($"{carnivore.Name} ate {herbivore.Name}");
            //    carnivore.IsHungry = false;
            //    return true;
            //}

            return false;
        }

        public static int ProperCount<T>(this IList<T> list)
        {
            return list.Count * 2;
        }
    }

    public static class Helper
    {
        public static int ProperCount<T>(IList<T> list)
        {
            return list.Count * 2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<string>();

            var re = list.ProperCount();
            var result = Helper.ProperCount(list);

            foreach (var item in Integers())
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        private static IEnumerable<int> Integers()
        {
            yield return 1;
            // iets doen

            yield return 2;
        }
    }

    //class Program
    //{
    //    private static Queue<string> _queue;
    //    private static BlockingCollection<string> _block;

    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");

    //        Thread.Sleep(1000);
    //        Thread.Sleep(1000);

    //        _block = new BlockingCollection<string>();
    //        _block.Add("String 1");
    //        _block.Add("String 2");
    //        _block.Add("String 3");

    //        Task.Run(() =>
    //        {
    //            var consumingEnumerable = _block.GetConsumingEnumerable();

    //            Parallel.ForEach(consumingEnumerable, new ParallelOptions(), (s) => { Console.WriteLine(s); });

    //            //foreach (var s in consumingEnumerable)
    //            //{
    //            //    Console.WriteLine(s);
    //            //}
    //        });
    //        Thread.Sleep(1000);

    //        _block.Add("String 1");
    //        _block.Add("String 2");
    //        _block.Add("String 3");

    //        _queue = new Queue<string>();
    //        _queue.Enqueue("String 1");
    //        _queue.Enqueue("String 2");
    //        _queue.Enqueue("String 3");

    //        Task.Run(async () =>
    //        {
    //            while (true)
    //            {
    //                if (_queue.TryDequeue(out var s))
    //                {
    //                    Console.WriteLine(s);
    //                }

    //                await Task.Delay(100);
    //            }
    //        });

    //        Thread.Sleep(1000);
    //        _queue.Enqueue("String 4");
    //        _queue.Enqueue("String 5");
    //        _queue.Enqueue("String 6");


    //        Console.ReadKey();
    //    }
    //}
}
