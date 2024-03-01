using System;

namespace ExceptionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept two ints, find the sum, then disp then continuesly
            // only if they are +ve
            // only if they are non zero
            // only if they are evens
            // if not throw an appropriate custom exep




            while (true)
            {
                try
                {
                    Console.Write("Enter First Number: ");
                    int fno = int.Parse(Console.ReadLine());

                    // open db connection

                    Console.Write("Enter Second Number: ");
                    int sno = int.Parse(Console.ReadLine());

                    //int sum = fno + sno;
                    Calculator calc = new Calculator();
                    int sum = calc.Sum(fno, sno);

                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");

                    // close db connection
                }
                catch (FormatException ex)
                {
                    // to fix the ex
                    // a=97
                    Console.WriteLine("Enter only integer values");
                    // close db conn
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Please enter small int numbers only");

                }


                catch (NonEvenNumbersException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (NonZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NonPositiveNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex) // catch all block
                {
                    Console.WriteLine(ex.Message);

                }

                finally
                {
                    // resource management
                    // close the db
                    // always exe
                    Console.WriteLine("Finally called");
                }

            }

        }
    }

    // single line comments
    /*
     * multi line comments 
     */


    // document comments /  xml comments



    // business layer code



    /// <summary>
    /// Use this calculator for finding a sum of two numbers
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Finds a sum of two positive non zero even numbers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        /// <exception cref="NonZeroException"></exception>
        /// <exception cref="NonPositiveNumberException"></exception>
        /// <exception cref="NonEvenNumbersException"></exception>
        public int Sum(int a, int b)
        {
            // non-zero validation
            if (a == 0 || b == 0)
            {
                //Console.WriteLine();
                string msg = "enter only non-zero numbers only";
                //return msg;
                //Console.WriteLine(msg);
                throw new NonZeroException(msg);
            }

            // +ve validation
            if (a < 0 || b < 0)
            {
                throw new NonPositiveNumberException("Enter only positive numbers only");
            }

            // even numbers validation
            if (a % 2 != 0 || b % 2 != 0)
            {
                throw new NonEvenNumbersException("Enter only even numbers only");
            }



            return a + b;
        }
    }


    public class NonZeroException : ApplicationException
    {
        public NonZeroException(string msg) : base(msg)
        {
            //Message = msg;
        }
    }

    public class NonPositiveNumberException : ApplicationException
    {
        public NonPositiveNumberException(string msg) : base(msg) { }
    }

    public class NonEvenNumbersException : ApplicationException
    {
        public NonEvenNumbersException(string msg) : base(msg)
        {

        }
    }
}
