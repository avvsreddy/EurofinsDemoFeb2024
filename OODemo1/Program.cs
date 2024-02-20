using System;

namespace OODemo1
{
    internal class Program
    {

        //var name;
        //Employee e = new Employee(); // Has - a
        static void Main(string[] args)
        {
            // var salary =  GetSalary(111);
            // var a = 10;
            // a = "234";
            var str = "sdfsdfsdf";


            var p2 = new { ProdudctID = 2 }; // Anonymous types

            var p1 = new { ProdudctID = 1, Name = "Iphone", Price = 10000, Brand = "Apple", Category = "Mobiles" };

            var p3 = new { ProdudctID = 3, Name = "IPhione 15 Pro" };

            var p4 = new { ProdudctID = 234, Rating = 5, Supplier = "abv" };
            //p4.Rating = 5;

            Console.WriteLine(p4.Supplier);

            // Object Initialization Syntax


            //p1.ProdudctID = 1;
            //p1.Name = "IPhone ";
            //p1.Brand = "Apple";
            //p1.Price = 100000;
            //p1.Category = "Mobiles";

        }
    }

    class Employee //: Program // IS-A
    {
        // state / fields
        private int eid;
        //private string name;
        //private string _backing34234234234;
        private int lname;
        private int salary;


        public Employee(string n)
        {
            Name = n;
        }
        public string Name
        {
            get;// { return _backing34234234234; }
            private set;// { _backing34234234234 = value; }
        }

        public int Eid
        {
            get { return eid; }
            set { eid = value; }
        }

        public int Salary  // Property
        {
            set
            {
                if (value < 1000)
                {
                    salary = 1000;
                }
                else
                    salary = value;
            }
            get
            {
                return salary;
            }
        }

    }


    //class Product
    //{
    //    public int ProdudctID { get; set; }
    //    public string Name { get; set; }
    //    public int Price { get; set; }
    //    public string Brand { get; set; }
    //    public string Category { get; set; }

    //    //public Product(int id)
    //    //{
    //    //    this.ProdudctID = id;
    //    //}

    //    //public Product(int id, string name):this(id)
    //    //{
    //    //    //this.ProdudctID=id;
    //    //    this.Name= name;
    //    //}

    //    //public Product(int id, string name, int price, string brand, string category):this(id,name)
    //    //{
    //    //    //this.ProdudctID = id;
    //    //    //this.Name = name;
    //    //    this.Brand = brand;
    //    //    this.Price = price;
    //    //    this.Category = category;
    //    //}
    //}
}
