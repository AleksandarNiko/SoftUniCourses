namespace ShoppingSpree
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] clientsTokens = Console.ReadLine()
                .Split(";",StringSplitOptions.RemoveEmptyEntries);

            string[] productTokens = Console.ReadLine()
                .Split(";", StringSplitOptions.RemoveEmptyEntries);

            List<Person> clients = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < clientsTokens.Length; i++)
                {
                    string[] currClientArgs = clientsTokens[i].Split("=");

                    Person person = new Person(currClientArgs.First(),
                        decimal.Parse(currClientArgs.Last())
                    );

                    clients.Add(person);
                }
                for (int i = 0; i < productTokens.Length; i++)
                {
                    string[] currentProducts = productTokens[i].Split("=");

                    Product product = new Product(currentProducts.First(),
                        decimal.Parse(currentProducts.Last())
                    );

                    products.Add(product);
                }
            }
            catch (ArgumentException exception)
            {
                Console.WriteLine(exception.Message); return;
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split();

                string name = lineToken[0];
                string product = lineToken[1];

                clients.SingleOrDefault(c => c.Name == name)
                    .Buy(products.SingleOrDefault(p => p.Name == product));
            }

            foreach (var client in clients)
            {
                Console.WriteLine(client.ToString());
            }
        }
    }
}
/*
Peter=11;George=4
Bread=10;Milk=2;
Peter Bread
George Milk
George Milk
Peter Milk
END
 */