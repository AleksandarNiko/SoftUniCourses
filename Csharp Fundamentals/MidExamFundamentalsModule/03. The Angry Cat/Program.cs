namespace _03._The_Angry_Cat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRatings = Console.ReadLine().Split(",").Select(int.Parse).ToList();
            int entryPoint=int.Parse(Console.ReadLine());
            string typeOfItem=Console.ReadLine();

            int entryItemValue = priceRatings[entryPoint];
            int leftDamage = 0;
            int rightDamage = 0;
            string position = string.Empty;
            if (typeOfItem == "cheap")
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if (priceRatings[i] < entryItemValue)
                    {
                        leftDamage += priceRatings[i];
                    }
                }

                for (int i = entryPoint + 1; i < priceRatings.Count; i++)
                {
                    if (priceRatings[i] < entryItemValue)
                    {
                        rightDamage += priceRatings[i];
                    }
                }
            }
            if(typeOfItem == "expensive")
            {
                for (int i = entryPoint - 1; i >= 0; i--)
                {
                    if(priceRatings[i] >= entryItemValue) 
                    {
                        leftDamage += priceRatings[i];
                    }
                }
                for (int i = entryPoint + 1;i < priceRatings.Count; i++)
                {
                    if (priceRatings[i]>=entryItemValue)
                    {
                        rightDamage += priceRatings[i];
                    }
                }
            }
            if (leftDamage >= rightDamage)
            {
                position = "Left";
                Console.WriteLine($"{position} - {leftDamage}");
            }
            else
            {
                position = "Right";
                Console.WriteLine($"{position} - {rightDamage}");

            }
        }
    }
}