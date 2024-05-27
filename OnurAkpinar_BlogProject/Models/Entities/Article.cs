namespace OnurAkpinar_BlogProject.Models.Entities
{
    public class Article
    {
        public int ArticleID { get; set; }

        public string? ArticleHeader { get; set; }

        public string? ArticleContent { get; set; }

        public int? ReadingTime { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public int? ViewCounter { get; set; }    

        public int? MemberID { get; set; }   

        public Member? Member { get; set; }  

        public ICollection<TopicArticle>? TopicArticles { get; set;}
    }
}
