namespace _02._Judge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, Dictionary<string, int>>();
            var users = new Dictionary<string, int>();
            string input;
            while ((input=Console.ReadLine())!="no more time")
            {
                string[] lineToken = input.Split(" -> ");
                string username = lineToken[0];
                string contest = lineToken[1];
                int points = int.Parse(lineToken[2]);

                if (!contests.ContainsKey(contest))
                {
                    contests.Add(contest, new Dictionary<string, int>());
                    contests[contest][username] = points;
                }
                else
                {
                    if (!contests[contest].ContainsKey(username))
                    {
                        contests[contest][username] = points;
                    }
                    else
                    {
                        if (contests[contest][username] < points)
                        {
                            contests[contest][username] = points;
                        }
                    }
                }
            }

            foreach (var contest in contests)
            {
                Console.WriteLine($"{contest.Key}: {contest.Value.Count()} participants");
                int counter = 0;
                foreach (var name in contest.Value.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
                {
                    counter++;
                    Console.WriteLine($"{counter}. {name.Key} <::> {name.Value}");
                }
                counter = 0;
            }

            Console.WriteLine("Individual standings:");

            foreach (var contest in contests)
            {
                foreach (var name in contest.Value)
                {
                    if (!users.ContainsKey(name.Key))
                    {
                        users.Add(name.Key, name.Value);
                    }
                    else
                    {
                        users[name.Key] = users[name.Key] + name.Value;
                    }
                }
            }
            int counter1 = 0;
            foreach (var name in users.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                counter1++;
                Console.WriteLine($"{counter1}. {name.Key} -> {name.Value}");
            }
        }
    }
    }
