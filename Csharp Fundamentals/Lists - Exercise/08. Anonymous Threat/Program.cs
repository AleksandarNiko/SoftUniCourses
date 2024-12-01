using System;
using System.Collections.Generic;
using System.Linq;


namespace _08._Anonymous_Threat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List <string> list=Console.ReadLine().Split(" ").ToList();
            string line=string.Empty;
            while ((line=Console.ReadLine()) !="3:1") 
            {
                string[] lineToken = line.Split().ToArray();
                string command = lineToken[0];
                int startIndex = int.Parse(lineToken[1]);
                int endIndex = int.Parse(lineToken[2]);
                if (command == "merge")
                {
                   list=Merge(list, startIndex, endIndex);
                }
                else if (command == "divide")
                {
                    list=Divide(list, startIndex, endIndex);
                }
            }
            Console.WriteLine(string.Join(" ",list));


             static List<string> Divide(List<string> list, int index, int partitions)
            {
                string element = list[index];
                if(partitions <= 0)
                {
                    return list;
                }
                list.RemoveRange(index, 1);
                int subString = element.Length / partitions;
                int remainingChars = element.Length % partitions;

                List<string> newElements = new List<string>();

                int elementIndex = 0;
                for (int i = 0; i < partitions; i++)
                {
                    string newString = "";

                    for (int j = 0; j < subString; j++)
                    {
                        newString += element[elementIndex];
                        elementIndex++;
                    }

                    newElements.Add(newString);
                }

                if (remainingChars > 0 && newElements.Count > 0)
                {
                    for (int i = elementIndex; i < element.Length; i++)
                    {
                        newElements[newElements.Count - 1] += element[i];
                    }
                }

                list.InsertRange(index, newElements);
                return list;
            }

             static int Clamp(int value, int min, int max)
            {
                if (value < 0)
                {
                    value = 0;
                }
                else if (value > max)
                {
                    value = max;
                }
                return value;
            }

            static List<string> Merge(List<string> list, int startIndex, int endIndex)
            {
                startIndex = Clamp(startIndex, 0, list.Count);
                endIndex = Clamp(endIndex, 0, list.Count - 1);

                string merged = string.Join("", list.GetRange(startIndex, endIndex - startIndex + 1));
                list.RemoveRange(startIndex, endIndex - startIndex + 1);
                list.Insert(startIndex, merged);

                return list;
            }
        }
    }
}
