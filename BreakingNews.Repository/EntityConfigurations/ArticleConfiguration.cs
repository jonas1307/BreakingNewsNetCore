using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BreakingNews.Domain.Entities;

namespace BreakingNews.Repository.EntityConfigurations
{
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Articles");

            builder.HasKey(pk => pk.Id);

            builder.Property(p => p.Slug)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Title)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Author)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Category)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Summary)
                .HasMaxLength(256)
                .IsRequired();

            builder.Property(p => p.Body)
                .IsRequired();

            builder.Property(p => p.Status)
                .IsRequired();

            builder.Property(p => p.CreationDate)
                .IsRequired();

            builder.Property(p => p.ReleaseDate);

            builder.Property(p => p.LastUpdateDate);

            builder.HasIndex(x => x.Slug)
                .IsUnique()
                .HasDatabaseName("UNIQ_Articles_Slug");
        }
    }
}
