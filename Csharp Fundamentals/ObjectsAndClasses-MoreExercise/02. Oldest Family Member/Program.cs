namespace _02._Oldest_Family_Member
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string name = lineToken[0];
                int age = int.Parse(lineToken[1]);
                Person person = new Person(name,age);
                people.Add(person);
            }

            var bestAge = people.OrderByDescending(d => d.Age).First();
            Console.WriteLine($"{bestAge.Name} {bestAge.Age}");
        }
    }
}
/*
3
Peter 3
George 4
Annie 5
*/