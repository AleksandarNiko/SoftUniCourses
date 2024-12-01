namespace _02._A_Miner_Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary <string,float> things = new Dictionary<string,float> ();
            string input;
            while ((input = Console.ReadLine())!="stop")
            {
                
                if (!things.ContainsKey(input))
                {
                    things.Add (input, 0);
                }
                float weight = float.Parse(Console.ReadLine());
                things[input] += weight;
            }
            foreach (var item in things)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
/*
Gold
155
Silver
10
Copper
17
stop
*/