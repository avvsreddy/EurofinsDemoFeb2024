using System;
using System.Linq;
using System.Xml.Linq;

namespace LinqToXmlDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {

            XDocument xml = XDocument.Load("Books.xml");
            // get all computer books total value

            var totalWorth = (from book in xml.Descendants("book")
                              where book.Element("genre").Value == "Computer"
                              select double.Parse(book.Element("price").Value)).Sum();

            Console.WriteLine($"Total worth of all computer books is {totalWorth}");

        }

        private static void GetBookDetails(XDocument xml)
        {
            // get all titles and price
            var bookTitlesNPrice = from book in xml.Descendants("book")
                                   select new
                                   {
                                       Title = book.Element("title").Value,
                                       Price = double.Parse(book.Element("price").Value),
                                       Author = book.Element("author").Value
                                   };


            foreach (var item in bookTitlesNPrice)
            {
                Console.WriteLine($"Title: {item.Title} - Price :{item.Price} - Author {item.Author}");
            }
        }

        private static void GetAllTitles(XDocument xml)
        {

            // extract all book titles and display

            var bookTitles = from title in xml.Descendants("title")
                             select title.Value;

            foreach (var bookTitle in bookTitles)
            {
                Console.WriteLine(bookTitle);
            }
        }
    }

    //class TitlePrice
    //{
    //    public string Title { get; set; }
    //    public double Price { get; set; }
    //}
}
