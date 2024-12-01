using System.Text;
using System.Xml.Linq;

namespace Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] firstPerson = Console.ReadLine().Split();
            string firstName = firstPerson[0];
            string lastName = firstPerson[1];
            string address = firstPerson[2];
            string town = firstPerson[3];

            Threeuple<string, string, string> firstThreeuple = new($"{firstName} {lastName}", address, town);

            string[] secondPerson = Console.ReadLine().Split();
            string name = secondPerson[0];
            int beerLiters = int.Parse(secondPerson[1]);
            string isDrunk = secondPerson[2];
            bool drunkOrNot = true;
            if (isDrunk != "drunk")
            {
                drunkOrNot = false;
            }

            Threeuple<string, int, bool> secondThreeuple = new(name, beerLiters, drunkOrNot);


            string[] thirdPerson = Console.ReadLine().Split();
            string personName = thirdPerson[0];
            double balance = double.Parse(thirdPerson[1]);
            string bank = thirdPerson[2];

            Threeuple<string, double, string> thirdThreeuple = new(personName, balance, bank);

            Console.WriteLine(firstThreeuple);
            Console.WriteLine(secondThreeuple);
            Console.WriteLine(thirdThreeuple);
        }
    }
}
/*
Adam Smith Wallstreet New York
Mark 18 drunk
Karren 0,10 USBank

Anatoly Andreevich Kutuzova Kaliningrad
Marley 9 not
Grant 2 NGB
 */