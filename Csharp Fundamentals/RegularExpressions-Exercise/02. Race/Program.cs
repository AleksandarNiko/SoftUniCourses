using System.Text;
using System.Text.RegularExpressions;

namespace _02._Race
{
    class Participant
    {
        public Participant(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public int Distance { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Participant> participants = new Dictionary<string, Participant>();
            string digitsPattern = @"\d";
            string lettersPattern = @"[A-Za-z]";

            List<string> participantsArr=Console.ReadLine().Split(", ").ToList();
            for (int i = 0; i < participantsArr.Count; i++)
            {
                participants.Add(participantsArr[i], new Participant(participantsArr[i]));
            }

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                StringBuilder name = new StringBuilder();
                foreach (Match matchedLetter in Regex.Matches(input, lettersPattern))
                {
                    name.Append(matchedLetter.Value);
                }

                int distance = 0;

                foreach (Match matchedDigit in Regex.Matches(input, digitsPattern))
                {
                    distance+=int.Parse(matchedDigit.Value);
                }

                if (participants.ContainsKey(name.ToString()))
                {
                    participants[name.ToString()].Distance += distance;
                }
            }

            List<Participant> orderedParticipants = participants
                .Select(p => p.Value)
                .OrderByDescending(m => m.Distance).Take(3)
                .ToList();
            Console.WriteLine($"1st place: {orderedParticipants[0].Name}");
            Console.WriteLine($"2nd place: {orderedParticipants[1].Name}");
            Console.WriteLine($"3rd place: {orderedParticipants[2].Name}");
        }
    }
}
/*
George, Peter, Bill, Tom
G4e@55or%6g6!68e!!@
R1@!3a$y4456@
B5@i@#123ll
G@e54o$r6ge#
7P%et^#e5346r
T$o553m&6
end of race
 */