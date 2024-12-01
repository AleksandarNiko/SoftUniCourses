namespace ListyIterator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = new ListyIterator<string>();

            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] lineToken = input.Split();
                string command = lineToken[0];

                switch (command)
                {
                    case "Create":
                    iterator = new ListyIterator<string>(lineToken.Skip(1).ToArray());
                        break;

                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                }
            }
           
        }
    }
}
/*
Create Steve George
HasNext
Print
Move
Print
END
*/
