using System;
using System.IO;

namespace FileIODemo5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var files = Directory.GetFiles("e:\\");
            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                Console.WriteLine($"{file}, Size {fileInfo.Length}, {fileInfo.FullName}");
            }

        }

        private static void GetDrives()
        {
            var drives = DriveInfo.GetDrives();
            foreach (var drive in drives)
            {
                Console.WriteLine($"{drive.Name} has total size {drive.TotalSize} and avilable free space is {drive.TotalFreeSpace}");
            }
        }
    }
}
