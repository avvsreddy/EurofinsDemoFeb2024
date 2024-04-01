using System;
using System.Collections.Generic;
using System.Net.Http;

namespace CoolProductsClientConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // fetch the list of products from web api and display

            // Discover the URL of the api
            string url = "https://localhost:44324/api/CoolProducts";

            HttpClient client = new HttpClient();


            var request = client.GetAsync(url);
            //sdfsdfsdf
            //sdfsdfsdf
            //sdfsdfsdf
            var result = request.Result;

            if (result.IsSuccessStatusCode)
            {
                string data = result.Content.ReadAsStringAsync().Result;
                var items = result.Content.ReadAsAsync<List<Item>>().Result;

                foreach (var item in items) { Console.WriteLine(item.Name); }
                //Console.WriteLine(item.Name);
            }
        }

        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public class Item
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Category { get; set; }
            public int Price { get; set; }
            public string Brand { get; set; }
            public string Country { get; set; }
            public bool IsInStock { get; set; }
        }


    }
}
