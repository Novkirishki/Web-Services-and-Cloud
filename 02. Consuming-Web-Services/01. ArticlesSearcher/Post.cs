namespace _01.ArticlesSearcher
{
    using System.Text;

    public class Post
    {
        public int UserId { get; set; }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("TiTle: " + this.Title);
            builder.AppendLine("Content: " + this.Body);

            return builder.ToString();
        }
    }
}
