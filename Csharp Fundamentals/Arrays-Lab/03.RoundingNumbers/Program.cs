namespace _03.RoundingNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 0,9 1,5 2,4 2,5 3,14
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();
            int[] roundedNums = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                roundedNums[i] = (int)Math.Round(nums[i], MidpointRounding.AwayFromZero);
                Console.WriteLine($"{nums[i]} => {roundedNums[i]}");
            }
        }
    }
}