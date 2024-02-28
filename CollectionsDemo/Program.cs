using System;
using System.Collections.Generic;
using System.Linq;

namespace CollectionsDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // client dev: need to store n number of int values in a collection and read

            // need to store n numbers of double values in a collction and read

            // need to store n names of string values in a collection and read

            DynamicArray<int> dynamicIntArray = new DynamicArray<int>();

            List<int> ints = new List<int>();




            dynamicIntArray.Add(10);
            dynamicIntArray.Add(20);
            dynamicIntArray.Add(30);
            dynamicIntArray.Add(40);
            //dynamicIntArray.Add(50);
            //dynamicIntArray.Add(60);
            //dynamicIntArray.Add(70.2);
            //dynamicIntArray.Add(80);
            //dynamicIntArray.Add(90);
            //dynamicIntArray.Add(100);
            //dynamicIntArray.Add(110);
            //dynamicIntArray.Add(120);
            //dynamicIntArray.Add(130);
            //dynamicIntArray.Add(140);
            //dynamicIntArray.Add(150);
            //dynamicIntArray.Add(160);


            for (int i = 0; i < dynamicIntArray.Size; i++)
            {
                Console.WriteLine(dynamicIntArray.Get(i));
            }


        }

        private static void jogged()
        {
            const int size = 100;
            int[] numbers = new int[size];


            // jogged arrays
            int[][] scores = new int[3][];//rows
            scores[0] = new int[2]; // first row 2 col
            scores[1] = new int[3];
            scores[2] = new int[1];

            // write
            scores[0][0] = 70;
        }

        private static void twod()
        {
            // two dim
            int[,] twod = new int[3, 5];

            twod[0, 0] = 10;
            twod[1, 1] = 20;
        }

        private static void Demo1()
        {
            // need to store 5 int values
            int[] ints = new int[5];
            ints[0] = 31;
            ints[1] = 22;
            ints[2] = 3;
            ints[3] = 34;
            ints[4] = 51;

            // find sum of all the numbers
            int sum = 0;
            foreach (int i in ints)
            {
                sum += i;
            }
            //Console.WriteLine(sum);
            sum = ints.Sum();
            int max = ints.Max();
            double avg = ints.Average();
            int min = ints.Min();
            int count = ints.Count();
            Array.Sort(ints);
            Array.Reverse(ints);
            foreach (var item in ints)
            {
                Console.WriteLine(item);
            }
        }
    }



    public class DynamicIntArray
    {

        private int[] data = new int[5];
        private int index = 0;
        public int Size
        {
            get { return index; }

        }

        public void Add(int v)
        {
            // if array is empty
            if (index < data.Length)
            {
                data[index++] = v;
            }
            else // if not empty
            {
                // increase the size of the array and store
                // create a new array
                //int[] temp = new int[data.Length * 2];
                // copy old array with new array
                //for (int i = 0; i < data.Length; i++)
                //{
                //    temp[i] = data[i];
                //}
                //Array.Copy(data, temp, data.Length);
                // move the ref variable from old address into new
                //data = temp;

                Array.Resize(ref data, data.Length * 2);

                // insert new value
                data[index++] = v;

            }
        }

        public int Get(int i)
        {
            return data[i];
        }
    }

    public class DynamicDoubleArray
    {

        private double[] data = new double[5];
        private int index = 0;
        public int Size
        {
            get { return index; }

        }

        public void Add(double v)
        {
            // if array is empty
            if (index < data.Length)
            {
                data[index++] = v;
            }
            else // if not empty
            {
                // increase the size of the array and store
                // create a new array
                //int[] temp = new int[data.Length * 2];
                // copy old array with new array
                //for (int i = 0; i < data.Length; i++)
                //{
                //    temp[i] = data[i];
                //}
                //Array.Copy(data, temp, data.Length);
                // move the ref variable from old address into new
                //data = temp;

                Array.Resize(ref data, data.Length * 2);

                // insert new value
                data[index++] = v;

            }
        }

        public double Get(int i)
        {
            return data[i];
        }
    }

    public class DynamicStringArray
    {

        private string[] data = new string[5];
        private int index = 0;
        public int Size
        {
            get { return index; }

        }

        public void Add(string v)
        {
            // if array is empty
            if (index < data.Length)
            {
                data[index++] = v;
            }
            else // if not empty
            {
                // increase the size of the array and store
                // create a new array
                //int[] temp = new int[data.Length * 2];
                // copy old array with new array
                //for (int i = 0; i < data.Length; i++)
                //{
                //    temp[i] = data[i];
                //}
                //Array.Copy(data, temp, data.Length);
                // move the ref variable from old address into new
                //data = temp;

                Array.Resize(ref data, data.Length * 2);

                // insert new value
                data[index++] = v;

            }
        }

        public string Get(int i)
        {
            return data[i];
        }
    }


    public class DynamicArray<T> // Generic Code / class
    {

        private T[] data = new T[5];
        private int index = 0;
        public int Size
        {
            get { return index; }

        }

        public void Add(T v) // generic method
        {
            // if array is empty
            if (index < data.Length)
            {
                data[index++] = v;
            }
            else // if not empty
            {
                // increase the size of the array and store
                // create a new array
                //int[] temp = new int[data.Length * 2];
                // copy old array with new array
                //for (int i = 0; i < data.Length; i++)
                //{
                //    temp[i] = data[i];
                //}
                //Array.Copy(data, temp, data.Length);
                // move the ref variable from old address into new
                //data = temp;

                Array.Resize(ref data, data.Length * 2);

                // insert new value
                data[index++] = v;

            }
        }

        public T Get(int i)
        {
            return data[i];
        }
    }

}
