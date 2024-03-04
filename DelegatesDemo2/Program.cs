using System;
using System.Diagnostics;

namespace DelegatesDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // client 1
            // display all processes
            // ProcessManager.ShowProcessList();

            // client 2 display all process names starts with S

            FilterDelegate filter = new FilterDelegate(Program.FilterByName);

            ProcessManager.ShowProcessList(filter);

            // client 3 display all large process
            ProcessManager.ShowProcessList(FilterBySize);


            // Anonymous Delegates
            ProcessManager.ShowProcessList(delegate (Process p)
            {
                return p.WorkingSet64 >= 100 * 1024 * 1024;
            });


            // Lambda Expression - Light Weight Syntax for Anonymous Delegates

            // Lambda - Statements

            ProcessManager.ShowProcessList((Process p) =>
            {
                return p.WorkingSet64 >= 100 * 1024 * 1024;
            });

            // Lambda - Expression 1
            ProcessManager.ShowProcessList((Process p) =>

                 p.WorkingSet64 >= 100 * 1024 * 1024
            );

            // Lambda - Expression 2
            ProcessManager.ShowProcessList(p => p.WorkingSet64 >= 100 * 1024 * 1024);


        }
        // by client 2
        public static bool FilterByName(Process p)
        {
            return p.ProcessName.StartsWith("S");
        }



        // by client 3
        public static bool FilterBySize(Process p)
        {
            return p.WorkingSet64 >= 100 * 1024 * 1024;
        }

    }


    // declare a delegate

    public delegate bool FilterDelegate(Process p);


    // Back End Dev
    public class ProcessManager
    {
        //public static void ShowProcessList()
        //{
        //    // display all running processes
        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        Console.WriteLine(p.ProcessName);
        //    }
        //}

        //public static void ShowProcessList(string sw)
        //{
        //    // display all running processes stats with 'S'
        //    foreach (Process p in Process.GetProcesses())
        //    {
        //        if (p.ProcessName.StartsWith(sw))
        //            Console.WriteLine(p.ProcessName);
        //    }
        //}

        public static void ShowProcessList(FilterDelegate filter)
        {
            // display all running processes stats with 'S'
            foreach (Process p in Process.GetProcesses())
            {
                if (filter(p)) // invoke the delegate
                    Console.WriteLine(p.ProcessName);
            }
        }
    }
}
