using System.Collections.Generic;

namespace _07._Order_by_Age
{
    class Person
    {
        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split(" ");
                string name = lineToken[0];
                string ID = lineToken[1];
                int age = int.Parse(lineToken[2]);
                Person person = new Person();
                person.Name = name;
                person.Id = ID;
                person.Age = age;
                Person sameID=people.Find(x => x.Id==ID);
                if (sameID != null)
                {
                    sameID.Age = age;
                    sameID.Name = name;
                }
                else
                {
                    people.Add(person);
                }
            }
            List<Person>sortedPeople=people.OrderBy(x => x.Age).ToList();
            foreach (Person person in sortedPeople)
            {
                Console.WriteLine(person);
            }
        }
        }
    }
/*
George 123456 20
Peter 78911 15
Stephen 524244 10
End
*/