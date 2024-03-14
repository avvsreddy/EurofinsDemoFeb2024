using System;
using System.Collections;
using System.Collections.Generic;

namespace ExtensionMethodsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string str = "Welcome to Extension Methods";
            Console.WriteLine(str.ToUpper());
            str.Encrypt();
            //str.

            int a = 10;
            //a.Encrypt();

            Program p = new Program();
            //p.Encrypt();
            string eStr = UtilityLibrary.Encrypt(str);

            int[] numbers = new int[10];
            numbers.Encrypt();
            List<int> list = new List<int>();
            //list.e
        }
    }


    //public class MyString : String
    //{

    //}

    public static class UtilityLibrary
    {
        public static string Encrypt(this IEnumerable str)
        {
            return "@#$@#$SDFEF@#$@#$ERTRH#$%%@#$WEER@#$%@#$%";
        }
        //public static string Encrypt(this int str)
        //{
        //    return "@#$@#$SDFEF@#$@#$ERTRH#$%%@#$WEER@#$%@#$%";
        //}
    }
}
