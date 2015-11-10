namespace _01.ArticlesSearcher
{
    using System.Collections.Generic;
    using System.Linq;

    public class PostSearcher
    {
        private const string serviceUrl = "http://jsonplaceholder.typicode.com/posts";

        public static IEnumerable<Post> Search(string query, int count)
        {
            return  WebClientRequester.Get<IEnumerable<Post>>(serviceUrl).Where(p => p.Title.Contains(query)).Take(count);
        }
    }
}
