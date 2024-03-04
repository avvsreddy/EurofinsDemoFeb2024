using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // find the sum
            int sum = list.Sum();
            // find all the even numbers sum
            Func<int, bool> filter = new Func<int, bool>(IsEven);
            int evensSum = list.Where(filter).Sum();
            int evensSum2 = list.Where(IsEven).Sum();

            int evensSum3 = list.Where(delegate (int x)
            {
                return x % 2 == 0;
            }).Sum();

            int evensSum4 = list.Where((int x) =>
            {
                return x % 2 == 0;
            }).Sum();

            int evensSum5 = list.Where((int x) =>
                 x % 2 == 0
            ).Sum();

            int evensSum6 = list.Where(x => x % 2 == 0).Sum();
        }


        public static bool IsEven(int x)
        {
            return x % 2 == 0;
        }

    }
}
