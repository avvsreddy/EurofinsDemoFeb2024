using System;

namespace ExceptionsDemo1
{
    public class NonZeroException : ApplicationException
    {
        public NonZeroException(string msg) : base(msg)
        {
            //Message = msg;
        }
    }
}
