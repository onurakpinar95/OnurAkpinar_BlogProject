using Microsoft.EntityFrameworkCore;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class Topic_CFG : IEntityTypeConfiguration<Topic>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Topic> builder)
        {

            builder.HasKey(x => x.TopicID);
            builder.Property(x => x.TopicName).HasColumnType("varchar(50)");
            builder.HasData(
                    new Topic { TopicID = 1, TopicName = "Teknoloji" },
                    new Topic { TopicID = 2, TopicName = "Psikoloji" },
                    new Topic { TopicID = 3, TopicName = "Bilim" },
                    new Topic { TopicID = 4, TopicName = "Moda" },
                    new Topic { TopicID = 5, TopicName = "Tarih" }
    );
        }
    }
}
