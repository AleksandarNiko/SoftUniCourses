namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IIdentifiable>all=new List<IIdentifiable>();

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] lineToken = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (lineToken.Length == 3)
                {
                    all.Add(new Citizen(lineToken[0], int.Parse(lineToken[1]), lineToken[2]));
                }
                else if (lineToken.Length == 2)
                {
                    all.Add(new Robot(lineToken[0], lineToken[1]));
                }
            }
            string fakeDigits=Console.ReadLine();

            all.Where(x => x.Id.EndsWith(fakeDigits))
                .Select(x => x.Id)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
/*
Peter 22 9010101122
MK-13 558833251
MK-12 33283122
End
122
 */