namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] kids = Console.ReadLine().Split();
            Queue<string> kidsQueue= new Queue<string>(kids);
            int tossCountToRemove = int.Parse(Console.ReadLine());
            int currentTosses = 1;
            while (kidsQueue.Count > 1)
            {
                var kidWithPotato = kidsQueue.Dequeue();
                if (currentTosses != tossCountToRemove)
                {
                    currentTosses++;
                    kidsQueue.Enqueue(kidWithPotato);
                }
                else
                {
                    currentTosses = 1;
                    Console.WriteLine($"Removed {kidWithPotato}");
                }
            }

            Console.WriteLine($"Last is {kidsQueue.Dequeue()}");
        }
        }
    }

