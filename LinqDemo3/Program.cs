using System;
using System.Linq;
using System.Xml.Linq;
namespace LinqDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<string> words = new List<string>() { "one", "two", "three", "four", "five", "six" };
            // get all short words

            //var shortWords = from word in words
            //                 where word.Length <= 3
            //                 select word;

            // load xml doc into mem
            XDocument xml = XDocument.Load("XMLFile1.xml");

            var shortWords = from word in xml.Descendants("word")
                             where word.Value.Length <= 3
                             select word.Value;

            foreach (var word in shortWords)
            {
                Console.WriteLine(word);
            }

        }
    }
}
