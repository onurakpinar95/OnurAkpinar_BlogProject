namespace OnurAkpinar_BlogProject.Models.Entities
{
    public class TopicMember
    {
        public int TopicMemberID { get; set; }

        public int TopicID { get; set; }

        public Topic? Topic { get; set; }

        public int MemberID { get; set; }

        public Member? Member { get; set; }
    }
}
