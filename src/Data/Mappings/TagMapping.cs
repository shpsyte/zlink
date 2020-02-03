using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class TagMapping : IEntityTypeConfiguration<Tag> {
        public void Configure (EntityTypeBuilder<Tag> builder) {
            builder.ToTable ("Tag");
            builder.HasKey (k => k.Id);
            builder.Property (p => p.Name)
                .IsRequired ();

            builder.Property (p => p.TargetLink)
                .IsRequired ();

            builder.HasMany (a => a.TagData)
                .WithOne (a => a.Tag)
                .HasForeignKey (a => a.TagId);

        }
    }

    public class TagDataMapping : IEntityTypeConfiguration<TagData> {
        public void Configure (EntityTypeBuilder<TagData> builder) {
            builder.ToTable ("TagData");
            builder.HasKey (k => k.Id);
            builder.Property (p => p.Data)
                .IsRequired ();

        }
    }
}