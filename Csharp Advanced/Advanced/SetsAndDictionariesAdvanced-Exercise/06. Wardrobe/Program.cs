namespace _06._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string,Dictionary<string,int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" -> ",StringSplitOptions.RemoveEmptyEntries).ToArray();
                string color = lineToken[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                string clothes = lineToken[1];
                string[] inputClotes = clothes.Split( ',' , StringSplitOptions.RemoveEmptyEntries).ToArray();

                foreach (var item in inputClotes)
                {
                    if (!wardrobe[color].ContainsKey(item))
                    {
                        wardrobe[color].Add(item, 0);
                    }

                    wardrobe[color][item]++;
                }
            }
            string[] inputFinal = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).ToArray();

            foreach (var kvpColor in wardrobe)
            {
                Console.WriteLine($"{kvpColor.Key} clothes:");

                foreach (var kvpClothes in kvpColor.Value)
                {
                    if (kvpColor.Key == inputFinal[0] && kvpClothes.Key == inputFinal[1])
                    {
                        Console.WriteLine($"* {kvpClothes.Key} - {kvpClothes.Value} (found!)");
                    }

                    else
                    {
                        Console.WriteLine($"* {kvpClothes.Key} - {kvpClothes.Value}");
                    }
                }
            }
        }
    }
}
