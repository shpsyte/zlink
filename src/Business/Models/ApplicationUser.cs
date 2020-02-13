using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Business.Models {
    // public static class IdentityCustom {

    //     // public static ModelBuilder LoadIdentity (this ModelBuilder model) {
    //     //     // model.Entity<ApplicationUser> ().ToTable ("User");

    //     //     //  model.Entity<IdentityRole> ().ToTable ("Role");

    //     //     //model.Entity<IdentityUserClaim<int>> ().ToTable ("UserClaim");
    //     //     //model.Entity<IdentityUserClaim<int>> ().HasKey (a => new { a.UserId, a.Id });

    //     //     // model.Entity<IdentityUserRole<int>> ().ToTable ("UserRole");
    //     //     // model.Entity<IdentityUserRole<int>> ().HasKey (a => new { a.UserId, a.RoleId });

    //     //     // model.Entity<IdentityUserLogin<int>> ().ToTable ("UserLogin");
    //     //     // model.Entity<IdentityUserLogin<int>> ().HasKey (a => new { a.UserId, a.ProviderKey });

    //     //     // model.Entity<IdentityRoleClaim<int>> ().ToTable ("RoleClaim");
    //     //     // model.Entity<IdentityRoleClaim<int>> ().HasKey (a => new { a.RoleId, a.Id });

    //     //     // model.Entity<IdentityUserToken<int>> ().ToTable ("UserToken");
    //     //     // model.Entity<IdentityUserToken<int>> ().HasKey (a => new { a.UserId, a.LoginProvider });

    //     //     // return model;
    //     // }
    // }

    public class ApplicationUser : IdentityUser<int> {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }

        public string MainLinkImg { get; set; }

        public string Theme { get; set; }

        public byte[] Ico { get; set; }

        public string CssFile { get; set; }
        public IEnumerable<Tag> Tag { get; set; }

        public virtual ICollection<IdentityUserClaim<int>> Claims { get; set; }
        public virtual ICollection<IdentityUserLogin<int>> Logins { get; set; }
        public virtual ICollection<IdentityUserToken<int>> Tokens { get; set; }
        public virtual ICollection<IdentityUserRole<int>> UserRoles { get; set; }

    }

}