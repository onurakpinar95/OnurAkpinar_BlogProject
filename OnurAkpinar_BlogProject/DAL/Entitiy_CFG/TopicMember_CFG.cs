using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class TopicMember_CFG : IEntityTypeConfiguration<TopicMember>
    {
        public void Configure(EntityTypeBuilder<TopicMember> builder)
        {
            builder.HasKey(x => x.TopicMemberID);
            builder.HasOne(x => x.Topic).WithMany(x => x.FollowingTopics);
            builder.HasOne(x => x.Member).WithMany(x => x.FollowingTopics);
        }
    }
}
