using System.Collections.Generic;
using System.Security.Claims;

namespace Business.Services {
    public interface IUser {
        int Id { get; }
        string UserName ();

        byte[] AvatarImage ();
        IEnumerable<Claim> GetClaimsIdentity ();

    }

}