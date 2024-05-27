namespace OnurAkpinar_BlogProject.Models.Entities
{
    public class Topic
    {
        public int TopicID { get; set; }

        public string TopicName { get; set; }   

        public ICollection<TopicArticle>? TopicArticles { get; set; }

        public ICollection<TopicMember>? FollowingTopics { get; set;}
    }
}
