using GenericSwapMethodString;

namespace GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int numOfElements = int.Parse(Console.ReadLine());
            Box<string> box= new Box<string>();

            for (int i = 0; i < numOfElements; i++)
            {
                string currentElement= Console.ReadLine();
                box.Add(currentElement);
            }

           string valueToCompare= Console.ReadLine();

           Console.WriteLine(box.Count(valueToCompare));
        }

    }
}
/*
3
aa
aaa
bb
aa
*/