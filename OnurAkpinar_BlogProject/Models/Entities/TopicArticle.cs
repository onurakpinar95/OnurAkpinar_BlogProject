namespace OnurAkpinar_BlogProject.Models.Entities
{
    public class TopicArticle
    {
        public int TopicArticleID { get; set; }

        public int TopicID { get; set; }

        public Topic? Topic { get; set; }

        public int ArticleID { get; set; }

        public Article? Article { get; set; }
    }
}
