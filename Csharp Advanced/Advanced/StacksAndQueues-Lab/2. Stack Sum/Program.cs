namespace _2._Stack_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums=Console.ReadLine().Split().Select(int.Parse).ToList();
            Stack<int> stack = new Stack<int>(nums);
            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var lineToken = input.Split();
                if (lineToken[0] == "add")
                {
                    int first = int.Parse(lineToken[1]);
                    int second = int.Parse(lineToken[2]);
                    stack.Push(first);
                    stack.Push(second);
                }
                else
                {
                    int range = int.Parse(lineToken[1]);
                    if (stack.Count >= range)
                    {
                        for (int i = 0; i < range; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
/*
1 2 3 4
adD 5 6
REmove 3
eNd
 */