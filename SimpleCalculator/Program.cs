using System;

namespace SimpleCalculator // UI
{
    internal class Program // SRP - UI
    {
        static void Main(string[] args) // SRP = Single Resposibility / UI
        {
            // accept two int numbers, find the max then display
            int fno;
            int sno;
            int max;

            // accept the data
            Console.Write("Enter first number: ");
            fno = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            sno = int.Parse(Console.ReadLine());

            ComputeLibrary.Calculator calc = new ComputeLibrary.Calculator();
            max = calc.FindMax(fno, sno);

            // display the result
            //Console.WriteLine("The maximum of" + fno + " and " + sno + " is " + max);
            //Console.WriteLine("The maximum of {0} and {1} is {2}", fno, sno, max);
            Console.WriteLine($"The maximum of {fno} and {sno} is {max}");
        }



    }


}

