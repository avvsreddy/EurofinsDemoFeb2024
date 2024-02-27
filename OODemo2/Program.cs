using System;

namespace OODemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Base class ref variable can hold derived type objects or it own objects - dynamic polymorphism
            Shape s;// = new Shape();
            s.Draw(); // early binding - static binding - compiler
            //Circle c = new Circle();
            s = new Circle(); // early
            s.Draw();
        }
    }


    //abstract class Shape
    interface IShape
    {
        //public int x;
        //public int y;
        void Draw(); // non polymarphic
        //{
        //    Console.WriteLine("Drawing a Shape");
        //}
        double GetArea();
        //{
        //Console.WriteLine("Calculating Shape area");
        //return x * y;
        //}
    }


    class Triangle : IShape// Realization
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Traiagle");
        }

        public double GetArea()
        {
            Console.WriteLine("Calculating Triangle area");
            return .5 * 34 * 3;
        }
    }

    class Circle : IShape // Generalization
    {
        public void Draw() //   hiding - non polymorphic
        {
            Console.WriteLine("Drawing a Circle");
        }

        public double GetArea()
        {
            return 34;
        }
    }
}
