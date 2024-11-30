using System;
using System.ComponentModel.Design;

namespace Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name=Console.ReadLine();
            double grade = 1;
            double sumgrades = 0;
            int badGrades = 0;
            while (grade <= 12)
            {
                double yearGrade = double.Parse(Console.ReadLine());
                if (yearGrade < 4)
                {
                    badGrades++;
                    if (badGrades < 2)
                    {
                        continue;
                    }
                    else
                    {
                        Console.WriteLine($"{name} has been excluded at {grade} grade");
                        break;
                    }
                }
                grade++;
                sumgrades += yearGrade;
            }
            if (grade >= 12)
            {
                double average = sumgrades / 12;
                Console.WriteLine($"{name} graduated. Average grade: {average:f2}");

            }

        }
            

        }
    }

