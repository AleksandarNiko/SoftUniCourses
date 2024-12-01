namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phoneNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] webs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            StationaryPhone stationaryPhone = new StationaryPhone();
            Smartphone smartphone = new Smartphone();

            foreach (string number in phoneNumbers)
            {
                if (number.Length == 7)
                {
                    stationaryPhone.Call(number);
                }
                else if (number.Length == 10)
                {
                    smartphone.Call(number);
                }
            }
            foreach (string site in webs)
            {
                smartphone.BrowseURL(site);
            }
        }
    }
}
/*
0882134215 0882134333 0899213421 0558123 3333123
http://softuni.bg http://youtube.com http://www.g00gle.com
 */