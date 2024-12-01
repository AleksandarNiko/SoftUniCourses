namespace _03._Custom_Min_Function
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToHashSet();

            Func<HashSet<int>, int> min = nums => nums.Min();

            Console.WriteLine(min(nums));

        }
    }
}
