using System.Diagnostics;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DTOs.Export;
using ProductShop.DTOs.Import;
using ProductShop.Models;
using User = ProductShop.Models.User;

namespace ProductShop
{
    public class StartUp
    {
        public static void Main()
        {
            ProductShopContext productShopContext = new ProductShopContext();

            // 01
            // string usersText = File.ReadAllText("../../../Datasets/users.xml");
            // Console.WriteLine(ImportUsers(productShopContext, usersText));

            // 02
              string productsText = File.ReadAllText("../../../Datasets/products.xml");
             Console.WriteLine(ImportProducts(productShopContext, productsText));

            // 03
            // string categoriesText = File.ReadAllText("../../../Datasets/categories.xml");
            // Console.WriteLine(ImportCategories(productShopContext, categoriesText));

            // 04
            // string categoriesProductsText = File.ReadAllText("../../../Datasets/categories-products.xml");
            // Console.WriteLine(ImportCategoryProducts(productShopContext, categoriesProductsText));

            // 05
            //Console.WriteLine(GetProductsInRange(productShopContext));

            //06
            //Console.WriteLine(GetSoldProducts(productShopContext));

            //07
            //Console.WriteLine(GetCategoriesByProductsCount(productShopContext));

            //08
            //Console.WriteLine(GetUsersWithProducts(productShopContext));
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Users");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportUsersDto[]), root);

            ImportUsersDto[] usersDtos;

            using (var reader = new StringReader(inputXml))
            {
                usersDtos = (ImportUsersDto[])xmlSerializer.Deserialize(reader);
            }

            User[] users = usersDtos
                .Select(dto => new User()
                {
                    FirstName = dto.FirstName,
                    LastName = dto.LastName,
                    Age = dto.Age
                })
                .ToArray();

            context.Users.AddRange(users);
            context.SaveChanges();

            return $"Successfully imported {users.Length}";
        }


        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ImportProductsDto[]),
                new XmlRootAttribute("Products"));

            ImportProductsDto[] productsDtos;

            using (var reader = new StringReader(inputXml))
            {
                productsDtos=(ImportProductsDto[])xmlSerializer.Deserialize(reader);
            }



            Product[] products = productsDtos
                .Select(p => new Product
                {
                    Name = p.Name,
                    Price = p.Price,
                    SellerId = p.SellerId,
                    BuyerId = p.BuyerId
                })
                .ToArray();

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }
        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("Categories");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoriesDto[]), root);

            using StringReader reader = new StringReader(inputXml);
            ImportCategoriesDto[] categoriesDtos = (ImportCategoriesDto[])serializer.Deserialize(reader);

            Category[] categories = categoriesDtos
                .Select(c => new Category()
                {
                    Name = c.Name,
                })
                .ToArray();

            context.Categories.AddRange(categories);
            context.SaveChanges();
            return $"Successfully imported {categories.Length}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute("CategoryProducts");
            XmlSerializer serializer = new XmlSerializer(typeof(ImportCategoryProductsDto[]), root);

            using StringReader reader = new StringReader(inputXml);

            ImportCategoryProductsDto[] catProductsDtos = (ImportCategoryProductsDto[])serializer.Deserialize(reader);

            List<CategoryProduct> catProducts = new List<CategoryProduct>();

            foreach (var entry in catProductsDtos)
            {
                if (context.Products.Any(p => p.Id == entry.ProductId) &&
                    context.Categories.Any(c => c.Id == entry.CategoryId))
                {
                    catProducts.Add(new CategoryProduct()
                    {
                        CategoryId = entry.CategoryId,
                        ProductId = entry.ProductId
                    });
                }
            }

            context.CategoryProducts.AddRange(catProducts);
            context.SaveChanges();

            return $"Successfully imported {catProducts.Count}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {
            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .OrderBy(p => p.Price)
                .Take(10)
                .Select(p => new ExportProductsInRangeDto()
                {
                    Name = p.Name,
                    Price = p.Price,
                    BuyerFullName = p.BuyerId.HasValue
                        ? $"{p.Buyer.FirstName} {p.Buyer.LastName}"
                        : null
                })
                .ToArray();

            return SerializeToXml(products, "Products");
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u => u.ProductsSold.Any())
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
                .Take(5)
                .Select(u => new ExportUserDto
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    ProductSold = u.ProductsSold.Select(ps => new ExportProductsDto()
                    {
                        Name = ps.Name,
                        Price = ps.Price,
                    }).ToArray()
                }).ToArray();

            return SerializeToXml(users, "Users");
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            var categories = context.Categories
                .Select(c => new ExportCategoriesByProductsCountDto()
                {
                    Name = c.Name,
                    Count = c.CategoryProducts.Count,
                    AveragePrice = c.CategoryProducts.Count > 0
                        ? c.CategoryProducts.Average(c => c.Product.Price)
                        : 0,
                    TotalRevenue = c.CategoryProducts.Sum(cp => cp.Product.Price),
                })
                .OrderByDescending(c => c.Count)
                .ThenBy(c => c.TotalRevenue).ToArray();

            return SerializeToXml(categories, "Categories");

        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {
            var users = context.Users
                .Where(u=>u.ProductsSold.Any())
                .OrderByDescending(u=>u.ProductsSold.Count)
                .Take(10)
                .Select(u=> new ExportUsersWithProducts()
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Age = u.Age,
                    SoldProducts = new ExportSoldProductsDto()
                    {
                        Count = u.ProductsSold.Count,
                        Products = u.ProductsSold.Select(p => new ExportProductsDto()
                        {
                           Name= p.Name,
                           Price=p.Price,
                            
                        })
                        .OrderByDescending(p=>p.Price)
                        .ToArray()
                    }
                })
                .ToArray();

            ExportUsersProductsDto result = new ExportUsersProductsDto()
            {
                Count = context.Users.Count(u => u.ProductsSold.Any()),
                UsersWithProducts = users
            };

            return SerializeToXml(result, "Users");

        }

        public static string SerializeToXml<T>(T obj, string rootName, bool omitXmlDeclaration = false)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj), "Object to serialize cannot be null.");

            if (string.IsNullOrEmpty(rootName))
                throw new ArgumentNullException(nameof(rootName), "Root name cannot be null or empty.");

            try
            {
                XmlRootAttribute xmlRoot = new(rootName);
                XmlSerializer xmlSerializer = new(typeof(T), xmlRoot);

                XmlSerializerNamespaces namespaces = new();
                namespaces.Add(string.Empty, string.Empty);

                XmlWriterSettings settings = new()
                {
                    OmitXmlDeclaration = omitXmlDeclaration,
                    Indent = true
                };

                StringBuilder sb = new();
                using var stringWriter = new StringWriter(sb);
                using var xmlWriter = XmlWriter.Create(stringWriter, settings);

                xmlSerializer.Serialize(xmlWriter, obj, namespaces);
                return sb.ToString().TrimEnd();
            }
            catch (InvalidOperationException ex)
            {
                Debug.WriteLine($"Serialization error: {ex.Message}");
                throw new InvalidOperationException($"Serializing {typeof(T)} failed.", ex);
            }
        }
    }
}