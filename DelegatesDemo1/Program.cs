using System;

namespace DelegatesDemo1
{
    //public class MyDel : MulticastDelegate

    //public class MyDelegate : Delegate
    //{

    //}

    // Step 1: Delegate Declaration

    public delegate void MyDelegate(string str);

    internal class Program
    {
        static void Main(string[] args)
        {
            // Direct Method Invocation
            // Method name -  Greeting
            // signature of the method void (string str)
            // type of the method - instance / static
            // class name - Program
            // namespace - DelegatesDemo1
            // assembly : DelegatesDemo1

            // Indirect Method Call - by its address + Sign

            //Greeting("Hello World!");
            //Delegate delegate = new Delegate();

            // Step 2: Instantiation and Intialization
            MyDelegate del = new MyDelegate(Greeting);

            Program p = new Program();
            del += p.Hi; // Subscription
            del -= p.Hi; // Unsubscription
            //del += p.Hello;

            // Step 3: Invocation
            //del.Invoke("Hello");
            del("Hello");

        }


        static void Greeting(string msg)
        {
            Console.WriteLine($"Greeting: {msg}");
        }

        public void Hi(string str)
        {
            Console.WriteLine($"Hi {str}");
        }

        public void Hello()
        {

        }
    }
}
