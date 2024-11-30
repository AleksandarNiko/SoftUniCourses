using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.Models;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext productShopContext = new ProductShopContext();

            //01
            //string userText = File.ReadAllText("../../../Datasets/users.json");
            //Console.WriteLine(ImportUsers(productShopContext,userText));

            //02
            //string productText = File.ReadAllText("../../../Datasets/products.json");
            //Console.WriteLine(ImportProducts(productShopContext,productText));

            //03
            //string categoryText = File.ReadAllText("../../../Datasets/categories.json");
            //Console.WriteLine(ImportCategories(productShopContext, categoryText));

            //04
            //string categoryProdText = File.ReadAllText("../../../Datasets/categories-products.json");
            //Console.WriteLine(ImportCategoryProducts(productShopContext, categoryProdText));

            //05
            //Console.WriteLine(GetProductsInRange(productShopContext));

            //06
            //Console.WriteLine(GetSoldProducts(productShopContext));

            //07
            //Console.WriteLine(GetCategoriesByProductsCount(productShopContext));

            //08
            //Console.WriteLine(GetUsersWithProducts(productShopContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var users=JsonConvert.DeserializeObject<List<User>>(inputJson);

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Count}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(inputJson);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count}";
        }
     
        public static string ImportCategories(ProductShopContext context, string inputJson)
         {
            var categories = JsonConvert.DeserializeObject<List<Category>>(inputJson);

            categories.RemoveAll(c => c.Name == null);
            context.Categories.AddRange(categories);
            context.SaveChanges();

            return $"Successfully imported {categories.Count}";
        }
        
        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            var categProd = JsonConvert.DeserializeObject<List<CategoryProduct>>(inputJson);

            context.CategoriesProducts.AddRange(categProd);
            context.SaveChanges();

            return $"Successfully imported {categProd.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products=context.Products
                .Where(p=>p.Price>=500 && p.Price<=1000)
                .OrderBy(p=>p.Price)
                .Select(p => new
                {
                    name=p.Name,
                    price=p.Price,
                    seller=p.Seller.FirstName+" "+p.Seller.LastName
                })
                .ToList();

            string productsJson=JsonConvert.SerializeObject(products);

            return productsJson;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            IContractResolver contractResolver = ConfigureCamelCaseNaming();

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    SoldProducts = u.ProductsSold
                        .Where(p => p.Buyer != null)
                        .Select(p => new
                        {
                            p.Name,
                            p.Price,
                            BuyerFirstName = p.Buyer.FirstName,
                            BuyerLastName = p.Buyer.LastName
                        })
                        .ToArray()
                })
                .AsNoTracking()
                .ToArray();

            return JsonConvert.SerializeObject(users,
                Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ContractResolver = contractResolver
                });

        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    Category=c.Name,
                    ProductsCount=c.CategoriesProducts.Count,
                    AveragePrice=c.CategoriesProducts.Average(cp=>cp.Product.Price).ToString("f2"),
                    TotalRevenue=c.CategoriesProducts.Sum(cp=>cp.Product.Price).ToString("f2")
                })
                .OrderByDescending (c=>c.ProductsCount) 
                .ToList();

            return SerializeObjectWithJsonSettings(categories);
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var userss = context.Users
                 .Where(u => u.ProductsSold.Any(p => p.BuyerId != null && p.Price != null))
                 .Select(u => new
                 {
                     u.FirstName,
                     u.LastName,
                     u.Age,
                     SoldProducts = u.ProductsSold
                         .Where(p => p.BuyerId != null && p.Price != null)
                         .Select(p => new
                         {
                             p.Name,
                             p.Price
                         })
                         .ToArray()
                 })
                 .OrderByDescending(u => u.SoldProducts.Length)
                 .ToArray();

            var output = new
            {
                UsersCount = userss.Length,
                Users = userss.Select(u => new
                {
                    u.FirstName,
                    u.LastName,
                    u.Age,
                    SoldProducts = new
                    {
                        Count = u.SoldProducts.Length,
                        Products = u.SoldProducts
                    }
                })
            };
            return SerializeObjectWithJsonSettings(output);
        }


        private static string SerializeObjectWithJsonSettings(object obj)
        {
            var settings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented
            };
            return JsonConvert.SerializeObject(obj, settings);
        }
        private static IContractResolver ConfigureCamelCaseNaming()
        {
            return new DefaultContractResolver()
            {
                NamingStrategy = new CamelCaseNamingStrategy(false, true)
            };
        }
    }
}