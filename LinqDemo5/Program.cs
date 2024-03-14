using System.Collections.Generic;
using System.Linq;

namespace LinqDemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>() { 12, 4, 2, 45, 65, 3, 5, 7, 96, 56, 34 };

            // get all evens in desc order and display
            // linq expression
            var result = from n in list
                         where n % 2 == 0
                         orderby n descending
                         select n;

            // linq with extension methods
            var result2 = list
                .Where(n => n % 2 == 0)
                .OrderByDescending(n => n)
                .Select(n => n);
        }
    }
}
