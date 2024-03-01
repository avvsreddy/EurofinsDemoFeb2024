using System;

namespace ExceptionsDemo1.DataLayer
{
    public class UnableToSaveDataException : ApplicationException
    {
        //public UnableToSaveDataException()
        //{

        //}
        //public UnableToSaveDataException(string msg) : base(msg)
        //{

        //}

        public UnableToSaveDataException(string msg = null, Exception ex = null) : base(msg, ex)
        {

        }
    }
}
