namespace BreakingNews.Application.DTOs
{
    public class CreateArticleDTO
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
    }
}
