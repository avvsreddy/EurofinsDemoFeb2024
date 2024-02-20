using System;

namespace DataTypesDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {


            int[] a = new int[10];
            int[] b = new int[3] { 1, 2, 3 };
            int[] c = new int[] { 1, 2, 3 };
            int[] d = { 1, 3, 4 };

            //Sum(10, 20);
            Sum("", b);
            Sum("", 10, 20, 30);
            Sum("", 10, 20, 30, 40);
            Sum("", 10);
            Sum("");

            //Print("resume",1,"gray");

            Print("resume", color: "gray", printer: "ltp1");
            Print(printer: "lpts", doc: "invoice");
        }


        static Tuple<int, int> SumMax(int a, int b)
        {
            int m = a > b ? a : b;
            int s = a + b;
            Tuple<int, int> t = new Tuple<int, int>(m, s);
            return (t);
            int sum;
            int max;
            SumMax2(10, 20, out max, out sum);
            Console.WriteLine(sum);
            Console.WriteLine(max);
        }

        static void SumMax2(int a, int b, out int m, out int s)
        {
            //Console.WriteLine(m);
            //
            //
            m = a > b ? a : b;
            s = a + b;
            //Tuple<int, int> t = new Tuple<int, int>(m, s);
            //return (t);
        }

        static int Sum(string str, params int[] numbers)
        {
            return a + b + c + d;
        }

        static void Print(string doc, int copies = 1, string color = "black", string printer = "sd")
        {

        }

    }
}
