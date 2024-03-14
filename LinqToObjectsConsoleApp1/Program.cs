using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqToObjectsConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = new List<int>() { 1, 22, 13, 44, 5, 16, 47, 68, 98 };
            // get all even numbers into separate collection and display

            // table: numbers
            // column: number
            // sql select: select top 3 number from numbers where number mod 2 = 0 order by number desc limit 3;

            // LINQ Expression - Linq to Objects

            var evensList = (from number in numbers
                             where number % 2 == 0
                             orderby number descending
                             select number).Take(3);// top 3;


            //List<int> evens = new List<int>();
            //foreach (int number in numbers)
            //{
            //    if (number % 2 == 0)
            //    {
            //        evens.Add(number);
            //    }
            //}

            // display
            foreach (var item in evensList)
            {
                Console.WriteLine(item);
            }

        }
    }
}
