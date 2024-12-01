namespace ChickenSnack
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> amountOfMoney= new Stack<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue <int> prices=new Queue<int>(Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int boughtFood = 0;
            int diffrence=0;

            while (true)
            {
                int currentAmount= amountOfMoney.Pop();
                currentAmount += diffrence;
                int currentPrice = prices.Dequeue();

                if (currentPrice == currentAmount)
                {
                    boughtFood++;
                }

                 if (currentAmount > currentPrice)
                {
                    boughtFood++;
                    diffrence = currentAmount - currentPrice;
                }

                if (!amountOfMoney.Any())
                {
                    break;
                }
                if (!prices.Any())
                {
                    break;
                }
            }

            if (boughtFood >= 4)
            {
                Console.WriteLine($"Gluttony of the day! Henry ate {boughtFood} foods.");
            }
            else if (boughtFood < 4 && boughtFood > 1)
            {
                Console.WriteLine($"Henry ate: {boughtFood} foods.");
            }
            else if (boughtFood == 1)
            {
                Console.WriteLine($"Henry ate: {boughtFood} food.");
            }
            else
            {
                Console.WriteLine("Henry remained hungry. He will try next weekend again.");
            }
        }
    }
}
/*
9 5 8 18
18 12 10 5

1 1 4 5 9 9 9
9 15 18 13 10
   
1 1 4 5 6 2 3 2
17 8 18 19 20
   
18 10 8 9
5 10 12 18
   
 */