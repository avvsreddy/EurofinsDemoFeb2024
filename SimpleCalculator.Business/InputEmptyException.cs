using System;
using System.Runtime.Serialization;

namespace SimpleCalculator.Business
{
    [Serializable]
    public class InputEmptyException : ApplicationException
    {
        public InputEmptyException()
        {
        }

        public InputEmptyException(string message) : base(message)
        {
        }

        public InputEmptyException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InputEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}