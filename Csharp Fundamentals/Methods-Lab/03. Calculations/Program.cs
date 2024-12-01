namespace _03._Calculations
{
    internal class Program
    {//*
     //"add",
     //"multiply",
     //"subtract",
     //"divide"
     //*//

        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());
            PrintAddedNumbers(operation, num1, num2);
            PrintMultipliedNumbers(operation, num1, num2);
            PrintSubtractedNumbers(operation, num1, num2);
            PrintDividedNumbers(operation, num1, num2);
        }

        private static void PrintDividedNumbers(string operation, int num1, int num2)
        {
            if (operation == "divide")
            {
                Console.WriteLine(num1 / num2);
            }
        }

        private static void PrintSubtractedNumbers(string operation, int num1, int num2)
        {
            if (operation == "subtract")
            {
                Console.WriteLine(num1 - num2);
            }
        }

        private static void PrintMultipliedNumbers(string operation, int num1, int num2)
        {
            if (operation == "multiply")
            {
                Console.WriteLine(num1 * num2);
            }
        }

        private static void PrintAddedNumbers(string operation, int num1, int num2)
        {
            if (operation == "add")
            {
                Console.WriteLine(num1 + num2);
            }
        }
    }
}