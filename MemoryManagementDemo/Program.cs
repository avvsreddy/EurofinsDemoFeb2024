using System;

namespace MemoryManagementDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ManageDB();
            //sdfdfsdf
            //sdfsdfsdf
            //sdfsdfsdf
            //sdfsdfsadfsd


            Console.WriteLine("end of the application");
        }

        static void ManageDB()
        {
            using (DbManager dbManager = new DbManager())
            //using (dbManager)
            {
                dbManager.OpenConnection();
                dbManager.WriteData();
                dbManager.ReadData();
                //dbManager.CloseConnection();
            }
            Console.WriteLine("End of manage db method");
            //ffdfwerwe
            //rerqwerqwer
            //werwerwer
        }
        //
    }

    class DbManager : IDisposable
    {
        ~DbManager() // Finalizaers
        {
            Console.WriteLine("dtor called");
            this.CloseConnection();
        }

        public void Dispose()
        {
            Console.WriteLine("Dispose called");
            this.CloseConnection();
            GC.SuppressFinalize(this);
        }

        public void OpenConnection()
        {
            Console.WriteLine("Connected to DB");
        }
        public void CloseConnection()
        {
            GC.SuppressFinalize(this);
            Console.WriteLine("Disconnected from DB");
        }
        public void WriteData()
        {
            Console.WriteLine("Writing Data");
        }
        public void ReadData()
        {
            Console.WriteLine("Reading Data");
        }
    }
}
