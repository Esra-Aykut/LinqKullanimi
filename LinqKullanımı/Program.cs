using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqKullanimi
{
    class Program
    {

            static void Main(string[] args)
            {

                List<Category> categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Bilgisayar"},
                new Category{CategoryId=2, CategoryName="Telefon"}
            };

                List<Product> products = new List<Product>
            {
                new Product{ProductId=1, CategoryId=1, ProductName="Acer Laptop", QuantityPerUnit="32 GB Ram", UnitPrice=10000, UnitsInStock=5},
                new Product{ProductId=2, CategoryId=1, ProductName="Asus Laptop", QuantityPerUnit="16 GB Ram", UnitPrice=18000, UnitsInStock=3},
                new Product{ProductId=3, CategoryId=1, ProductName="Hp Laptop", QuantityPerUnit="8 GB Ram", UnitPrice=18000, UnitsInStock=2},
                new Product{ProductId=4, CategoryId=2, ProductName="Samsung Galaxy", QuantityPerUnit="4 GB Ram", UnitPrice=5000, UnitsInStock=15},
                new Product{ProductId=5, CategoryId=2, ProductName="Iphone", QuantityPerUnit="4 GB Ram", UnitPrice=80000, UnitsInStock=0},
            };

                Test(products);
                //FindTest(products);
                //GetProducts(products);
                //GetProductsLinq(products);
                //AnyTest(products);
                //FindAllTest(products);  //FindAll, Contains
                //AscDescTest(products);
                //ClassicLinqTest(products, categories);

            } //Main

            #region Test
            static void Test(List<Product> products)
            {
                Console.WriteLine("-------Algoritmik-------");
                foreach (var p in products)
                {
                    if (p.UnitPrice > 8000 && p.UnitsInStock > 2)
                    {
                        Console.WriteLine(p.ProductName);
                    }
                }

                Console.WriteLine("-------Linq-------");
                var result = products.Where(p => p.UnitPrice > 8000 && p.UnitsInStock > 2);
                foreach (var p in result)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            #endregion


            #region GetProducts
            static List<Product> GetProducts(List<Product> products)
            {
                List<Product> filteredProducts = new List<Product>();
                foreach (var p in products)
                {
                    if (p.UnitPrice > 5000 && p.UnitsInStock > 3)
                    {
                        filteredProducts.Add(p);
                        Console.WriteLine(p.ProductName);
                    }
                }
                return filteredProducts;
            }
           #endregion


           #region GetProductsLinq
            static void GetProductsLinq(List<Product> products)
            {
                var result= products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
                foreach (var p in result)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            #endregion


            #region AnyTest
            static void AnyTest(List<Product> products)
            {
                var result = products.Any(p => p.ProductName == "Acer Laptop");
                Console.WriteLine(result); //True
            }
            #endregion


            #region FindTest
            private static void FindTest(List<Product> products)
            {
                var result = products.Find(p => p.ProductId == 5);
                Console.WriteLine(result.ProductName);
            }
            #endregion


            #region FindAllTest
            private static void FindAllTest(List<Product> products)
            {
                var result = products.FindAll(p => p.ProductName.Contains("top"));
                foreach (var p in result)
                {
                   Console.WriteLine(p.ProductName);
                }

            }
            #endregion


            #region AscDescTest
            private static void AscDescTest(List<Product> products)
            {
                var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
                foreach (var p in result)
                {
                    Console.WriteLine(p.ProductName);
                }
            }
            #endregion


            #region ClassicLinqTest
            private static void ClassicLinqTest(List<Product> products, List<Category> categories)
            {
                var result = from p in products
                             join c in categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDto { CategoryName = c.CategoryName, ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

                foreach (var productDto in result)
                {
                    Console.WriteLine(productDto.ProductName + "----" + productDto.CategoryName);
                }

            }
            #endregion

    } //class Program


    class ProductDto
    {
            public int ProductId { get; set; }
            public string CategoryName { get; set; }
            public string ProductName { get; set; }
            public decimal UnitPrice { get; set; }
    }

    class Product
    {
            public int ProductId { get; set; }
            public int CategoryId { get; set; }
            public string ProductName { get; set; }
            public string QuantityPerUnit { get; set; }
            public decimal UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
    }

    class Category
    {
            public int CategoryId { get; set; }
            public string CategoryName { get; set; }
    }

}
