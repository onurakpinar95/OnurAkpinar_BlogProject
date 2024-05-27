using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OnurAkpinar_BlogProject.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureFilePath = table.Column<string>(type: "varchar(300)", maxLength: 300, nullable: true),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmCode = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Topics",
                columns: table => new
                {
                    TopicID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicName = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topics", x => x.TopicID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleHeader = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: true),
                    ArticleContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingTime = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ViewCounter = table.Column<int>(type: "int", nullable: true),
                    MemberID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleID);
                    table.ForeignKey(
                        name: "FK_Articles_AspNetUsers_MemberID",
                        column: x => x.MemberID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicMembers",
                columns: table => new
                {
                    TopicMemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicMembers", x => x.TopicMemberID);
                    table.ForeignKey(
                        name: "FK_TopicMembers_AspNetUsers_MemberID",
                        column: x => x.MemberID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicMembers_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TopicArticles",
                columns: table => new
                {
                    TopicArticleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TopicID = table.Column<int>(type: "int", nullable: false),
                    ArticleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TopicArticles", x => x.TopicArticleID);
                    table.ForeignKey(
                        name: "FK_TopicArticles_Articles_ArticleID",
                        column: x => x.ArticleID,
                        principalTable: "Articles",
                        principalColumn: "ArticleID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TopicArticles_Topics_TopicID",
                        column: x => x.TopicID,
                        principalTable: "Topics",
                        principalColumn: "TopicID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 1, "680f9323-64ba-44b0-a53c-c1da56a62099", "Admin", "ADMIN" },
                    { 2, "34561f44-c63d-4327-b011-7bdd2c678bf9", "Member", "Member" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "About", "AccessFailedCount", "ConcurrencyStamp", "ConfirmCode", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PictureFilePath", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, "admin", 0, "981bd328-7288-48db-b346-c39eee476252", null, "admin@admin.com", false, "Onur", "Admin", false, null, "admin@admin.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEGw8zNo1QkvEP3SXM2/bGP9YJ3t6nwJaTC3ZkX8SdQI60u6Sz85x8kBgOsmkxuMIxQ==", null, false, null, "53bc3afd-9020-4d1b-9f2a-9519273fa3e7", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "Topics",
                columns: new[] { "TopicID", "TopicName" },
                values: new object[,]
                {
                    { 1, "Teknoloji" },
                    { 2, "Psikoloji" },
                    { 3, "Bilim" },
                    { 4, "Moda" },
                    { 5, "Tarih" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "ArticleID", "ArticleContent", "ArticleHeader", "CreatedDate", "MemberID", "ReadingTime", "ViewCounter" },
                values: new object[,]
                {
                    { 1, "Yapay zeka, günümüzün en hızlı gelişen teknolojilerinden biri olarak öne çıkıyor. Hem endüstriyel hem de günlük yaşamda etkili bir şekilde kullanılan yapay zeka, gelecekteki rolüyle de merak uyandırıyor. Yapay zeka, insanların işlerini kolaylaştırmak ve verimliliği artırmak için giderek daha fazla alanı kapsıyor. Özellikle otomasyon, sağlık, ulaşım ve eğitim gibi sektörlerde yapay zeka kullanımı hızla yayılıyor. Gelecekte, yapay zeka insan hayatında daha da entegre olacak ve birçok alanda önemli bir rol oynayacak gibi görünüyor.", "Yapay Zeka ve Gelecekteki Rolü", new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9892), 1, "3", 10 },
                    { 2, "Nesnelerin İnterneti (IoT), internete bağlı cihazların ve nesnelerin birbirleriyle iletişim kurması ve veri alışverişi yapması olarak tanımlanıyor. IoT, ev otomasyonundan akıllı şehirlere kadar birçok alanda kullanılıyor ve gelecekte daha da yaygınlaşması bekleniyor. IoT teknolojisi, insanların yaşamını kolaylaştırırken aynı zamanda daha verimli ve sürdürülebilir bir gelecek için önemli bir rol oynuyor. Gelecekte, IoT'nin yaygınlaşmasıyla birlikte insanlar ve çevreleri arasındaki etkileşim daha akıllı ve bağlantılı hale gelecek.", "İnternetin Geleceği: Nesnelerin İnterneti", new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9906), 1, "3", 15 },
                    { 3, "Günümüzde dijital teknolojilerin yaygınlaşmasıyla birlikte dijital stres de artmaktadır. Sürekli olarak akıllı telefonlarımızı kontrol etmek, sosyal medya platformlarında sürekli etkileşimde olmak ve bilgi bombardımanına maruz kalmak, zihinsel sağlığımız üzerinde ciddi etkiler yaratabilir. Dijital stresin artmasıyla birlikte anksiyete ve depresyon gibi zihinsel sağlık sorunlarının da artış gösterdiği gözlemlenmektedir. Bu makalede, dijital stresin zihinsel sağlık üzerindeki etkileri incelenmekte ve dijital stresle başa çıkma stratejileri üzerine öneriler sunulmaktadır.", "Dijital Stres ve Zihinsel Sağlık", new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9907), 1, "3", 15 },
                    { 4, "Empati, insan ilişkilerinin temel unsurlarından biridir ve sağlıklı bir toplum için önemlidir. Empati, başkalarının duygularını anlama ve onlara karşı duyarlılık gösterme yeteneği olarak tanımlanır. Son yıllarda yapılan araştırmalar, empatinin azaldığını ve insanların birbirlerine daha az anlayış gösterdiğini göstermektedir. Bu makalede, empati kavramının önemi ve insan ilişkileri üzerindeki etkileri ele alınmakta ve empatik becerilerin geliştirilmesi için öneriler sunulmaktadır.", "Empati ve İnsan İlişkileri", new DateTime(2024, 5, 27, 5, 22, 24, 491, DateTimeKind.Local).AddTicks(9909), 1, "3", 10 }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "TopicArticles",
                columns: new[] { "TopicArticleID", "ArticleID", "TopicID" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 1 },
                    { 3, 3, 2 },
                    { 4, 4, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MemberID",
                table: "Articles",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TopicArticles_ArticleID",
                table: "TopicArticles",
                column: "ArticleID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicArticles_TopicID",
                table: "TopicArticles",
                column: "TopicID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMembers_MemberID",
                table: "TopicMembers",
                column: "MemberID");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMembers_TopicID",
                table: "TopicMembers",
                column: "TopicID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "TopicArticles");

            migrationBuilder.DropTable(
                name: "TopicMembers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Topics");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
