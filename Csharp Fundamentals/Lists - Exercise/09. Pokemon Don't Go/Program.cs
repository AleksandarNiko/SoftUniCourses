using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _09._Pokemon_Don_t_Go
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> distances = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int sum = 0;
            while (distances.Count > 0)
            {
                int index=int.Parse(Console.ReadLine());      
                    int removedNumber;
                    if (index < 0)
                    {
                        removedNumber = distances[0];
                        distances[0] = distances[distances.Count - 1];
                    }
                    else if (index > distances.Count - 1)
                    {
                        removedNumber = distances[distances.Count - 1];
                        distances[distances.Count - 1] = distances[0];
                    }
                    else
                    {
                        removedNumber = distances[index];
                        distances.RemoveAt(index);
                    }
                    sum += removedNumber;
                    for (int i=0; i < distances.Count;i++)
                    {
                       if (distances[i]<=removedNumber)
                        {
                        distances[i] += removedNumber;
                        }
                       else 
                        {
                        distances[i]-=removedNumber;
                    }
                    }
                }
            Console.WriteLine( sum);
        }

        
        }
    }

