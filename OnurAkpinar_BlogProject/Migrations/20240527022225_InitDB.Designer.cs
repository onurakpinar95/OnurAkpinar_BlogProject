﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnurAkpinar_BlogProject.DAL;

#nullable disable

namespace OnurAkpinar_BlogProject.Migrations
{
    [DbContext(typeof(BlogDbContext))]
    [Migration("20240527022225_InitDB")]
    partial class InitDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Article", b =>
                {
                    b.Property<int>("ArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleID"));

                    b.Property<string>("ArticleContent")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleHeader")
                        .HasMaxLength(150)
                        .HasColumnType("varchar");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MemberID")
                        .HasColumnType("int");

                    b.Property<string>("ReadingTime")
                        .HasMaxLength(50)
                        .HasColumnType("varchar");

                    b.Property<int?>("ViewCounter")
                        .HasColumnType("int");

                    b.HasKey("ArticleID");

                    b.HasIndex("MemberID");

                    b.ToTable("Articles");

                    b.HasData(
                        new
                        {
                            ArticleID = 1,
                            ArticleContent = "Yapay zeka, günümüzün en hızlı gelişen teknolojilerinden biri olarak öne çıkıyor. Hem endüstriyel hem de günlük yaşamda etkili bir şekilde kullanılan yapay zeka, gelecekteki rolüyle de merak uyandırıyor. Yapay zeka, insanların işlerini kolaylaştırmak ve verimliliği artırmak için giderek daha fazla alanı kapsıyor. Özellikle otomasyon, sağlık, ulaşım ve eğitim gibi sektörlerde yapay zeka kullanımı hızla yayılıyor. Gelecekte, yapay zeka insan hayatında daha da entegre olacak ve birçok alanda önemli bir rol oynayacak gibi görünüyor.",
                            ArticleHeader = "Yapay Zeka ve Gelecekteki Rolü",
                            CreatedDate = new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9892),
                            MemberID = 1,
                            ReadingTime = "3",
                            ViewCounter = 10
                        },
                        new
                        {
                            ArticleID = 2,
                            ArticleContent = "Nesnelerin İnterneti (IoT), internete bağlı cihazların ve nesnelerin birbirleriyle iletişim kurması ve veri alışverişi yapması olarak tanımlanıyor. IoT, ev otomasyonundan akıllı şehirlere kadar birçok alanda kullanılıyor ve gelecekte daha da yaygınlaşması bekleniyor. IoT teknolojisi, insanların yaşamını kolaylaştırırken aynı zamanda daha verimli ve sürdürülebilir bir gelecek için önemli bir rol oynuyor. Gelecekte, IoT'nin yaygınlaşmasıyla birlikte insanlar ve çevreleri arasındaki etkileşim daha akıllı ve bağlantılı hale gelecek.",
                            ArticleHeader = "İnternetin Geleceği: Nesnelerin İnterneti",
                            CreatedDate = new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9906),
                            MemberID = 1,
                            ReadingTime = "3",
                            ViewCounter = 15
                        },
                        new
                        {
                            ArticleID = 3,
                            ArticleContent = "Günümüzde dijital teknolojilerin yaygınlaşmasıyla birlikte dijital stres de artmaktadır. Sürekli olarak akıllı telefonlarımızı kontrol etmek, sosyal medya platformlarında sürekli etkileşimde olmak ve bilgi bombardımanına maruz kalmak, zihinsel sağlığımız üzerinde ciddi etkiler yaratabilir. Dijital stresin artmasıyla birlikte anksiyete ve depresyon gibi zihinsel sağlık sorunlarının da artış gösterdiği gözlemlenmektedir. Bu makalede, dijital stresin zihinsel sağlık üzerindeki etkileri incelenmekte ve dijital stresle başa çıkma stratejileri üzerine öneriler sunulmaktadır.",
                            ArticleHeader = "Dijital Stres ve Zihinsel Sağlık",
                            CreatedDate = new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9907),
                            MemberID = 1,
                            ReadingTime = "3",
                            ViewCounter = 15
                        },
                        new
                        {
                            ArticleID = 4,
                            ArticleContent = "Empati, insan ilişkilerinin temel unsurlarından biridir ve sağlıklı bir toplum için önemlidir. Empati, başkalarının duygularını anlama ve onlara karşı duyarlılık gösterme yeteneği olarak tanımlanır. Son yıllarda yapılan araştırmalar, empatinin azaldığını ve insanların birbirlerine daha az anlayış gösterdiğini göstermektedir. Bu makalede, empati kavramının önemi ve insan ilişkileri üzerindeki etkileri ele alınmakta ve empatik becerilerin geliştirilmesi için öneriler sunulmaktadır.",
                            ArticleHeader = "Empati ve İnsan İlişkileri",
                            CreatedDate = new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9909),
                            MemberID = 1,
                            ReadingTime = "3",
                            ViewCounter = 10
                        });
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("About")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ConfirmCode")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("PictureFilePath")
                        .HasMaxLength(300)
                        .HasColumnType("varchar");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            About = "admin",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "981bd328-7288-48db-b346-c39eee476252",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            FirstName = "Onur",
                            LastName = "Admin",
                            LockoutEnabled = false,
                            NormalizedEmail = "admin@admin.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEGw8zNo1QkvEP3SXM2/bGP9YJ3t6nwJaTC3ZkX8SdQI60u6Sz85x8kBgOsmkxuMIxQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "53bc3afd-9020-4d1b-9f2a-9519273fa3e7",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        });
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "680f9323-64ba-44b0-a53c-c1da56a62099",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "34561f44-c63d-4327-b011-7bdd2c678bf9",
                            Name = "Member",
                            NormalizedName = "Member"
                        });
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Topic", b =>
                {
                    b.Property<int>("TopicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicID"));

                    b.Property<string>("TopicName")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("TopicID");

                    b.ToTable("Topics");

                    b.HasData(
                        new
                        {
                            TopicID = 1,
                            TopicName = "Teknoloji"
                        },
                        new
                        {
                            TopicID = 2,
                            TopicName = "Psikoloji"
                        },
                        new
                        {
                            TopicID = 3,
                            TopicName = "Bilim"
                        },
                        new
                        {
                            TopicID = 4,
                            TopicName = "Moda"
                        },
                        new
                        {
                            TopicID = 5,
                            TopicName = "Tarih"
                        });
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.TopicArticle", b =>
                {
                    b.Property<int>("TopicArticleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicArticleID"));

                    b.Property<int>("ArticleID")
                        .HasColumnType("int");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("TopicArticleID");

                    b.HasIndex("ArticleID");

                    b.HasIndex("TopicID");

                    b.ToTable("TopicArticles");

                    b.HasData(
                        new
                        {
                            TopicArticleID = 1,
                            ArticleID = 1,
                            TopicID = 1
                        },
                        new
                        {
                            TopicArticleID = 2,
                            ArticleID = 2,
                            TopicID = 1
                        },
                        new
                        {
                            TopicArticleID = 3,
                            ArticleID = 3,
                            TopicID = 2
                        },
                        new
                        {
                            TopicArticleID = 4,
                            ArticleID = 4,
                            TopicID = 2
                        });
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.TopicMember", b =>
                {
                    b.Property<int>("TopicMemberID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TopicMemberID"));

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<int>("TopicID")
                        .HasColumnType("int");

                    b.HasKey("TopicMemberID");

                    b.HasIndex("MemberID");

                    b.HasIndex("TopicID");

                    b.ToTable("TopicMembers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Article", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", "Member")
                        .WithMany("Articles")
                        .HasForeignKey("MemberID");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.TopicArticle", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Article", "Article")
                        .WithMany("TopicArticles")
                        .HasForeignKey("ArticleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Topic", "Topic")
                        .WithMany("TopicArticles")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Article");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.TopicMember", b =>
                {
                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Member", "Member")
                        .WithMany("FollowingTopics")
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnurAkpinar_BlogProject.Models.Entities.Topic", "Topic")
                        .WithMany("FollowingTopics")
                        .HasForeignKey("TopicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Member");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Article", b =>
                {
                    b.Navigation("TopicArticles");
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Member", b =>
                {
                    b.Navigation("Articles");

                    b.Navigation("FollowingTopics");
                });

            modelBuilder.Entity("OnurAkpinar_BlogProject.Models.Entities.Topic", b =>
                {
                    b.Navigation("FollowingTopics");

                    b.Navigation("TopicArticles");
                });
#pragma warning restore 612, 618
        }
    }
}
