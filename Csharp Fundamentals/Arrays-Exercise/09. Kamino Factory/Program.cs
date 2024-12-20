﻿namespace _09._Kamino_Factory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequences=int.Parse(Console.ReadLine());
            string sequence;
            int bestIndex = 0;
            int bestStartIndex = int.MaxValue;
            int bestSum = 0;
            int bestCount = 0;
            string[] bestSequence = Array.Empty<string>();
            int index = 0;
            while (true)
            {
                sequence = Console.ReadLine();
                if (sequence == "Clone them!")
                {
                    break;
                }
                index += 1;
                int count = 0;
                int sum = 0;
                string[] sequenceArr = sequence.Split("!", StringSplitOptions.RemoveEmptyEntries);
                for (int i = lengthOfSequences - 1; i >= 0; i--)
                {
                    if (sequenceArr[i] == "1")
                    {
                        sum++;
                        count++;
                        if (bestCount < count || bestStartIndex > i || bestSum < sum)
                        {
                            bestSequence = sequenceArr;
                            bestStartIndex = i;
                            bestIndex = index;
                            bestCount = count;
                            bestSum = sum;
                        }
                    }
                    else
                    {
                        count = 0;
                    }
                }
            }
            Console.WriteLine($"Best DNA sample {bestIndex} with sum: {bestSum}.");
            Console.WriteLine(string.Join(" ", bestSequence));
        }
    }
 }