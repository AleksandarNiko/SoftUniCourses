namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Family family=new Family();
            for (int i = 0; i < n; i++)
            {
                string[] lineToken = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string name = lineToken[0];
                int age = int.Parse(lineToken[1]);
                Person person= new Person()
                {
                    Name = name,
                    Age = age
                };
                family.AddMember(person);
            }

            Person oldestPerson = family.GetOldestMember();
            Console.WriteLine($"{oldestPerson.Name} {oldestPerson.Age}");
        }
    }
}
/*
3
Peter 3
George 4
Annie 5
 */