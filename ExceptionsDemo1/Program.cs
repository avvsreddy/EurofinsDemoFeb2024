using ExceptionsDemo1.DataLayer;
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
            // store the result into some file




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
                    //throw ex
                }

                catch (NonZeroException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (NonPositiveNumberException ex)
                {
                    Console.WriteLine(ex.Message);
                }

                catch (UnableToSaveDataException ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
                catch (Exception ex) // catch all block
                {
                    //Console.WriteLine(ex.Message);
                    Console.WriteLine("Something went worng, please try later");

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
}
