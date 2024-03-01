using ExceptionsDemo1.DataLayer;

namespace ExceptionsDemo1
{
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

            int sum = a + b;

            // store this data.
            CalclatorRepository repo = new CalclatorRepository();
            repo.Save($"{a} + {b} = {sum}");

            return sum;
        }
    }
}
