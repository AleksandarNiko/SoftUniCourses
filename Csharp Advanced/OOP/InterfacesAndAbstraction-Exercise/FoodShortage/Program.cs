namespace FoodShortage
{
    public class Program
    {
        static void Main(string[] args)
        {
            int numOfPeople=int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < numOfPeople; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                if (lineToken.Length == 4)
                {
                    buyers.Add(new Citizen(lineToken[0], 
                        int.Parse(lineToken[1]),
                        lineToken[2],
                        lineToken[3]));
                }
                else if (lineToken.Length == 3)
                {
                    buyers.Add(new Rebel(lineToken[0], 
                        int.Parse(lineToken[1]), 
                        lineToken[2]));
                }
            }

            string names;
            while ((names = Console.ReadLine()) != "End")
            {
                var buyer = buyers.SingleOrDefault(b => b.Name == names);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
/*
2
Peter 25 8904041303 04/04/1989
Stan 27 WildMonkeys
Peter
George
Peter
End
 */