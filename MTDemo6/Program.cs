using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace MTDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BigData bigData = new BigData();
            //bigData.Fill(); // fill 1M
            //bigData.Fill();

            Parallel.Invoke(bigData.Fill, bigData.Fill);

            Console.WriteLine(bigData.Stack.Count);
        }
    }

    class BigData
    {
        //public Stack<int> Stack = new Stack<int>();
        public ConcurrentStack<int> Stack = new ConcurrentStack<int>();

        //[MethodImpl(MethodImplOptions.Synchronized)] // if every line in a method is critical section
        public void Fill()
        {
            // fill 1M numbers into stack
            for (int i = 1; i <= 1000000; i++)
            {
                //Monitor.Enter(this);
                //lock (this)
                //{
                Stack.Push(i); // critical section
                               //}
                               //sdfsdfs
                               //sdfsdf
                               //Monitor.Exit(this);


            }

        }
    }
}
