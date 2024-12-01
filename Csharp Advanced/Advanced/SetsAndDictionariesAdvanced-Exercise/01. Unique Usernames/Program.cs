namespace _01._Unique_Usernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> usernames=new HashSet<string>();
            int numOfUsers=int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfUsers; i++)
            {
                string username=Console.ReadLine();
                usernames.Add(username);
                
            }

            foreach (var user in usernames)
            {
                Console.WriteLine(user);
            }
        }
    }
}
/*
6
John
John
John
Peter
John
Boy1234

10
Peter
Maria
Peter
George
Sam
Maria
Sara
Peter
Sam
George
 */
