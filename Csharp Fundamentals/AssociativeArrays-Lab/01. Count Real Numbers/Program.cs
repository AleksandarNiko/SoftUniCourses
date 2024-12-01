namespace _01._Count_Real_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> numbers = Console.ReadLine().Split().Select(int.Parse).ToList();
            SortedDictionary <int,int> keyValuePairs = new SortedDictionary<int,int>();
            foreach (int number in numbers)
            {
                if (keyValuePairs.ContainsKey(number))
                {
                    keyValuePairs[number]++;
                }
                else
                {
                    keyValuePairs.Add(number, 1);
                }
            }
            foreach (var number in keyValuePairs)
            {
                Console.WriteLine($"{number.Key} -> {number.Value}");
            }
        }
    }
}