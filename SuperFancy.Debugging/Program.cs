using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SuperFancy.Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            Main1();
            Main2();
            Main3();
            Main4();
            Main5();
            Main6();
            Main7();
            Main8();
            Main9();
            Main10();
            Main11();
        }

        private static void Main1()
        {
            // break
            // watch
            int a = 1, b = 1, c = 3;
            int d = a + c - b;

            Console.WriteLine(d);
        }

        private static void Main2()
        {
            // step 
            // Move
            int a = 1;
            a = a * 1;
            a = a - 3;
            a = a * 4;

            Console.WriteLine(a);
        }

        private static void Main3()
        {
            // method
            // continue
            int a = 1;
            int b = 3;
            int result = Multiply(a, b);

            Console.WriteLine(result);
        }

        static int Multiply(int a, int b)
        {
            return a * b;
        }

        private static void Main4()
        {
            // Condition
            // hit count
            for (int i = 0; i < 10_000; i++)
            {
                Console.WriteLine("i is " + i);
            }
        }

        private static void Main5()
        {
            // Exception
            int[] numbers = new int[2];
            try
            {
                numbers[0] = 11;
                numbers[1] = 22;
                numbers[2] = 33;

                foreach (int i in numbers)
                {
                    Console.WriteLine(i);
                }
            }
            catch
            {
                Console.WriteLine("Oops");
            }
            Console.ReadLine();
        }

        private static void Main6()
        {
            // Exception settings
            int[] numbers = new int[2];
            try
            {
                numbers[0] = 11;
                numbers[1] = 22;
                numbers[2] = 33;

                foreach (int i in numbers)
                {
                    Console.WriteLine(i);
                }
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Oops");
            }
            catch
            {
                Console.WriteLine("Oops");
            }
            Console.ReadLine();
        }

        private static void Main7()
        {
            // ObjectId
            var class1 = new MyClass { Name = "Instance 1" };
            var class2 = new MyClass { Name = "Instance 2" };

            MyMethod(class1, class2);

            Console.ReadLine();
        }

        public class MyClass
        {
            public string Name { get; set; }
        }

        public static void MyMethod(MyClass myClass, MyClass myClass2)
        {
            myClass.Name += " - Method";
            MyMethod2(myClass);
            myClass2.Name += " - Method";
        }

        public static void MyMethod2(MyClass myClass)
        {
            myClass.Name += " - Method2";
        }

        private static void Main8()
        {
            // Inner breakpoint
            Task.Run(() => Console.WriteLine("Hello"));

            //Task.Run(() =>
            //{
            //    Console.WriteLine("Hello");
            //});

            Console.ReadLine();
        }

        private static void Main9()
        {
            // deadlock
            object lockA = new object();
            object lockB = new object();

            var up = Task.Run(() =>
            {
                lock (lockA)
                {
                    Thread.Sleep(1000);
                    lock (lockB)
                    {
                        Console.WriteLine("Locked A and B");
                    }
                }
            });

            lock (lockB)
            {
                Thread.Sleep(1000);
                lock (lockA)
                {
                    Console.WriteLine("Locked A and B");
                }
            }
            up.Wait();

            Console.ReadLine();
        }

        private static void Main10()
        {
            Task theTask = ProcessAsync();
            int x = 0;  // set breakpoint
            theTask.Wait();
        }

        static async Task ProcessAsync()
        {
            var result = await DoSomethingAsync();  // set breakpoint

            int y = 0;  // set breakpoint
        }

        static async Task<int> DoSomethingAsync()
        {
            await Task.Delay(1000);
            return 5;
        }

        private static void Main11()
        {
            ProcessAsync2().Wait();
        }

        static async Task ProcessAsync2()
        {
            var theTask = DoSomethingAsync2();
            int z = 0;
            var result = await theTask;
        }

        static async Task<int> DoSomethingAsync2()
        {
            Debug.WriteLine("before");  // Step Out from here
            await Task.Delay(1000);
            Debug.WriteLine("after");
            return 5;
        }
    }

    //public class Program
    //{
    //    static void Main()
    //    {
    //        pcount = Environment.ProcessorCount;
    //        Console.WriteLine("Proc count = " + pcount);
    //        ThreadPool.SetMinThreads(4, -1);
    //        ThreadPool.SetMaxThreads(4, -1);

    //        t1 = new Task(A, 1);
    //        t2 = new Task(A, 2);
    //        t3 = new Task(A, 3);
    //        t4 = new Task(A, 4);
    //        Console.WriteLine("Starting t1 " + t1.Id.ToString());
    //        t1.Start();
    //        Console.WriteLine("Starting t2 " + t2.Id.ToString());
    //        t2.Start();
    //        Console.WriteLine("Starting t3 " + t3.Id.ToString());
    //        t3.Start();
    //        Console.WriteLine("Starting t4 " + t4.Id.ToString());
    //        t4.Start();

    //        Console.ReadLine();
    //    }

    //    static void A(object o)
    //    {
    //        B(o);
    //    }
    //    static void B(object o)
    //    {
    //        C(o);
    //    }
    //    static void C(object o)
    //    {
    //        int temp = (int)o;

    //        Interlocked.Increment(ref aa);
    //        while (aa < 4)
    //        {
    //            ;
    //        }

    //        if (temp == 1)
    //        {
    //            // BP1 - all tasks in C
    //            Debugger.Break();
    //            waitFor1 = false;
    //        }
    //        else
    //        {
    //            while (waitFor1)
    //            {
    //                ;
    //            }
    //        }
    //        switch (temp)
    //        {
    //            case 1:
    //                D(o);
    //                break;
    //            case 2:
    //                F(o);
    //                break;
    //            case 3:
    //            case 4:
    //                I(o);
    //                break;
    //            default:
    //                Debug.Assert(false, "fool");
    //                break;
    //        }
    //    }
    //    static void D(object o)
    //    {
    //        E(o);
    //    }
    //    static void E(object o)
    //    {
    //        // break here at the same time as H and K
    //        while (bb < 2)
    //        {
    //            ;
    //        }
    //        //BP2 - 1 in E, 2 in H, 3 in J, 4 in K
    //        Debugger.Break();
    //        Interlocked.Increment(ref bb);

    //        //after
    //        L(o);
    //    }
    //    static void F(object o)
    //    {
    //        G(o);
    //    }
    //    static void G(object o)
    //    {
    //        H(o);
    //    }
    //    static void H(object o)
    //    {
    //        // break here at the same time as E and K
    //        Interlocked.Increment(ref bb);
    //        Monitor.Enter(mylock);
    //        while (bb < 3)
    //        {
    //            ;
    //        }
    //        Monitor.Exit(mylock);


    //        //after
    //        L(o);
    //    }
    //    static void I(object o)
    //    {
    //        J(o);
    //    }
    //    static void J(object o)
    //    {
    //        int temp2 = (int)o;

    //        switch (temp2)
    //        {
    //            case 3:
    //                t4.Wait();
    //                break;
    //            case 4:
    //                K(o);
    //                break;
    //            default:
    //                Debug.Assert(false, "fool2");
    //                break;
    //        }
    //    }
    //    static void K(object o)
    //    {
    //        // break here at the same time as E and H
    //        Interlocked.Increment(ref bb);
    //        Monitor.Enter(mylock);
    //        while (bb < 3)
    //        {
    //            ;
    //        }
    //        Monitor.Exit(mylock);


    //        //after
    //        L(o);
    //    }
    //    static void L(object oo)
    //    {
    //        int temp3 = (int)oo;

    //        switch (temp3)
    //        {
    //            case 1:
    //                M(oo);
    //                break;
    //            case 2:
    //                N(oo);
    //                break;
    //            case 4:
    //                O(oo);
    //                break;
    //            default:
    //                Debug.Assert(false, "fool3");
    //                break;
    //        }
    //    }
    //    static void M(object o)
    //    {
    //        // breaks here at the same time as N and Q
    //        Interlocked.Increment(ref cc);
    //        while (cc < 3)
    //        {
    //            ;
    //        }
    //        //BP3 - 1 in M, 2 in N, 3 still in J, 4 in O, 5 in Q
    //        Debugger.Break();
    //        Interlocked.Increment(ref cc);
    //        while (true)
    //            Thread.Sleep(500); // for ever
    //    }
    //    static void N(object o)
    //    {
    //        // breaks here at the same time as M and Q
    //        Interlocked.Increment(ref cc);
    //        while (cc < 4)
    //        {
    //            ;
    //        }
    //        R(o);
    //    }
    //    static void O(object o)
    //    {
    //        Task t5 = Task.Factory.StartNew(P, TaskCreationOptions.AttachedToParent);
    //        t5.Wait();
    //        R(o);
    //    }
    //    static void P()
    //    {
    //        Console.WriteLine("t5 runs " + Task.CurrentId.ToString());
    //        Q();
    //    }
    //    static void Q()
    //    {
    //        // breaks here at the same time as N and M
    //        Interlocked.Increment(ref cc);
    //        while (cc < 4)
    //        {
    //            ;
    //        }
    //        // task 5 dies here freeing task 4 (its parent)
    //        Console.WriteLine("t5 dies " + Task.CurrentId.ToString());
    //        waitFor5 = false;
    //    }
    //    static void R(object o)
    //    {
    //        if ((int)o == 2)
    //        {
    //            //wait for task5 to die
    //            while (waitFor5) {; }


    //            int i;
    //            //spin up all procs
    //            for (i = 0; i < pcount - 4; i++)
    //            {
    //                Task t = Task.Factory.StartNew(() => { while (true) ; });
    //                Console.WriteLine("Started task " + t.Id.ToString());
    //            }

    //            Task.Factory.StartNew(T, i + 1 + 5, TaskCreationOptions.AttachedToParent); //scheduled
    //            Task.Factory.StartNew(T, i + 2 + 5, TaskCreationOptions.AttachedToParent); //scheduled
    //            Task.Factory.StartNew(T, i + 3 + 5, TaskCreationOptions.AttachedToParent); //scheduled
    //            Task.Factory.StartNew(T, i + 4 + 5, TaskCreationOptions.AttachedToParent); //scheduled
    //            Task.Factory.StartNew(T, (i + 5 + 5).ToString(), TaskCreationOptions.AttachedToParent); //scheduled

    //            //BP4 - 1 in M, 2 in R, 3 in J, 4 in R, 5 died
    //            Debugger.Break();
    //        }
    //        else
    //        {
    //            Debug.Assert((int)o == 4);
    //            t3.Wait();
    //        }
    //    }
    //    static void T(object o)
    //    {
    //        Console.WriteLine("Scheduled run " + Task.CurrentId.ToString());
    //    }
    //    static Task t1, t2, t3, t4;
    //    static int aa = 0;
    //    static int bb = 0;
    //    static int cc = 0;
    //    static bool waitFor1 = true;
    //    static bool waitFor5 = true;
    //    static int pcount;
    //    static Program mylock = new Program();
    //}
}

