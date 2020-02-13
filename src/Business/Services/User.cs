using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace Business.Services {
    public class User : IUser {
        private readonly IHttpContextAccessor _accessor;

        public User (IHttpContextAccessor accessor) { _accessor = accessor; }

        public int Id {
            get {
                return System.Convert.ToInt32 (_accessor.HttpContext.User.FindFirstValue (ClaimTypes.NameIdentifier));
            }
        }

        public byte[] AvatarImage () {
            return _accessor.HttpContext.Session.Get ("User.Settings.AvatarImage");
        }

        public IEnumerable<Claim> GetClaimsIdentity () {
            return _accessor.HttpContext.User.Claims;
        }

        public string UserName () {
            return _accessor.HttpContext.User.Identity.Name;
        }
    }
}