using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private readonly List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                name = value;
            }
        }
        public decimal Money
        {
            get => money;
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");
                money = value;
            }
        }
        public IReadOnlyCollection<Product> Products { get => products.AsReadOnly(); }
        public void Buy(Product product)
        {
            if (Money >= product.Cost)
            {
                Console.WriteLine($"{Name} bought {product}");
                Money -= product.Cost;
                products.Add(product);
            }
            else
                Console.WriteLine($"{Name} can't afford {product}");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Products.Any())
            {
                sb.Append($"{Name} - {string.Join(", ", Products)}");
            return sb.ToString();
             }
             else
            {
                sb.Append($"{Name} - Nothing bought");
                return  sb.ToString();
        }
        }
    }
}
