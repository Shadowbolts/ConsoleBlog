using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp31.Configurations
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogEntity>
    {
        public void Configure(EntityTypeBuilder<BlogEntity> builder)
        {
            builder.ToTable("Blogs");

            builder.HasKey(b => b.Id);

            builder.HasMany(b => b.Comments)
                .WithOne(c => c.Blog);
        }
    }
}
