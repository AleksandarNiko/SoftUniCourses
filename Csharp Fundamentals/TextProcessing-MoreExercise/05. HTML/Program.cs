namespace _05._HTML
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string title=Console.ReadLine();
            string content=Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"{title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"{content}");
            Console.WriteLine("</article>");
            string input;
            while((input = Console.ReadLine()) != "end of comments")
            {
                string comments=input;               
                Console.WriteLine("<div>");
                Console.WriteLine(comments);
                Console.WriteLine("</div>");
            }
        }
    }
}
/*
SoftUni Article
Some content of the SoftUni article
some comment
more comment
last comment
end of comments
*/