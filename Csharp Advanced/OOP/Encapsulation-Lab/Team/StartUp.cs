using Team;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var lines = int.Parse(Console.ReadLine());
            var people = new List<Person>();

            for (int i = 0; i < lines; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ');
                try
                {
                    Person person = new Person(cmdArgs[0], 
                        cmdArgs[1],
                        int.Parse(cmdArgs[2]),
                        decimal.Parse(cmdArgs[3]));
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            var percent = decimal.Parse(Console.ReadLine());
            people = people.OrderBy(p => p.FirstName)
                .ThenBy(p => p.Age)
                .ToList();
            people.ForEach(p => p.IncreaseSalary(percent));

            Team team = new Team("SoftUni");
            foreach (Person person in people)
            {
                team.AddPlayer(person);
            }
        }
    }
}
/*
5
Andrew Williams 20 2200
Newton Holland 57 3333
Rachelle Nelson 27 600
Grigor Dimitrov 25 666,66
Brandi Scott 35 555
 */
