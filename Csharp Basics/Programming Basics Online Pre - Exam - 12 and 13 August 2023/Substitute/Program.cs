using System;

namespace Substitute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            int count = 0;
            for (int i = k; i <= 8; i++)
            {
                if (i % 2 == 1) 
                { 
                    continue; 
                }
                for (int j = 9; j >= l; j--)
                {
                    if (j % 2 == 0) { continue; }
                    for (int z = m; z <= 8; z++)
                    {
                        if (z % 2 == 1) 
                        { 
                            continue; 
                        }
                        for (int q = 9; q >= n; q--)
                        {
                            if (q % 2 == 0)
                            {
                                continue;
                            }
                            if (i == z && j == q)
                            {
                                Console.WriteLine("Cannot change the same player.");
                            }
                            else
                            {
                                count++;
                                Console.WriteLine($"{i}{j} - {z}{q}");
                            }
                            if (count == 6) 
                            { 
                                return; 
                            }
                        }
                    }
                }
            }
        }
    }
}
