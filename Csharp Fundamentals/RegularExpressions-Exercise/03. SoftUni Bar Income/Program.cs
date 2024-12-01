using System.Text.RegularExpressions;

namespace _03._SoftUni_Bar_Income
{
    class Order
    {
        public string Customer { get; set; }

        public string Item { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal TotalPrice
        {
            get { return Quantity * Price; }
        }
    }

    internal class Program
    {
        static void Main()
        {
            decimal totalIncome = 0;
            string pattern = @"\%([A-Z][a-z]+)\%[^|$%.]*\<(\w+)\>[^|$%.]*\|(\d+)\|[^|$%.]*?(\d+(?:\.\d+)?)\$";
            string command;
            while ((command = Console.ReadLine()) != "end of shift")
            {
                if (Regex.IsMatch(command, pattern) == false)
                {
                    continue;
                }



                Match match = Regex.Match(command, pattern);

                Order order = new Order();
                order.Customer = match.Groups[1].Value;
                order.Item = match.Groups[2].Value;
                order.Quantity = int.Parse(match.Groups[3].Value);
                order.Price = decimal.Parse(match.Groups[4].Value);

                totalIncome += order.TotalPrice;
                Console.WriteLine($"{order.Customer}: {order.Item} - {order.TotalPrice:F2}");
            }

            Console.WriteLine($"Total income: {totalIncome:F2}");
        }
    }
}
/*
%George%<Croissant>|2|10,3$
%Peter%<Gum>|1|1,3$
%Maria%<Cola>|1|2,4$
end of shift
*/