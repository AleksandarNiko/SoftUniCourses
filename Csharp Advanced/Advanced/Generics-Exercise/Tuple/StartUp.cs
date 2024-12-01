namespace Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] personInfo = Console.ReadLine().Split();
            string firstName=personInfo[0];
            string lastName = personInfo[1];
            string address = personInfo[2];

            CustomTuple<string, string> firstPerson = new($"{firstName} {lastName}", address);

            string[] secondPersonInfo = Console.ReadLine().Split();
            string name = secondPersonInfo[0];
            int beerLiters = int.Parse(secondPersonInfo[1]);

            CustomTuple<string,int> secondPerson=new(name, beerLiters);

            string[] nums = Console.ReadLine().Split();
            int integerNum = int.Parse(nums[0]);
            double doubleNum = double.Parse(nums[1]);

            CustomTuple<int,double> thirdTuple=new(integerNum, doubleNum);

            Console.WriteLine(firstPerson);
            Console.WriteLine(secondPerson);
            Console.WriteLine(thirdTuple);

        }
    }
}
/*
Adam Smith California
Mark 2
23 21,23212321
 */