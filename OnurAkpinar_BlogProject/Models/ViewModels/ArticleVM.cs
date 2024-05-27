using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.Models.ViewModels
{
    public class ArticleVM
    {

        public int? MemberID { get; set; }

        

        public List<string>? FollowedTopics { get; set; }

        public List<Article>? Articles { get; set; }

        public List<Topic>? Topics { get; set; }  

        public List<Topic>? AddableTopics { get; set; }

        public List<Topic>? MemberTopics { get; set; }
        
    }
}
