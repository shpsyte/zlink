using System.Collections.Generic;
using System.Security.Claims;
using Business.Models;

namespace Business.Interfaces {
    public interface IUserRepository : IRepository<ApplicationUser> {
        int Id { get; }
        string UserName ();
        IEnumerable<Claim> GetClaimsIdentity ();

    }
}