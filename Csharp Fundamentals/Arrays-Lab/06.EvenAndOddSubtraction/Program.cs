namespace _06.EvenAndOddSubtraction
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]arr=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sumOfEven = 0;
            int sumOfOdd = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i]%2 ==0)
                {
                    sumOfEven += arr[i];
                }
                else
                { 
                    sumOfOdd += arr[i]; 
                }
            }
            Console.WriteLine((sumOfEven - sumOfOdd));
        }
    }
}