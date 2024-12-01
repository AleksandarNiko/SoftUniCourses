namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> all = new List<IBirthable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineToken[0] == "Citizen")
                {
                    all.Add(new Citizen(lineToken[1], int.Parse(lineToken[2]), lineToken[3], lineToken[4]));
                }
                else if (lineToken[0] == "Pet")
                {
                    all.Add(new Pet(lineToken[1], lineToken[2]));
                }
            }
            int year = int.Parse(Console.ReadLine());

            all.Where(c => c.Birthdate.Year == year)
                .Select(c => c.Birthdate)
                .ToList()
                .ForEach(dt => Console.WriteLine($"{dt:dd/mm/yyyy}"));


        }
    }
}
