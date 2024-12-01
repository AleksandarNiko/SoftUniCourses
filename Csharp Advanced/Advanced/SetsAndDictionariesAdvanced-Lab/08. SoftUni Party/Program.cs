namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var regularGuests = new List<string>();
            var vipGuests = new List<string>();
            string input;
            int count = 0;

            while ((input=Console.ReadLine()).ToUpper() != "PARTY")
            {
                char firstChar = input[0];
                if (char.IsDigit(firstChar))
                {
                    if (!vipGuests.Contains(input))
                    {
                        vipGuests.Add(input);
                    }
                }
                else
                {
                    if (!regularGuests.Contains(input))
                    {
                        regularGuests.Add(input);
                    }
                }
            }

            while ((input=Console.ReadLine()).ToUpper() != "END")
            {
                if (vipGuests.Contains(input))
                {
                    vipGuests.Remove(input);
                }
                else if (regularGuests.Contains(input))
                {
                    regularGuests.Remove(input);
                }
            
            }
            count = vipGuests.Count + regularGuests.Count;
            Console.WriteLine(count);
            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }
            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
        }
    }
/*
7IK9Yo0h
9NoBUajQ
Ce8vwPmE
SVQXQCbc
tSzE5t0p
PARTY
9NoBUajQ
Ce8vwPmE
SVQXQCbc
END
 */