namespace _02._Sum_Numbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums=Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            NumsCount(nums);
            NumsSum(nums);
        }

        static void NumsCount(int[] nums)
        {
            Console.WriteLine(nums.Length);
        }

        static void NumsSum(int[] nums)
        {
            Console.WriteLine(nums.Sum());
        }

    }
}
