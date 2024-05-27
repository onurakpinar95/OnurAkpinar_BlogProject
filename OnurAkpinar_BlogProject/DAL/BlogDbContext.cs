using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnurAkpinar_BlogProject.Models.Entities;
using System.Reflection;

namespace OnurAkpinar_BlogProject.DAL
{
    public class BlogDbContext : IdentityDbContext<Member, Role, int>
    {
        public BlogDbContext()
        {

        }
        public BlogDbContext(DbContextOptions options) : base(options)
        {
        }



        public DbSet<Article> Articles { get; set; }    

        public DbSet<Topic> Topics { get; set; }

        public DbSet<TopicArticle> TopicArticles { get; set; }

        public DbSet<TopicMember> TopicMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //User-Role tablosunda ilişkiyi yaz...
            builder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>() { UserId = 1, RoleId = 1 });
        }
    }
}
