namespace _02.FromLeftToTheRight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int linesNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < linesNumber; i++)
            {
                string leftNum = "";
                string rightNum = "";
                int sumOfDigits = 0;

                string input = Console.ReadLine();

                int j = 0;

                while (input[j] != ' ')
                {
                    leftNum += input[j];
                    j++;
                }
                while ((j + 1) != input.Length)
                {
                    rightNum += input[j + 1];
                    j++;
                }

                long left = long.Parse(leftNum);
                long right = long.Parse(rightNum);

                if (left >= right)
                {
                    for (int k = leftNum.Length; k >= 0; k--)
                    {
                        byte lastDigits = 0;
                        lastDigits = (byte)(Math.Abs(left % 10));
                        sumOfDigits += (int)lastDigits;
                        left /= 10;
                    }
                    Console.WriteLine(sumOfDigits);
                }
                else
                {
                    for (int k = rightNum.Length; k >= 0; k--)
                    {
                        byte lastDigits = 0;
                        lastDigits = (byte)(Math.Abs(right % 10));
                        sumOfDigits += (int)lastDigits;
                        right /= 10;
                    }
                    Console.WriteLine(sumOfDigits);
                }
            }
        }
    }
}