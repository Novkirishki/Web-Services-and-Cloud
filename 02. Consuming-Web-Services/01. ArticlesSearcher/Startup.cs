namespace _01.ArticlesSearcher
{
    using System;

    public class Startup
    {
        public static void Main()
        {
            // try "autem"

            Console.WriteLine("Input query string: ");
            var query = Console.ReadLine();
            Console.WriteLine("Input articles count: ");
            var count = int.Parse(Console.ReadLine());

            var posts = PostSearcher.Search(query, count);

            foreach (var post in posts)
            {
                Console.WriteLine(post);
            }
        }
    }
}
