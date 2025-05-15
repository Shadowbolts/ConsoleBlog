using ConsoleApp31.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ConsoleApp31.Configurations
{
    public class CommentaryConfiguration : IEntityTypeConfiguration<CommentaryEntity>
    {
        public void Configure(EntityTypeBuilder<CommentaryEntity> builder)
        {
            builder.ToTable("Comments");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
