using System;

namespace ExceptionsDemo1
{
    public class NonEvenNumbersException : ApplicationException
    {
        public NonEvenNumbersException(string msg) : base(msg)
        {

        }
    }
}
