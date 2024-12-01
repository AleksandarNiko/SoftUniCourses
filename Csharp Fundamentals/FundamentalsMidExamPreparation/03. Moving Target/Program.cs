namespace _03._Moving_Target
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <int> targets =Console.ReadLine().Split().Select(int.Parse).ToList();
            string line=string.Empty;
            while ((line = Console.ReadLine()) != "End")
            {
                string[] lineToken = line.Split().ToArray();
                string command = lineToken[0];
                int index = int.Parse(lineToken[1]);
                if (command == "Shoot")
                {
                    int power = int.Parse(lineToken[2]);
                    if (isValidIndex(index, targets))
                    {
                        targets[index] -= power;
                        if (targets[index] <= 0)
                        {
                            targets.RemoveAt(index);
                        }
                    }
                }
                if (command == "Add")
                {
                    int value = int.Parse(lineToken[2]);
                   if( isValidIndex(index, targets))
                    {
                        targets.Insert(index, value);
                    }
                    else
                    {
                        Console.WriteLine("Invalid placement!");
                    }
                }
                if (command == "Strike")
                {
                    int radius = int.Parse(lineToken[2]);
                    if(isValidIndex(index,targets)&&isValidIndex(index+radius,targets)&& isValidIndex(index - radius, targets))
                    {
                        for (int i = 1; i <= radius; i++)
                        {
                            targets.RemoveAt(index+i);
                        }
                        targets.RemoveAt(index);
                        for (int i = 1;i <= radius; i++)
                        {
                            targets.RemoveAt(index-i);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Strike missed!");
                    }
                }
            }
                Console.WriteLine(string.Join('|',targets));
            
        }

         static bool isValidIndex(int index,List<int> targets)
        {
            return index >= 0 && index < targets.Count;
            
        }
    }
}