using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp31.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(u => u.Id);

            builder.HasMany(u => u.Comments)
                .WithOne(c => c.User);

            builder.HasMany(u => u.Blogs)
                .WithOne(b => b.Author);
        }
    }
}
