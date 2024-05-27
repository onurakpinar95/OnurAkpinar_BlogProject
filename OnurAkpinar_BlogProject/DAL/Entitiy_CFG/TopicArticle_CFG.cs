using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class TopicArticle_CFG : IEntityTypeConfiguration<TopicArticle>
    {
        public void Configure(EntityTypeBuilder<TopicArticle> builder)
        {
            builder.HasKey(x => x.TopicArticleID);
            builder.HasOne(x => x.Topic).WithMany(x => x.TopicArticles);
            builder.HasOne(x => x.Article).WithMany(x => x.TopicArticles);
            builder.HasData(
            new TopicArticle()
            {
                TopicArticleID = 1,
                TopicID = 1,
                ArticleID = 1
            },
            new TopicArticle()
            {
                TopicArticleID = 2,
                TopicID = 1,
                ArticleID = 2
            },
            new TopicArticle()
            {
                TopicArticleID = 3,
                TopicID = 2,
                ArticleID = 3
            },
            new TopicArticle()
            {
                TopicArticleID = 4,
                TopicID = 2,
                ArticleID = 4
            });
        }
    }
}
