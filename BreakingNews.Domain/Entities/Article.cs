using BreakingNews.Domain.Enumerators;

namespace BreakingNews.Domain.Entities
{
    public class Article : Entity<Guid>
    {
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Body { get; set; }
        public string Slug { get; set; }
        public ArticleStatus Status { get; protected set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public DateTime? LastUpdateDate { get; set; }

        public void ChangeStatus(ArticleStatus status)
        {
            Status = status;

            if (status == ArticleStatus.Drafted)
            {
                CreationDate = DateTime.UtcNow;
            }

            if (status == ArticleStatus.Published)
            {
                ReleaseDate = DateTime.UtcNow;
            }
        }
    }
}
