using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Business.Services {
    public class UserServices : IUserServices {
        private readonly IHttpContextAccessor _accessor;

        public UserServices (IHttpContextAccessor accessor) { _accessor = accessor; }

        public int Id {
            get {
                return System.Convert.ToInt32 (_accessor.HttpContext.User.FindFirstValue (ClaimTypes.NameIdentifier));
            }
        }

        public async Task<byte[]> Avatar () {
            return await Task.FromResult (_accessor.HttpContext.Session.Get ("User.Settings.AvatarImage"));
        }

        public IEnumerable<Claim> GetClaimsIdentity () {
            return _accessor.HttpContext.User.Claims;
        }

        public string UserName () {
            return _accessor.HttpContext.User.Identity.Name;
        }
    }
}