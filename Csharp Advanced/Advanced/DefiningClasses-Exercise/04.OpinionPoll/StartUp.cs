namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = lineToken[0];
                int age = int.Parse(lineToken[1]);

                Person person = new Person()
                {
                    Name=name,
                    Age=age
                };
                people.Add(person);
            }

            List<Person> filteredPeople = people.FindAll(p => p.Age > 30);
            List<Person> sortedPeople=filteredPeople.OrderBy(p => p.Name).ToList();

            foreach (Person person in sortedPeople)
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
/*
3
Peter 12
Sam 31
Ivan 48

5
Niki 33
Yord 88
Teo 22
Lily 44
Stan 11
 */