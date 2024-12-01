using System.Net.Http.Headers;

namespace _01._Count_Same_Values_in_Array
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers=Console.ReadLine().Split().Select(double.Parse).ToList();
            var times = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (!times.ContainsKey(number))
                {
                    times[number] = 0;
                }
                times[number]++;
            }
    
            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
//-2,5 4 3 -2,5 -5,5 4 3 3 -2,5 3
