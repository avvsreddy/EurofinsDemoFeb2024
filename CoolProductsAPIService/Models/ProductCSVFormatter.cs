using CoolProductsAPIService.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;

namespace CoolProductsAPIService.Models
{
    public class ProductCSVFormatter : BufferedMediaTypeFormatter
    {

        public ProductCSVFormatter()
        {
            SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/csv"));
        }
        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            return true;
        }


        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            var writer = new StreamWriter(writeStream);


            var products = value as IEnumerable<Product>; // is value is a collection
            if (products != null)
            {
                foreach (var product in products)
                {
                    writer.WriteLine($"{product.Id},{product.Name},{product.Description},{product.Country},{product.Price},{product.Category}");
                }
            }
            else
            {
                var singleProduct = value as Product; // is value is a single object
                if (singleProduct == null)
                {
                    throw new InvalidOperationException("Cannot serialize type");
                }

                writer.WriteLine($"{singleProduct.Id},{singleProduct.Name},{singleProduct.Description},{singleProduct.Country},{singleProduct.Price},{singleProduct.Category}");
            }
            writer.Close();
        }
    }
}