using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories {
    public class UserRepository : Repository<ApplicationUser>, IUserRepository {
        private readonly IHttpContextAccessor _accessor;
        public UserRepository (AppDbContext context, IHttpContextAccessor accessor) : base (context) {
            _accessor = accessor;
        }

        public int Id {
            get {
                return System.Convert.ToInt32 (_accessor.HttpContext.User.FindFirstValue (ClaimTypes.NameIdentifier));
            }
        }

        public IEnumerable<Claim> GetClaimsIdentity () {

            return _accessor.HttpContext.User.Claims;
        }

        public string UserName () {
            return _accessor.HttpContext.User.Identity.Name;
        }
    }
}