namespace _01._Action_Print
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split();

            Action<string[]> print = (string[] strings)
                =>
            {
                foreach (string s in strings)
                {
                    Console.WriteLine(s);
                }
            };
            print(strings);
        }
    }
}
