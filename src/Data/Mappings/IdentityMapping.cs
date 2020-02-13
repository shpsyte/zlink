using Business.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mappings {
    public class IdentityMapping : IEntityTypeConfiguration<ApplicationUser> {
        public void Configure (EntityTypeBuilder<ApplicationUser> builder) {
            builder.ToTable ("User");

            builder.HasMany (a => a.Tag)
                .WithOne (a => a.User)
                .HasForeignKey (a => a.UserId);

            builder.HasMany (e => e.Claims)
                .WithOne ()
                .HasForeignKey (uc => uc.UserId)
                .IsRequired ();

            builder.HasMany (e => e.Logins)
                .WithOne ()
                .HasForeignKey (ul => ul.UserId)
                .IsRequired ();

            // Each User can have many UserTokens
            builder.HasMany (e => e.Tokens)
                .WithOne ()
                .HasForeignKey (ut => ut.UserId)
                .IsRequired ();

            // Each User can have many entries in the UserRole join table
            builder.HasMany (e => e.UserRoles)
                .WithOne ()
                .HasForeignKey (ur => ur.UserId)
                .IsRequired ();

        }
    }
    public class IdentityRoleMapping : IEntityTypeConfiguration<IdentityRole<int>> {
        public void Configure (EntityTypeBuilder<IdentityRole<int>> builder) {
            builder.ToTable ("Role");

        }
    }

    public class IdentityUserClaimMapping : IEntityTypeConfiguration<IdentityUserClaim<int>> {
        public void Configure (EntityTypeBuilder<IdentityUserClaim<int>> builder) {
            builder.ToTable ("UserClaim");
            builder.HasKey (a => a.Id);
        }
    }

    public class IdentityUserLoginMapping : IEntityTypeConfiguration<IdentityUserLogin<int>> {
        public void Configure (EntityTypeBuilder<IdentityUserLogin<int>> builder) {

            builder.ToTable ("UserLogin");
            builder.HasKey (x => new { x.LoginProvider, x.ProviderKey });
        }

    }

    public class IdentityRoleClaimMapping : IEntityTypeConfiguration<IdentityRoleClaim<int>> {
        public void Configure (EntityTypeBuilder<IdentityRoleClaim<int>> builder) {

            builder.ToTable ("RoleClaim");
            builder.HasKey (a => new { a.RoleId, a.Id });

        }

    }

    public class IdentityUserTokenMapping : IEntityTypeConfiguration<IdentityUserToken<int>> {
        public void Configure (EntityTypeBuilder<IdentityUserToken<int>> builder) {
            builder.ToTable ("UserToken");
            builder.HasKey (a => new { a.UserId, a.LoginProvider, a.Name });

        }

    }

}