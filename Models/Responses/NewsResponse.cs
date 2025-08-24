namespace Studying.Models.Responses
{
    public class NewsResponse
    {
        public Article[] Articles { get; set; }
    }

    public class Article
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string PublishedAt { get; set; }
    //    public Source Source { get; set; }
    }

  /*  public class Source
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }*/
}
