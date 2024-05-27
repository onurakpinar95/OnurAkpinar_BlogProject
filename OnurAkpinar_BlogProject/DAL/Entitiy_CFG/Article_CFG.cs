using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class Article_CFG : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasKey(x => x.ArticleID);
            builder.Property(x => x.ArticleHeader).HasColumnType("varchar").HasMaxLength(150);
            builder.Property(x => x.ReadingTime).HasColumnType("varchar").HasMaxLength(50);
            builder.HasOne(x => x.Member).WithMany(x => x.Articles).HasForeignKey(x=>x.MemberID);
            builder.HasData(
         new Article { ArticleID = 1, ArticleHeader = "Yapay Zeka ve Gelecekteki Rolü", ArticleContent = "Yapay zeka, günümüzün en hızlı gelişen teknolojilerinden biri olarak öne çıkıyor. Hem endüstriyel hem de günlük yaşamda etkili bir şekilde kullanılan yapay zeka, gelecekteki rolüyle de merak uyandırıyor. Yapay zeka, insanların işlerini kolaylaştırmak ve verimliliği artırmak için giderek daha fazla alanı kapsıyor. Özellikle otomasyon, sağlık, ulaşım ve eğitim gibi sektörlerde yapay zeka kullanımı hızla yayılıyor. Gelecekte, yapay zeka insan hayatında daha da entegre olacak ve birçok alanda önemli bir rol oynayacak gibi görünüyor.", MemberID = 1, ReadingTime = 3, ViewCounter = 10 },
         new Article { ArticleID = 2, ArticleHeader = "İnternetin Geleceği: Nesnelerin İnterneti", ArticleContent = "Nesnelerin İnterneti (IoT), internete bağlı cihazların ve nesnelerin birbirleriyle iletişim kurması ve veri alışverişi yapması olarak tanımlanıyor. IoT, ev otomasyonundan akıllı şehirlere kadar birçok alanda kullanılıyor ve gelecekte daha da yaygınlaşması bekleniyor. IoT teknolojisi, insanların yaşamını kolaylaştırırken aynı zamanda daha verimli ve sürdürülebilir bir gelecek için önemli bir rol oynuyor. Gelecekte, IoT'nin yaygınlaşmasıyla birlikte insanlar ve çevreleri arasındaki etkileşim daha akıllı ve bağlantılı hale gelecek.", MemberID = 1, ReadingTime = 3, ViewCounter = 15 },
         new Article { ArticleID = 3, ArticleHeader = "Dijital Stres ve Zihinsel Sağlık", ArticleContent = "Günümüzde dijital teknolojilerin yaygınlaşmasıyla birlikte dijital stres de artmaktadır. Sürekli olarak akıllı telefonlarımızı kontrol etmek, sosyal medya platformlarında sürekli etkileşimde olmak ve bilgi bombardımanına maruz kalmak, zihinsel sağlığımız üzerinde ciddi etkiler yaratabilir. Dijital stresin artmasıyla birlikte anksiyete ve depresyon gibi zihinsel sağlık sorunlarının da artış gösterdiği gözlemlenmektedir. Bu makalede, dijital stresin zihinsel sağlık üzerindeki etkileri incelenmekte ve dijital stresle başa çıkma stratejileri üzerine öneriler sunulmaktadır.", MemberID = 1, ReadingTime = 3, ViewCounter = 15 },
         new Article { ArticleID = 4, ArticleHeader = "Empati ve İnsan İlişkileri", ArticleContent = "Empati, insan ilişkilerinin temel unsurlarından biridir ve sağlıklı bir toplum için önemlidir. Empati, başkalarının duygularını anlama ve onlara karşı duyarlılık gösterme yeteneği olarak tanımlanır. Son yıllarda yapılan araştırmalar, empatinin azaldığını ve insanların birbirlerine daha az anlayış gösterdiğini göstermektedir. Bu makalede, empati kavramının önemi ve insan ilişkileri üzerindeki etkileri ele alınmakta ve empatik becerilerin geliştirilmesi için öneriler sunulmaktadır.", MemberID = 1, ReadingTime = 3, ViewCounter = 10 });

         
        }
    }
}
