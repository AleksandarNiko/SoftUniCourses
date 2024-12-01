namespace _6._Supermarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> customers = new Queue<string>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (input == "Paid")
                {
                    Console.WriteLine(string.Join("\n",customers));
                    while (customers.Count > 0)
                    {
                        customers.Dequeue();
                    }
                }
                else
                {
                    customers.Enqueue(input);
                }
            }
            Console.WriteLine($"{customers.Count} people remaining.");
        }
    }
}
/*
Liam
Noah
James
Paid
Oliver
Lucas
Logan
Tiana
End
 */
