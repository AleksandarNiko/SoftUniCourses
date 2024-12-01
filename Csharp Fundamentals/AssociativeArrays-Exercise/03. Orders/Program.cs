class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal Quantity { get; set; }

    public Product(string name, decimal price, decimal quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }
    public void Update(decimal price, decimal quantity)
    {
        Price = price;
        Quantity += quantity;
    }
    public decimal TotalPrice ()
    {
        return Price*Quantity;
    }
    public override string ToString()
    {
        return $"{Name} -> {TotalPrice():f2}";
    }
}
internal class Program
{
   static void Main(string[] args)
   {
    Dictionary<string,Product> result = new Dictionary<string,Product>();
    string input;
        while ((input = Console.ReadLine()) != "buy")
        {
            string[] lineToken = input.Split();
            
           string name = lineToken[0];
            decimal price = decimal.Parse(lineToken[1]);           
           decimal quantity = decimal.Parse(lineToken[2]);
            Product product = new Product(name, price, quantity);
            if (result.ContainsKey(name) == false)
            {
                result.Add(product.Name, product);
            }
            else
            {
                result[name].Update (product.Price, product.Quantity);
            }
        }
        foreach (var name in result)
        {
            Console.WriteLine(name.Value);
        }
    }

}
/*
Beer 2,20 100
IceTea 1,50 50
NukaCola 3,30 80
Water 1,00 500
buy
*/