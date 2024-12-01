namespace _03._Heart_Delivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> neighborhood = Console.ReadLine()
                 .Split('@')
                 .Select(int.Parse)
                 .ToList();

            string input = Console.ReadLine();
            int currentPosition = 0;

            while ((input = Console.ReadLine()) != "Love!")
            {
                List<string> inputArg = input
                    .Split()
                    .ToList();

                if (inputArg[0] == "Jump")
                {
                    currentPosition += int.Parse(inputArg[1]);
                }

                if (currentPosition > neighborhood.Count - 1)
                {
                    currentPosition = 0;
                }

                if (neighborhood[currentPosition] == 0)
                { 
                    Console.WriteLine($"Place {currentPosition} already had Valentine's day.");
                }
                else
                {
                    neighborhood[currentPosition] -= 2;

                    if (neighborhood[currentPosition] == 0)
                    {
                        Console.WriteLine($"Place {currentPosition} has Valentine's day.");
                    }
                }
                
            }

            Console.WriteLine($"Cupid's last position was {currentPosition}.");

            int counter = neighborhood
                .Count(x => x > 0);
            if (neighborhood.Sum() == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {counter} places.");
            }
        }
    }
}
/*
10@10@10@2
Jump 1
Jump 2
Love!
*/