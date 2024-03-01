using System;

namespace ExceptionsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Account acc = new Account { AccNo = 111, CurrentBalance = 10000, IsActive = true, MinimumBalance = 1000, Pin = 1234 };

                acc.Deposit(111, 2000);
            }
            catch (InvalidAccountNumber ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
