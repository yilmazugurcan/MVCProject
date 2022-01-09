using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBUI.Models.ViewModels;

namespace TestConsoleApp
{
    public class Product
    {
        public Guid ID { get; set; }
        public string ProductName { get; set; }
        public string ImagePath { get; set; }
        public decimal UnitPrice { get; set; }
        public Guid SubCategoryId { get; set; }
        public short UnitsInStock { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Product> productVMs = new List<Product>();
            for (int i = 0; i < 100; i++)
            {
                var testProduct = new Faker<Product>()
                    .RuleFor(x => x.ID, f => f.Random.Guid())
                    .RuleFor(x => x.ProductName, f => f.Commerce.Product())
                    .RuleFor(x => x.UnitPrice, f => f.Finance.Amount())
                    .RuleFor(x => x.UnitsInStock, f => Convert.ToInt16(f.Random.Int(1, 500)))
                    .RuleFor(x => x.ImagePath, f => f.Image.LoremFlickrUrl(600, 700, "product"));
                var product = testProduct.Generate();
                productVMs.Add(product);
            }


            foreach (var product in productVMs)
            {
                Console.WriteLine(product.ID + "\n" + product.ProductName + "\n" + product.UnitPrice + "\n" + product.UnitsInStock + "\n" + product.ImagePath + "\n" + "---------------------------------");
            }
            Console.Read();
        }
    }
}
