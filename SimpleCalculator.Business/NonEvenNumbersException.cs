using System;
using System.Runtime.Serialization;

namespace SimpleCalculator.Business
{
    [Serializable]
    public class NonEvenNumbersException : ApplicationException
    {
        public NonEvenNumbersException()
        {
        }

        public NonEvenNumbersException(string message) : base(message)
        {
        }

        public NonEvenNumbersException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NonEvenNumbersException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}