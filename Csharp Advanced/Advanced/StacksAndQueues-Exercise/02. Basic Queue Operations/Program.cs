 namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine=Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] secondLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = firstLine[0];
            int s= firstLine[1];
            int x = firstLine[2];
            Queue<int> queue = new Queue<int>(n);

            foreach (var item in secondLine)
            {
                queue.Enqueue(item);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(x))
            {
                Console.WriteLine( "true");
            }
            else if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
/*
5 2 32
1 13 45 32 4
*/
