using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class Member_CFG : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x => x.PictureFilePath).HasColumnType("varchar").HasMaxLength(300);
            
            Member member = new Member
            {
                Id = 1,
                FirstName="Onur",
                LastName="Admin",
                UserName = "admin@admin.com",
                NormalizedUserName = "ADMIN@ADMIN.COM",
                Email = "admin@admin.com",
                NormalizedEmail = "admin@admin.COM",
                About = "admin",
                EmailConfirmed = false,                
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //Tabloda sifre hash'li oldugundan; sifre haslandikten sonra gonderilir...
            PasswordHasher<Member> passwordHasher = new PasswordHasher<Member>();
            member.PasswordHash = passwordHasher.HashPassword(member, "sprAdmn_123");

            builder.HasData(member);
        }
    }
}
