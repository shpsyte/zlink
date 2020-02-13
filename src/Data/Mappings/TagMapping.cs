using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class TagMapping : IEntityTypeConfiguration<Tag> {
        public void Configure (EntityTypeBuilder<Tag> builder) {
            builder.ToTable ("Tag");
            builder.HasKey (k => k.Id);

            builder.HasMany (a => a.TagData)
                .WithOne (a => a.Tag)
                .HasForeignKey (a => a.TagId);

            builder.Property (a => a.OpenNewTab)
                .HasDefaultValue (false);

            builder.Property (a => a.IsPriority)
                .HasDefaultValue (false);

            builder.Property (a => a.Active)
                .HasDefaultValue (true);

            builder.Property (a => a.Deleted)
                .HasDefaultValue (false);

            builder.Property (p => p.Name).HasColumnType ("varchar(max)");
            builder.Property (p => p.TargetLink).HasColumnType ("varchar(max)");
            builder.Property (p => p.HideInfo).HasColumnType ("varchar(max)");
            builder.Property (p => p.ShortText).HasColumnType ("varchar(max)");
            builder.Property (p => p.Campaing).HasColumnType ("varchar(max)");
            builder.Property (p => p.Parameters).HasColumnType ("varchar(max)");

        }
    }
}