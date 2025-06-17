using System;
using System.Collections.Generic;
using System.Linq;
using BusinessObjects;
 

namespace DataAccessLayer
{
    public class ProductDAO
    {
        private static List<Product> listProducts;

        public ProductDAO()
        {
            Product chai = new Product(1, "Chai", 3, 12, 18);
            Product chang = new Product(2, "Chang", 1, 23, 19);
            Product aniseed = new Product(3, "Aniseed Syrup", 2, 23, 10);

            listProducts = new List<Product> { chai, chang, aniseed };
        }

        public List<Product> GetProducts()
        {
            return listProducts;
        }

        public void SaveProduct(Product p)
        {
            listProducts.Add(p);
        }

        public void UpdateProduct(Product product)
        {
            foreach (Product p in listProducts.ToList())
            {
                if (p.ProductId == product.ProductId)
                {
                    p.ProductName = product.ProductName;
                    p.UnitPrice = product.UnitPrice ?? 0;         // nullable to value
                    p.UnitsInStock = product.UnitsInStock ?? 0;
                    p.CategoryId = product.CategoryId ?? 0;
                }
            }
        }

        public void DeleteProduct(Product product)
        {
            var item = listProducts.FirstOrDefault(p => p.ProductId == product.ProductId);
            if (item != null)
            {
                listProducts.Remove(item);
            }
        }

        public Product? GetProductById(int id)
        {
            return listProducts.FirstOrDefault(p => p.ProductId == id);
        }
    }
}
