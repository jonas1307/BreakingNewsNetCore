using Bogus;
using BreakingNews.Domain.Entities;
using BreakingNews.Domain.Enumerators;

namespace BreakingNews.UnitTests.Entities
{
    public class ArticleTests
    {
        private readonly Faker Faker = new Faker();

        [Fact]
        public void Status_WhenDrafted_AssignsCreationDate()
        {
            // Arrange
            var article = new Article
            {
                Author = Faker.Person.FullName,
                Title = Faker.Lorem.Sentence(),
                Summary = Faker.Lorem.Sentence(15),
                Body = Faker.Lorem.Paragraphs(5, "."),
                Category = Faker.Lorem.Word(),
                Slug = Faker.Lorem.Slug()
            };

            // Act
            article.ChangeStatus(ArticleStatus.Drafted);

            // Assert
            Assert.NotEqual(default, article.CreationDate);
        }

        [Fact]
        public void Status_WhenPublished_AssignsReleaseDate()
        {
            // Arrange
            var article = new Article
            {
                Author = Faker.Person.FullName,
                Title = Faker.Lorem.Sentence(),
                Summary = Faker.Lorem.Sentence(15),
                Body = Faker.Lorem.Paragraphs(5, "."),
                Category = Faker.Lorem.Word(),
                Slug = Faker.Lorem.Slug()
            };

            // Act
            article.ChangeStatus(ArticleStatus.Published);

            // Assert
            Assert.NotEqual(default, article.ReleaseDate);
        }
    }
}