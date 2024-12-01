namespace _09._Palindrome_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintPalindrom();
        }

        private static void PrintPalindrom()
        {
            while (true)
            {
                string num = Console.ReadLine();
                if (num == "END")
                {
                    break;
                }
                string reversedString = string.Empty;
                for (int j = num.ToString().Length - 1; j >= 0; j--)
                {
                    char symbol = num[j];
                    reversedString += symbol;
                }
                if (reversedString == num)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }
    }
}