using System.Data;
using System.Net.WebSockets;

namespace _05._Applied_Arithmetics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();
            Func<string, List<int>, List<int>> calculate = (command, nums) =>
            {
                List<int> result = new List<int>();

                foreach (int number in nums)
                {
                        switch (command)
                        {
                            case "add":
                            result .Add(number+1);
                                break;
                            case "multiply":
                            result .Add(number*2);
                                break;
                            case "subtract":
                            result .Add(number-1);
                                break;
                            case "print":
                            Console.WriteLine(string.Join(" ", result));
                            break;
                        }
                    
                }

                return result;
            };
            Action <List<int>> print=nums=>
            Console.WriteLine(string.Join(" ", nums));
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input == "print")
                {
                    print(nums);
                }
                else
                {
                    nums=calculate(input,nums);
                }
            }
        }
    }
}
/*
1 2 3 4 5
add
add
print
end
*/
