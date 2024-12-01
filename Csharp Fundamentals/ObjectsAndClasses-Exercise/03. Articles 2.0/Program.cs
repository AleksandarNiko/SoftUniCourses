class Article
{
    public Article(string title, string content, string author)
    {
        Title = title;
        Content = content;
        Author = author;
    }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Author { get; set; }


    public override string ToString()
    {
        return $"{Title} - {Content}: {Author}";
    }
}
internal class Program
    {
    static void Main(string[] args)
    {
        int numOfArticles = int.Parse(Console.ReadLine());
        List<Article> list = new List<Article>();

        for (int i = 0; i < numOfArticles; i++)
        {        
            string[] articles = Console.ReadLine().Split(", ");
            Article article = new Article("title", "content", "author");
            article.Title = articles[0];
            article.Content = articles[1];
            article.Author = articles[2];
            list.Add(article);
        }
        Console.WriteLine(string.Join ("\n",list));
    }
    }
