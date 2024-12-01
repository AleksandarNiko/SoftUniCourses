namespace _02._Shoot_for_the_Win
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> numbers = Console.ReadLine().Split(' ').Select (int.Parse).ToList();
            int shotTargetsCount = 0;
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                int targetIndex = int.Parse(input);
                if (targetIndex >= numbers.Count || targetIndex < 0)
                {
                    continue;
                }
                int targetValue = numbers[targetIndex];
                if (targetValue==-1)
                {
                    continue;
                }
                 numbers[targetIndex] = -1;
                shotTargetsCount++;

                for (int i = 0; i < numbers.Count; i++)
                {
                    if (numbers[i] == -1)
                    {
                        continue;
                    }
                    else if (numbers[i] > targetValue)
                    {
                        numbers[i] -= targetValue;
                    }
                    else if (numbers[i]<=targetValue)
                    {
                        numbers[i] +=targetValue;
                    }
                }

            }
            Console.WriteLine($"Shot targets: {shotTargetsCount} -> {string.Join(" ",numbers)}");
        }
    }
}