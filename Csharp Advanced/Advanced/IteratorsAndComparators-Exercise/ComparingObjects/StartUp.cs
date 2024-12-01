using System;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split();
                string name = lineToken[0];
                int age = int.Parse(lineToken[1]);
                string town = lineToken[2];
                Person person = new Person(name,age,town);
                people.Add(person);
            }
            int n=int.Parse(Console.ReadLine())-1;
            int equals = 0;
            int notEquals = 0;


            foreach (Person person in people)
            {
                if (people[n].CompareTo(person) == 0)
                {
                    equals++;
                }
                else
                {
                    notEquals++;
                }
            }

            if (equals <= 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equals} {notEquals} {people.Count}");
            }
        }
    }
}
/*
Peter 22 Varna   
George 14 Sofia   
END
2
 */