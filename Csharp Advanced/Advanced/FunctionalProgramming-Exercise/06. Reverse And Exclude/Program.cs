namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums= Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            int n=int.Parse(Console.ReadLine());
            Func<List<int>,List<int>> reverse = (nums) =>
            {
                List<int> result = new List<int>();
                for (int i = nums.Count - 1; i >= 0; i--)
                {
                    result.Add(nums[i]);
                }
                return result;
            };

            Predicate<int> match = num => num % n == 0;
            Func<List<int>, Predicate<int>, List<int>> exclude = (nums, match) =>
            {
                var result = new List<int>();
                foreach (int i in nums)
                {
                    if (!match(i))
                    {
                        result.Add((int)i);
                    }
                }
                return result;
            };

           
            nums = exclude(nums, match);
            nums=reverse(nums);
            Console.WriteLine( string.Join(" ",nums));

        }
    }
}
/*
1 2 3 4 5 6
2
*/