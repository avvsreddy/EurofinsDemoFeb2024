using System;
using System.IO;

namespace ExceptionsDemo1.DataLayer
{
    public class CalclatorRepository
    {

        public void Save(string msg)
        {
            try
            {
                File.WriteAllText("calcresult.txt", msg);
            }
            catch (Exception ex)
            {
                // write code to fix
                // Console.WriteLine(ex.Message);
                // back end code - catch
                // 1. log - record the error state - file/db/mail/ex
                // error loging frameworks : nLog, Serilog, etc
                // 2. ex conversion

                UnableToSaveDataException unableToSaveDataException = new UnableToSaveDataException("Data not saved", ex);

                // never suppress the ex
                // must throw exp
                throw unableToSaveDataException;
            }

        }

    }
}
