using Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class TagDataMapping : IEntityTypeConfiguration<TagData> {
        public void Configure (EntityTypeBuilder<TagData> builder) {
            builder.ToTable ("TagData");
            builder.HasKey (k => k.Id);

            builder.Property (p => p.Data).IsRequired ();

            builder.Property (a => a.IsMobile).HasDefaultValue (false);
            builder.Property (p => p.Continent).HasColumnType ("varchar(100)");
            builder.Property (p => p.ContinentCode).HasColumnType ("varchar(150)");
            builder.Property (p => p.Country).HasColumnType ("varchar(200)");
            builder.Property (p => p.Region).HasColumnType ("varchar(150)");
            builder.Property (p => p.RegionName).HasColumnType ("varchar(150)");
            builder.Property (p => p.City).HasColumnType ("varchar(200)");
            builder.Property (p => p.District).HasColumnType ("varchar(150)");
            builder.Property (p => p.Lat).HasColumnType ("varchar(150)");
            builder.Property (p => p.Lon).HasColumnType ("varchar(150)");
            builder.Property (p => p.PostalCode).HasColumnType ("varchar(150)");
            builder.Property (p => p.TimeZone).HasColumnType ("varchar(150)");
            builder.Property (p => p.Currency).HasColumnType ("varchar(150)");
            builder.Property (p => p.Iso).HasColumnType ("varchar(150)");
            builder.Property (p => p.Organization).HasColumnType ("varchar(max)");
            builder.Property (p => p.WebBrowserClient).HasColumnType ("varchar(150)");
            builder.Property (p => p.SoClient).HasColumnType ("varchar(150)");
            builder.Property (p => p.ISP).HasColumnType ("varchar(max)");

        }
    }
}