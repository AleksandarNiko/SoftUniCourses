namespace _04._Fold_and_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]nums=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int leftIndex = nums.Length / 4 - 1;
            int rightIndex = 3 * nums.Length / 4;

            int[] topNums = new int[nums.Length / 2];

            int numsCount = 0;
            for (int i = leftIndex; i >= 0; i--)
            {
                numsCount++;
                topNums[leftIndex - i] = nums[i];
            }
            for (int i = nums.Length - 1; i >= rightIndex; i--)
            {
                topNums[nums.Length - 1 - i + numsCount] = nums[i];
            }
            int[] bottomArr = new int[nums.Length / 2];

            for (int i = leftIndex + 1; i < rightIndex; i++)
            {
                bottomArr[i - numsCount ] = nums[i];
            }
            for (int i = 0; i < topNums.Length; i++)
            {
                Console.Write(topNums[i] + bottomArr[i] + " ");
            }
        }
    }
}