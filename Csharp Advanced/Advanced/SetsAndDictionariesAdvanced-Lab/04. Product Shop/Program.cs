namespace _04._Product_Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var markets = new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] lineToken = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string marketName = lineToken[0];
                string productName= lineToken[1];
                double price= double.Parse(lineToken[2]);

                if (!markets.ContainsKey(marketName))
                {
                    markets.Add(marketName,new Dictionary<string, double>());
                }

                if (!markets[marketName].ContainsKey(productName))
                {
                    markets[marketName].Add(productName, 0);
                }

                markets[marketName][productName] = price;
            }

            markets = markets.OrderBy(x => x.Key).ToDictionary(x => x.Key,x=>x.Value);
            foreach (var (market,products) in markets)
            {
                Console.WriteLine($"{market}->");
                foreach (var (product,price) in products)
                {
                    Console.WriteLine($"Product: {product}, Price: {price}");
                }
            }
        }
    }
}
/*
lidl, juice, 2,30
fantastico, apple, 1,20
kaufland, banana, 1,10
fantastico, grape, 2,20
Revision
 */
