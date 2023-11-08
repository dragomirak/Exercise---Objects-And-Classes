namespace P03.Articles2._0
{
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
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
            int n = int.Parse(Console.ReadLine());
            List<Article> articles = new List<Article>();

            for (int i = 0; i < n; i++)
            {
                string[] articleArray = Console.ReadLine().Split(", ");

                Article article = new Article(articleArray[0], articleArray[1], articleArray[2]);
                articles.Add(article);
            }

            //foreach (Article article in articles)
            //{
            //    Console.WriteLine(article);
            //}

            Console.WriteLine(string.Join(Environment.NewLine, articles));
        }
    }

}