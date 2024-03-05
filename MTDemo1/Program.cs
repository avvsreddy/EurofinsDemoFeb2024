using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Seq....
            //Console.WriteLine("Running in seq...");
            //Stopwatch sw = Stopwatch.StartNew();
            //M1();
            //M2();
            //Console.WriteLine(sw.ElapsedMilliseconds);
            //sw = Stopwatch.StartNew();


            //// Using Thread Class
            //Console.WriteLine("Running in Threads...");
            //ThreadStart ts1 = new ThreadStart(M1);
            //Thread t1 = new Thread(ts1);
            //t1.Start();

            //Thread t2 = new Thread(M2);
            //t2.Start();

            //t1.Join();
            //t2.Join();

            //Console.WriteLine(sw.ElapsedMilliseconds);


            //// Using Task Class
            //Console.WriteLine("Running in Task...");
            //sw = Stopwatch.StartNew();
            //Task tt1 = new Task(M1);
            //tt1.Start();
            //Task tt2 = new Task(M2);
            //tt2.Start();
            //tt1.Wait();
            //tt2.Wait();
            //Console.WriteLine(sw.ElapsedMilliseconds);

            //// Using Parallel Class
            //Console.WriteLine("Running in Parallel...");
            //sw = Stopwatch.StartNew();
            //Parallel.Invoke(M1, M2);
            //Console.WriteLine(sw.ElapsedMilliseconds);

            //Console.WriteLine("Running in Parallel Loop...");
            //sw = Stopwatch.StartNew();
            //Parallel.Invoke(M11, M22);
            //Console.WriteLine(sw.ElapsedMilliseconds);\
            Console.WriteLine($"No of Cores {Environment.ProcessorCount}");
            M22();

        }

        static void M1()
        {
            Console.WriteLine($"M1() running in thread id {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                //Console.WriteLine($"M1 {i}");
            }
        }

        static void M2()
        {
            Console.WriteLine($"M2() running in thread id {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
                //Console.WriteLine($"M2 {i}");
            }
        }


        static void M11()
        {
            Console.WriteLine($"M1() running in thread id {Thread.CurrentThread.ManagedThreadId}");
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, i =>
            {
                Thread.Sleep(1000);
                //Console.WriteLine($"M1 {i}");
            });
        }

        static void M22()
        {
            Console.WriteLine($"M2() running in thread id {Thread.CurrentThread.ManagedThreadId}");

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = Environment.ProcessorCount / 2;

            HashSet<int> set = new HashSet<int>();
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 100, options, x =>
            {
                Thread.Sleep(1000);
                Console.WriteLine($"M2 {Thread.CurrentThread.ManagedThreadId}");
                set.Add(Thread.CurrentThread.ManagedThreadId);
            });

            Console.WriteLine("No. of Threads " + set.Count);
        }



    }
}
