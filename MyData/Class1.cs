using System.Collections.Generic;

namespace WebApplication1.App_Code
{
    public class Product
    {
        public string Name { get; }
        public int Price { get; }

        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }
    }
    
    public class Merchant
    {
        private static List<Product> _products;

        public Merchant()
        {
            _products = new List<Product>();
            _products.Add(new Product("Pen", 25));
            _products.Add(new Product("Pencil", 30));
            _products.Add(new Product("Notebook", 15));
        }

        public static List<Product> GetProducts()
        {
            return _products;
        }
    }
}