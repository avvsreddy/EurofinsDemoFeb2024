using System;

namespace ExceptionsDemo1
{
    public class NonPositiveNumberException : ApplicationException
    {
        public NonPositiveNumberException(string msg) : base(msg) { }
    }
}
