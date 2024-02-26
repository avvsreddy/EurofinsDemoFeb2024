using System.Collections.Generic;

namespace OneToManyHasADemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // static/fixed

            int[] numbers = new int[10];
            numbers[0] = 1; // add
            int data = numbers[0]; //read

            // dyanamic collection
            List<int> list = new List<int>();
            list.Add(10); // add
            data = list[0]; //read
        }
    }

    class Company
    {
        Store[] stores = new Store[10];
        List<Customer> customerList = new List<Customer>();
        public Address Address { get; set; }
    }
    class Customer
    {

    }
    class Store
    {

    }
    class Address { }
}
