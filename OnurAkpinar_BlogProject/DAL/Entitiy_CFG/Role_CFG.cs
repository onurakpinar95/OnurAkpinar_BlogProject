using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnurAkpinar_BlogProject.Models.Entities;

namespace OnurAkpinar_BlogProject.DAL.Entitiy_CFG
{
    public class Role_CFG : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {

            builder.HasData(
            new Role { Id = 1, Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = Guid.NewGuid().ToString() },
            new Role { Id = 2, Name = "Member", NormalizedName = "Member", ConcurrencyStamp = Guid.NewGuid().ToString() }

            );

        }
    }
}
