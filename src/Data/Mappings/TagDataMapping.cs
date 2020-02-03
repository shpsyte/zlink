using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
  public class TagDataMapping : IEntityTypeConfiguration<TagData> {
    public void Configure (EntityTypeBuilder<TagData> builder) {
      builder.ToTable ("TagData");
      builder.HasKey (k => k.Id);
      builder.Property (p => p.Data)
        .IsRequired ();

      builder.Property (p => p.Region)
        .IsRequired ()
        .HasColumnType ("varchar(max)");

    }
  }
}