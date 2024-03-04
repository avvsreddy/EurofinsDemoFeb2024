using System;
using System.IO;

namespace FileIODemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // read line by line
            string readLine;
            using (StreamReader reader = new StreamReader(@"e:\names.txt"))
            {
                // read all lines
                while (!reader.EndOfStream)
                {
                    readLine = reader.ReadLine();
                    Console.WriteLine(readLine);
                }
            }


        }

        private static void ReadAllLines()
        {
            // read data from names.txt
            string readAllLines;
            using (StreamReader reader = new StreamReader(@"e:\names.txt"))
            {
                // read all lines
                readAllLines = reader.ReadToEnd();
            }
            Console.WriteLine(readAllLines);
        }

        private static void WriteData()
        {
            // collect person name from user and store into file
            StreamWriter writer = null;
            //try
            //{
            Console.Write("Enter Preson name :");
            string name = Console.ReadLine();

            writer = new StreamWriter("E:\\names.txt", true);
            using (writer)
            {
                writer.WriteLine(name);
            }

            //
            //}
            //finally
            //{
            //writer.Close();
            //}
        }
    }
}
