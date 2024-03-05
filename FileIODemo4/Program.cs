using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace FileIODemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Product));
            Product p = new Product { ProductID = 111, Name = "IPhone 13", Price = 90000 };
            Stream stream = File.OpenWrite("products.xml");

            serializer.Serialize(stream, p);
            stream.Close();

        }

        private static void Deserializer()
        {
            BinaryFormatter binary = new BinaryFormatter();
            Product p = new Product();
            Stream stream = File.OpenRead("productBinary.dat");
            p = (Product)binary.Deserialize(stream);
            Console.WriteLine(p.ProductID);
            Console.WriteLine(p.Name);
            Console.WriteLine(p.Price);
        }

        private static void Serialize()
        {
            Product p = new Product { ProductID = 111, Name = "IPhone 13", Price = 90000 };

            BinaryFormatter binary = new BinaryFormatter();
            //StreamWriter writer = new StreamWriter("productBinary.dat");
            Stream stream = File.OpenWrite("productBinary.dat");

            binary.Serialize(stream, p);
            stream.Close();
        }
    }

    [Serializable]
    public class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
