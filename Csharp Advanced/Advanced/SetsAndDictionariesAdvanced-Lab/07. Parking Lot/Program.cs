namespace _07._Parking_Lot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[]lineToken=input.Split(", ",StringSplitOptions.RemoveEmptyEntries);
                string direction = lineToken[0].ToLower();
                string carNumber = lineToken[1];
                if (direction == "in")
                {
                    set.Add(carNumber);
                }
                else if (direction == "out")
                {
                    set.Remove(carNumber);
                }              
            }
            if(set.Count == 0) 
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string line in set)
                {
                    Console.WriteLine(line);
                }
            }
        }
    }
}
/*
IN, CA2844AA
IN, CA1234TA
OUT, CA2844AA
IN, CA9999TT
IN, CA2866HI
OUT, CA1234TA
IN, CA2844AA
OUT, CA2866HI
IN, CA9876HH
IN, CA2822UU
END
*/
