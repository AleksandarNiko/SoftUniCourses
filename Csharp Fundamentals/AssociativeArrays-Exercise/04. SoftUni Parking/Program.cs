namespace _04._SoftUni_Parking
{
    class User
    {
        public User(string username,string licenseplate) 
        {
            Username = username;
            Licenseplate = licenseplate;
        }
        public  string Username { get; set; }
        public  string  Licenseplate { get; set; }

        public override string ToString()
        {
            return $"{Username} => {Licenseplate}";
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfCommands=int .Parse(Console.ReadLine());
            Dictionary <string,User> users=new Dictionary<string, User> ();
            for (int i = 0; i < numberOfCommands; i++)
            {
                string[] lineToken = Console.ReadLine().Split();
                string command = lineToken[0];
                string username = lineToken[1];
                switch (command)
                {
                    case "register":
                        string licenseplate = lineToken[2];
                        User newUser = new User (username, licenseplate);
                        if (users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: already registered with plate number {licenseplate}");
                            continue;
                        }
                        users.Add (username, newUser);                                   
                        Console.WriteLine($"{username} registered {licenseplate} successfully");
                        break;
                    case "unregister":
                        if (!users.ContainsKey(username))
                        {
                            Console.WriteLine($"ERROR: user {username} not found");
                        }
                        if(users.ContainsKey(username))
                        {
                            users.Remove (username);
                            Console.WriteLine($"{username} unregistered successfully");
                        }
                        break;
                }

            }
            foreach (var user in users)
            {
                Console.WriteLine(user.Value);
            }
        }
    }
}
/*
5
register John CS1234JS
register George JAVA123S
register Andy AB4142CD
register Jesica VR1223EE
unregister Andy
*/