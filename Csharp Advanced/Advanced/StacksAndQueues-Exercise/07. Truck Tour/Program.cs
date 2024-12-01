namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<int[]>pumpsQueue = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] pairs=Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                
                pumpsQueue.Enqueue(pairs);
            }

            int position = 0;
            while(true)
            {
                int fuel = 0;
                foreach (var item in  pumpsQueue)
                {
                    fuel += item[0]-item[1];
                    if(fuel < 0)
                    {
                        position++;
                        pumpsQueue.Enqueue(pumpsQueue.Dequeue());
                        break;
                    }                  
                }
                if (fuel >= 0)
                {
                    break;
                }
            }
            Console.WriteLine(position);
        }
    }
}
/*
3
1 5
10 3
3 4
*/
