using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            //var result = GetEvens(list);



            var evens = (from n in list
                         where IsEven(n)
                         select n).ToList();

            // Defered Exe

            list.Add(10);

            foreach (var e in evens)
            {
                Console.WriteLine(e);
            }

            //list.Add(10);
            //Console.WriteLine("=============");
            //foreach (var e in evens)
            //{
            //    Console.WriteLine(e);
            //}
        }

        public static bool IsEven(int n)
        {
            Console.WriteLine("Checking IsEven....");
            return (n % 2 == 0);
        }

        public static IEnumerable<int> GetEvens(List<int> list)
        {
            var evens = (from e in list
                         where e % 2 == 0
                         select e).ToList();
            // Immediate exe
            return evens;
        }
    }
}
