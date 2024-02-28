using System;
using System.Collections.Generic;

namespace CollectionsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // dynamic untyped collection
            List<int> numbers = new List<int>(10);

            Console.WriteLine($"Capacity {numbers.Capacity}");

            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);
            numbers.Add(1);





            numbers.TrimExcess();
            Console.WriteLine($"Capacity {numbers.Capacity}");

            Stack<int> stack = new Stack<int>();
            // add
            stack.Push(1);
            //read
            int x = stack.Pop(); //read & remove


            Queue<int> q = new Queue<int>();
            // add
            q.Enqueue(x);
            // read and remove
            q.Dequeue();
            // only read
            q.Peek();

            // key - value

            Dictionary<int, string> results = new Dictionary<int, string>();
            results.Add(111, "Pass");
            results.Add(222, "Fail");
            // read
            Console.WriteLine(results[222]);

            HashSet<int> visited = new HashSet<int>();
            visited.Add(111);
            visited.Add(111);
        }
    }
}
