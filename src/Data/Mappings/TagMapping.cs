using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class TagMapping : IEntityTypeConfiguration<Tag> {
        public void Configure (EntityTypeBuilder<Tag> builder) {
            builder.ToTable ("Tag");
            builder.HasKey (k => k.Id);
            builder.Property (p => p.Name)
                .IsRequired ()
                .HasColumnType ("varchar(max)");

            builder.Property (p => p.TargetLink)
                .IsRequired ()
                .HasColumnType ("varchar(max)");

            builder.Property (p => p.Campaingn)
                .IsRequired ()
                .HasColumnType ("varchar(max)");

            builder.Property (p => p.Parameters)
                .IsRequired ()
                .HasColumnType ("varchar(max)");

            builder.HasMany (a => a.TagData)
                .WithOne (a => a.Tag)
                .HasForeignKey (a => a.TagId);

        }
    }
}