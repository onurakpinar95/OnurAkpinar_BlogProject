using Microsoft.AspNetCore.Identity;

namespace OnurAkpinar_BlogProject.Models.Entities
{
    public class Member: IdentityUser<int>
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? PictureFilePath { get; set; }

        public string? About { get; set; }

        public int? ConfirmCode { get; set; }    

        public ICollection<Article>? Articles { get; set; }

        public ICollection<TopicMember>? FollowingTopics { get; set; }
    }
}
