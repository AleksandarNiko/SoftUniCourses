namespace _01._Data_Types
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type=Console.ReadLine();
            string input = Console.ReadLine();

            typeInput(type, input);
        }

        private static void typeInput(string? type, string? input)
        {
            double result = 0;
            if (type == "int")
            {
                int n = int.Parse(input);
                result = n * 2;
                Console.WriteLine(result);
            }

            if (type == "real")
            {
                double n = double.Parse(input);
                result = n * 1.5;
                Console.WriteLine($"{result:f2}");
            }

            if (type == "string")
            {
                Console.WriteLine($"${input}$");
            }
        }
    }
}