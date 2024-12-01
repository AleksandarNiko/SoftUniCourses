namespace _02._Articles
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }  

        public  string  Title { get; set; }
        public  string Content { get; set; }
        public  string Author { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }
        public void ChangeAuthor(string author)
        {
            Author = author;
        }
        public void Rename(string newTitle)
        {
            Title = newTitle;
        }
        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] articles = Console.ReadLine().Split(", ");
            int numOfCommands=int.Parse(Console.ReadLine());
            Article article = new Article(articles[0], articles[1], articles[2]);
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] inputs = Console.ReadLine().Split(": ");
                string command = inputs[0];
                if(command == "Edit")
                {
                    article.Edit(inputs[1]);
                }
                if(command == "ChangeAuthor")
                {
                    article.ChangeAuthor(inputs[1]);
                }
                if( command == "Rename")
                {
                    article.Rename(inputs[1]);
                }
            }
            Console.WriteLine( article.ToString());
        }
    }
}
